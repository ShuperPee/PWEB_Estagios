using Microsoft.AspNet.Identity;
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
                CandidaturaPropostaId = 1,
                Aluno = contaAluno,
                AlunoId = contaAluno.AlunoId,
                Aprovado = false,
                PropostaId = propostaId,
                Proposta = context.Propostas.Where(x => x.PropostaId == propostaId).FirstOrDefault()
            };
            
            context.Candidaturas.Add(newCandidatura);
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
    }
}