using Microsoft.AspNet.Identity;
using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }
        [Authorize(Roles = "Aluno")]
        public ActionResult Perfil()
        {
            return View(context.Alunos.Find(1));
        }
        public ActionResult Edit()
        {
            string strCurrentUserId = User.Identity.GetUserId();

           // return View(strCurrentUserId);

            return View(context.Alunos.Where(s => s.UserId == strCurrentUserId).FirstOrDefault());
        }
        public ActionResult Avout()
        {
            string strCurrentUserId = User.Identity.GetUserId();

            ViewBag.Message = strCurrentUserId;

            return View();

            //return View(context.Alunos.Where(s => s.UserId == strCurrentUserId));
        }

    }
}