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
    public class MensagemController : Controller
    {
        private PropostasContext context = new PropostasContext();
        // GET: Mensagem
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Docente, Aluno")]
        public ActionResult EscreverMensagem()
        {
            IList<String> emailAlunos = new List<String>();
            IList<String> emailDocentes = new List<String>();


            foreach (var i in context.Docentes)
            {
                //nomeDocentes.Add(i.PrimeiroNome+" " + i.Apelido + " : " + i.NumeroDocente);
                emailDocentes.Add(i.Email);
            }
            foreach (var i in context.Alunos)
            {
                //nomeDocentes.Add(i.PrimeiroNome+" " + i.Apelido + " : " + i.NumeroDocente);
                emailAlunos.Add(i.Email);
            }
            string strCurrentUserId = User.Identity.GetUserId();
            if (User.IsInRole("Aluno"))
            {
                ViewBag.User = context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault().AlunoId;
            }
            if (User.IsInRole("Docente"))
            {
                ViewBag.User = context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault().DocenteId;
            }

            ViewBag.Docentes = new SelectList(emailDocentes.ToList());
            ViewBag.Alunos = new SelectList(emailAlunos.ToList());


            return View();
        }

        [HttpPost]
        public ActionResult EscreverMensagem(Mensagem mensagem)
        {
            int docId = 0;
            int alunoId = 0;
            String email;
            if (ModelState.IsValid)
            {
                if (mensagem != null)
                {
                    //customers.ToList().Where(c => c.CustomerID.CompareTo(txtSerchId.Text) >= 0);

                    if (User.IsInRole("Aluno"))
                    {
                        string strCurrentUserId = User.Identity.GetUserId();
                        alunoId = context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault().AlunoId;
                        email = mensagem.DocentesSelect;
                        docId = context.Docentes.Where(x => x.Email.CompareTo(email) == 0).FirstOrDefault().DocenteId;
                    }
                    if (User.IsInRole("Docente"))
                    {
                        string strCurrentUserId = User.Identity.GetUserId();
                        docId = context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault().DocenteId;
                        email = mensagem.AlunosSelect;
                        alunoId = context.Alunos.Where(x => x.Email.CompareTo(email) == 0).FirstOrDefault().AlunoId;
                    }

                    Mensagem newMensagem = new Mensagem()
                    {
                        MensagemID = 1,
                        DocentId = docId,
                        AlunoId = alunoId,
                        Texto = mensagem.Texto,
                        Aluno = context.Alunos.Where(s => s.AlunoId == alunoId).FirstOrDefault(),
                        Docente = context.Docentes.Where(s => s.DocenteId == docId).FirstOrDefault()

                    };
                    context.Mensagens.Add(newMensagem);

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        ModelState.AddModelError("", "Não foi possivel atualizar o modelo!");
                    }
                    return RedirectToAction("LerMensagem", "Mensagem");
                }
            }
            return RedirectToAction("EscreverMensagem", "Mensagem");
        }

        [Authorize(Roles = "Docente, Aluno")]
        public ActionResult LerMensagem()
        {
            IList<Mensagem> listaMensagens = new List<Mensagem>();
            int alunoId = 0;
            int docId = 0;

            if (User.IsInRole("Aluno"))
            {
                string strCurrentUserId = User.Identity.GetUserId();
                alunoId = context.Alunos.Where(x => x.UserId == strCurrentUserId).FirstOrDefault().AlunoId;
            }
            if (User.IsInRole("Docente"))
            {
                string strCurrentUserId = User.Identity.GetUserId();
                docId = context.Docentes.Where(x => x.UserId == strCurrentUserId).FirstOrDefault().DocenteId;
            }

            foreach (Mensagem i in context.Mensagens)
            {
                if(i.DocentId == docId || i.AlunoId == alunoId)
                {
                    
                    listaMensagens.Add(i);
                }
            }
            foreach(Mensagem i in listaMensagens)
            {
                i.Docente = context.Docentes.Where(x => x.DocenteId == i.DocentId).FirstOrDefault();
                i.Aluno = context.Alunos.Where(x => x.AlunoId == i.AlunoId).FirstOrDefault();
            }
            return View(listaMensagens);
        }

    }
}