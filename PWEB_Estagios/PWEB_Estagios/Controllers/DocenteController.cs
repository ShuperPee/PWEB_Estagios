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
            return View();
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
    }
}