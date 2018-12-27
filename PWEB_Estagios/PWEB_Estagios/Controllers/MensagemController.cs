using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
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

        [Authorize(Roles = "Docente, Empresa, Aluno")]
        public ActionResult EscreverMensagem()
        {
            if (User.IsInRole("Docente"))
            {
                string strCurrentUserId = User.Identity.GetUserId();

            }
            if (User.IsInRole("Aluno"))
            {
                string strCurrentUserId = User.Identity.GetUserId();
            }
                
            return View();
        }
    }
}