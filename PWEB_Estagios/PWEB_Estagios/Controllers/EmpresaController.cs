using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        [Authorize(Roles = "Empresa")]
        public ActionResult Index()
        {
            return View();
        }
    }
}