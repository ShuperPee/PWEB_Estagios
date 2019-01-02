using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
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
            if (User.IsInRole("Docente"))
            {
                string strCurrentUserId = User.Identity.GetUserId();
                Docente contaDocente = context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                if (contaDocente.Comisao == true)
                {
                    return RedirectToAction("VerComissao", "Proposta");
                }
            }
            IList<Proposta> listaPropostas = new List<Proposta>();
            foreach(Proposta i in context.Propostas)
            {
                if (i.Aprovado && i.Ativo)
                {
                    listaPropostas.Add(i);
                }
            }
            foreach(Proposta i in listaPropostas)
            {
                i.Docente = context.Docentes.Where(s => s.DocenteId == i.DocenteId).FirstOrDefault();
                i.Empresa = context.Empresas.Where(s => s.EmpresaId == i.EmpresaId).FirstOrDefault();
            }

            return View(listaPropostas);
        }
        [Authorize(Roles = "Docente")]
        public ActionResult VerComissao()
        { 
        IList<Proposta> listaPropostas = new List<Proposta>();
            foreach(Proposta i in context.Propostas)
            {
                if (i.Ativo)
                {
                    listaPropostas.Add(i);
                }
            }
            return View(listaPropostas);
        }
        [Authorize(Roles = "Docente")]
        public ActionResult AprovarProposta(int propostaId)
        {
            Proposta proposta = context.Propostas.Where(x => x.PropostaId == propostaId).FirstOrDefault();
            proposta.Aprovado = true;
            context.SaveChanges();
            return RedirectToAction("Ver", "Proposta");
        }
        [Authorize(Roles = "Docente")]
        public ActionResult RecusarProposta(int propostaId)
        {
            Proposta proposta = context.Propostas.Where(x => x.PropostaId == propostaId).FirstOrDefault();
            proposta.Aprovado = false;
            proposta.Ativo = false;
            context.SaveChanges();
            return RedirectToAction("Ver", "Proposta");
        }
        [Authorize(Roles = "Docente")]
        public ActionResult FimProposta(int propostaId)
        {
            Proposta proposta = context.Propostas.Where(x => x.PropostaId == propostaId).FirstOrDefault();
            if (proposta.Aprovado) {
                proposta.Ativo = false;
                context.SaveChanges();
            }
            return RedirectToAction("Ver", "Proposta");
        }
        // GET: Proposta Create
        [Authorize(Roles = "Docente, Empresa")]
        public ActionResult Create()
        {
            IList<String> nomeDocentes = new List<String>();
            IList<String> nomeEmpresas = new List<String>();
            IList<String> tipoProposta = new List<String>();
            IList<String> ramos = new List<String>();
            string strCurrentUserId = User.Identity.GetUserId();
            foreach (var i in context.Docentes)
            {
                nomeDocentes.Add(i.NumeroDocente.ToString());
            }
            foreach (var i in context.Empresas)
            {
                nomeEmpresas.Add(i.EmpresaNIF.ToString());
            }
            if (User.IsInRole("Empresa"))
            {
                nomeEmpresas.Clear();
                nomeEmpresas.Add(context.Empresas.Where(x => x.UserId == strCurrentUserId).FirstOrDefault().EmpresaNIF.ToString());
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
                        Docente = context.Docentes.Where(x => x.NumeroDocente == docNum).First(),
                        DocenteId = docId,
                        NomeDocente = context.Docentes.Where(x => x.NumeroDocente == docNum).FirstOrDefault().PrimeiroNome,
                        Empresa = context.Empresas.Where(x => x.EmpresaNIF == empreNif).First(),
                        EmpresaId = empreId,
                        NomeEmpresa = context.Empresas.Where(x => x.EmpresaNIF == empreNif).FirstOrDefault().Nome,
                        Descricao = proposta.Descricao,
                        Tipo = proposta.Tipo,
                        Ramos = proposta.Ramos,
                        Local = proposta.Local,
                        MediaMin = proposta.MediaMin,
                        NumeroCadeirasMinimas = proposta.NumeroCadeirasMinimas,
                        AnoLetivo = DateTime.Now,
                        Aprovado = false,
                        Ativo = true,
                        Alunos = new List<Aluno>(),
                        DocentesAuxiliares = new List<Docente>()
                    };
                    context.Propostas.Add(newProposta);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Não foi possivel atualizar o modelo!");
                        return RedirectToAction("Create", "Proposta");
                    }
                    return RedirectToAction("Ver", "Proposta");
                  }
                }
                return RedirectToAction("Create", "Proposta");
            }
        }
    }