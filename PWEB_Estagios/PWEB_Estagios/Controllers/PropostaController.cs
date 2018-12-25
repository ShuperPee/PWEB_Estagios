﻿using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class PropostaController : Controller
    {
        private PropostasContext context = new PropostasContext();
        // GET: Proposta
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Docente, Empresa, Aluno")]
        public ActionResult Ver()
        {
            return View(context.Propostas.ToList());
        }
        // GET: Proposta Create
        [Authorize(Roles = "Docente, Empresa")]
        public ActionResult Create()
        {
            IList<String> nomeDocentes = new List<String>();
            IList<String> nomeEmpresas = new List<String>();
            IList<String> tipoProposta = new List<String>();
            IList<String> ramos = new List<String>();
            foreach (var i in context.Docentes)
            {
                //nomeDocentes.Add(i.PrimeiroNome+" " + i.Apelido + " : " + i.NumeroDocente);
                nomeDocentes.Add(i.NumeroDocente.ToString());
            }
            foreach (var i in context.Empresas)
            {
                //nomeEmpresas.Add(i.Nome + " " + i.Sede + " : " + i.EmpresaNIF);
                nomeEmpresas.Add(i.EmpresaNIF.ToString());
            }
            tipoProposta.Add(TipoProposta.Estagio.ToString());
            tipoProposta.Add(TipoProposta.Projeto.ToString());
            ramos.Add(Ramo.DA.ToString());
            ramos.Add(Ramo.RAD.ToString());
            ramos.Add(Ramo.SI.ToString());
            ramos.Add(Ramo.COMUM.ToString());
            ViewBag.Docentes = new SelectList(nomeDocentes.ToList());
            ViewBag.Empresas = new SelectList(nomeEmpresas.ToList());
            ViewBag.Tipos = new SelectList(tipoProposta.ToList());
            ViewBag.Ramos = new SelectList(ramos.ToList());
            return View();
        }
        // POST: Proposta Create
        [HttpPost]
        [Authorize(Roles = "Docente, Empresa")]
        public ActionResult Create(Proposta proposta)
        {
            int docId, empreId,docNum = 0, empreNif = 0;

             if (ModelState.IsValid)
             {
                if (proposta != null)
                {
                    docNum = Convert.ToInt32(proposta.DocentesSelect);
                    empreNif = Convert.ToInt32(proposta.EmpresasSelect);
                    docId = context.Docentes.Where(x => x.NumeroDocente == docNum).FirstOrDefault().DocenteId;
                    empreId = context.Empresas.Where(x => x.EmpresaNIF == empreNif).FirstOrDefault().EmpresaId;
                    Proposta newProposta = new Proposta()
                    {
                        PropostaId = 1,
                        Docente = context.Docentes.Where(x => x.NumeroDocente == docId).FirstOrDefault(),
                        DocenteId = docId,
                        Empresa = context.Empresas.Where(x => x.EmpresaNIF == empreId).FirstOrDefault(),
                        EmpresaId = empreId,
                        Descricao = proposta.Descricao,
                        Tipo = proposta.Tipo,
                        Ramos = proposta.Ramos,
                        Local = proposta.Local,
                        MediaMin = proposta.MediaMin,
                        NumeroCadeirasMinimas = proposta.NumeroCadeirasMinimas,
                        AnoLetivo = DateTime.Now,
                        Aprovado = false,
                        Alunos = new List<Aluno>(),
                        DocentesAuxiliares = new List<Docente>()
                    };
                    context.Propostas.Add(newProposta);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        //Create empty list to capture Validation error(s)
                        var outputLines = new List<string>();

                        foreach (var eve in e.EntityValidationErrors)
                        {
                            outputLines.Add(
                                $"{DateTime.Now}: Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                            outputLines.AddRange(eve.ValidationErrors.Select(ve =>
                                $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\""));
                        }
                        Console.Write(outputLines);
                    }
                    return RedirectToAction("Ver", "Proposta");
                  }
                }
                return RedirectToAction("Create", "Proposta");
            }
        }
    }