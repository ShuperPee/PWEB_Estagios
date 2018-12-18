using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class DocenteController : Controller
    {
        // GET: Docente
        [Authorize(Roles = "Docente")]
        public ActionResult Index()
        {
            return View();
        }
    }
}