using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class DocenteController : Controller
    {

        private PropostasContext context = new PropostasContext();
        // GET: Docente
        [Authorize(Roles = "Docente")]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Docente")]
        public ActionResult Perfil()
        {
            string strCurrentUserId = User.Identity.GetUserId();
            return View(context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }

        [Authorize(Roles = "Docente")]
        public ActionResult Edit()
        {
            string strCurrentUserId = User.Identity.GetUserId();
            return View(context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }
        [HttpPost]
        [Authorize(Roles = "Docente")]
        public ActionResult Edit(Docente docente)
        {
            if(docente != null)
            {

                string strCurrentUserId = User.Identity.GetUserId();
                Docente contaDocente = context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                contaDocente.PrimeiroNome = docente.PrimeiroNome;
                contaDocente.Apelido = docente.Apelido;
                contaDocente.NumeroDocente = docente.NumeroDocente;
                if (ModelState.IsValid)
                {
                    
                    var contaToUpdate = context.Docentes.Where(s => s.UserId == strCurrentUserId).FirstOrDefault();
                    if (TryUpdateModel(contaToUpdate, "", new string[] { "PrimeiroNome", "Apelido", "NumeroDocente"}))
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
            return View(docente);
        }
    }
}