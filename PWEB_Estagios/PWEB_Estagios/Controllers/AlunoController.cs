using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class AlunoController : Controller
    {

        private PropostasContext context = new PropostasContext();
        // GET: Aluno
        [Authorize(Roles = "Aluno")]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Aluno")]
        public ActionResult Perfil()
        {
            string strCurrentUserId = User.Identity.GetUserId();
            return View(context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }
        [Authorize(Roles = "Aluno")]
        public ActionResult Edit()
        {
            IList<String> ramos = new List<String>();
            string strCurrentUserId = User.Identity.GetUserId();
            ramos.Add(Ramo.DA.ToString());
            ramos.Add(Ramo.RAD.ToString());
            ramos.Add(Ramo.SI.ToString());
            ramos.Add(Ramo.COMUM.ToString());
            ViewBag.Ramos = new SelectList(ramos.ToList());
            return View(context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public ActionResult Edit(Aluno aluno)
        {
            if(aluno != null)
            {

                string strCurrentUserId = User.Identity.GetUserId();
                Aluno contaAluno = context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                contaAluno.PrimeiroNome = aluno.PrimeiroNome;
                contaAluno.Apelido = aluno.Apelido;
                contaAluno.NumeroAluno = aluno.NumeroAluno;
                contaAluno.NumeroCadeirasConcluidas = aluno.NumeroCadeirasConcluidas;
                contaAluno.Media = aluno.Media;
                contaAluno.Ramo = aluno.Ramo;
            if (ModelState.IsValid)
            {
                    var contaToUpdate = context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                    if(TryUpdateModel(contaToUpdate,"",new string[] {"PrimeiroNome", "Apelido", "NumeroAluno","NumeroCadeirasConcluidas", "Media" }))
                    {
                        try
                        {
                            context.SaveChanges();
                            return RedirectToAction("Perfil");
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("", "Não foi possivel atualizar o modelo!");
                        }
                    }
                return RedirectToAction("Perfil");
            }

            }
            return View(aluno);
        }

    }
}