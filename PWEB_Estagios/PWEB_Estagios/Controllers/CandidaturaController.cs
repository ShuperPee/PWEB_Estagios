﻿using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PWEB_Estagios.Controllers
{
    public class CandidaturaController : Controller
    {
        private PropostasContext context = new PropostasContext();
        // GET: Candidatura
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Aluno")]
        public ActionResult Candidatura()
        {
            return View(context.Propostas);
        }
        [Authorize(Roles = "Aluno")]
        public ActionResult FazerCandidatura(int propostaId)
        {
            string strCurrentUserId = User.Identity.GetUserId();
            Aluno contaAluno = context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();

            foreach (CandidaturaProposta i in context.Candidaturas)
            {
                if(i.AlunoId == contaAluno.AlunoId && i.PropostaId == propostaId)
                {
                    TempData["msg"] = "<script>alert('Já realizou essa candidatura');</script>";

                    return RedirectToAction("Candidatura", "Candidatura");
                }
            }
            CandidaturaProposta newCandidatura = new CandidaturaProposta()
            {
                CandidaturaPropostaId = context.Candidaturas.Count() + 1,
                Aluno = contaAluno,
                AlunoId = contaAluno.AlunoId,
                AlunoNome = contaAluno.PrimeiroNome,
                Aprovado = false,
                PropostaId = propostaId,
                Proposta = context.Propostas.Where(x => x.PropostaId == propostaId).FirstOrDefault()
            };
            
            context.Candidaturas.Add(newCandidatura);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Não foi possivel atualizar o modelo!");
            }
            return RedirectToAction("ListarCandidaturas", "Candidatura");
        }

        [Authorize(Roles = "Aluno")]
        public ActionResult ListarCandidaturas()
        {
            IList<CandidaturaProposta> minhasCandidaturas = new List<CandidaturaProposta>();
            int alunoId = 0;

            string strCurrentUserId = User.Identity.GetUserId();
            alunoId = context.Alunos.Where(x => x.UserId == strCurrentUserId).FirstOrDefault().AlunoId;

            foreach(CandidaturaProposta i in context.Candidaturas)
            {
                if(i.AlunoId == alunoId)
                {
                    minhasCandidaturas.Add(i);
                }
            }

            return View(minhasCandidaturas);
        }

        [Authorize(Roles = "Docente")]
        public ActionResult ListarTodasCandidaturas()
        {
            return View(context.Candidaturas);
        }
        [Authorize(Roles = "Docente")]
        public ActionResult AprovarCandidatura(int candidaturaId)
        {
            CandidaturaProposta candidatura = context.Candidaturas.Where(x => x.CandidaturaPropostaId == candidaturaId).FirstOrDefault();
            if (candidatura.Aprovado)
            {
                TempData["msg"] = "<script>alert('A Candidatura já se encontra aprovada');</script>";
                return RedirectToAction("ListarTodasCandidaturas", "Candidatura");
            }else
            candidatura.Aprovado = true;
            context.SaveChanges();
            return RedirectToAction("ListarTodasCandidaturas", "Candidatura");
        }
        [Authorize(Roles = "Docente")]
        public ActionResult RecusarCandidatura(int candidaturaId)
        {
            CandidaturaProposta candidatura = context.Candidaturas.Where(x => x.CandidaturaPropostaId == candidaturaId).FirstOrDefault();
            if (candidatura.Aprovado)
            {
                TempData["msg"] = "<script>alert('A Candidatura já se encontra aprovada');</script>";
                return RedirectToAction("ListarTodasCandidaturas", "Candidatura");
            }
            else
            context.Candidaturas.Remove(candidatura);
            context.SaveChanges();
            return RedirectToAction("ListarTodasCandidaturas", "Candidatura");
        }
        [Authorize(Roles = "Docente")]
        public ActionResult AvaliarCandidatura()
        {
            return View(context.Candidaturas.Where(x => x.Aprovado == true));
        }
        [Authorize(Roles = "Docente")]
        public ActionResult Avaliar(int candidaturaId)
        {
            return View(context.Candidaturas.Where(x => x.CandidaturaPropostaId == candidaturaId).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Avaliar(CandidaturaProposta candidatura)
        {
            if (candidatura != null)
            {
                CandidaturaProposta prop = context.Candidaturas.Where(x => x.CandidaturaPropostaId == candidatura.CandidaturaPropostaId).FirstOrDefault();
                prop.NotaProposta = candidatura.NotaProposta;
                if (ModelState.IsValid)
                {
                    var contaToUpdate = context.Propostas.Where(s => s.PropostaId == candidatura.PropostaId).FirstOrDefault();
                    if (TryUpdateModel(contaToUpdate, "", new string[] { "NotaProposta" }))
                    {
                        try
                        {
                            context.SaveChanges();
                            return RedirectToAction("AvaliacoesConcluidas", "Candidatura");
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("", "Não foi possivel atualizar o modelo!");
                        }
                    }
                    return RedirectToAction("AvaliacoesConcluidas", "Candidatura");
                }
            }
            return RedirectToAction("AvaliacoesConcluidas", "Candidatura");
        }

        public ActionResult AvaliacoesConcluidas()
        {
            return View(context.Candidaturas.Where(x => x.NotaProposta > 0));
        }
        [Authorize(Roles = "Empresa")]
        public ActionResult Candidatos()
        {
            IList<Aluno> listaAlunos = new List<Aluno>();
            IList<Proposta> listaProposta = new List<Proposta>();
            IList<CandidaturaProposta> listaCandidaturas = new List<CandidaturaProposta>();
            string strCurrentUserId = User.Identity.GetUserId();
            int empresaId = context.Empresas.Where(s => s.UserId == strCurrentUserId).FirstOrDefault().EmpresaId;

            foreach (CandidaturaProposta i in context.Candidaturas)
            {
                listaCandidaturas.Add(i);
            }
            foreach (Proposta i in context.Propostas)
            {
                listaProposta.Add(i);
            }

            foreach (CandidaturaProposta i in listaCandidaturas)
            {
                foreach (Proposta y in listaProposta)
                {
                    if(i.PropostaId == y.PropostaId)
                    {
                        if(y.EmpresaId == empresaId)
                        {
                            Aluno aluno = context.Alunos.Where(x => x.AlunoId == i.AlunoId).FirstOrDefault();
                            if (listaAlunos.IndexOf(aluno) == -1)
                            {
                                listaAlunos.Add(aluno);
                            }
                        }
                    }
                }
                
            }
            return View(listaAlunos);
        }
    }
}