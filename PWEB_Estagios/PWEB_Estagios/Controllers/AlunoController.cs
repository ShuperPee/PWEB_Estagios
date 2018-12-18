using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        [Authorize(Roles = "Aluno")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Aluno")]
        [Authorize(Roles = "Docente")]
        [Authorize(Roles = "Empresa")]
        public ActionResult Perfil()
        {

            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

    }
}