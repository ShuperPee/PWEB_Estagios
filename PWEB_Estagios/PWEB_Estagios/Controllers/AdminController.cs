using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class AdminController : Controller
    {
        private PropostasContext context = new PropostasContext();
        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ListarDocentes()
        {
            return View(context.Docentes);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult VisualizarDocentes()
        {
            return View(context.Docentes);
        }
        public ActionResult AddComissao(int docenteId)
        {
            Docente docente = context.Docentes.Where(x => x.DocenteId == docenteId).FirstOrDefault();
            docente.Comisao = true;
            context.SaveChanges();
            return RedirectToAction("ListarDocentes", "Admin");
        }
        public ActionResult RemoveComissao(int docenteId)
        {
            Docente docente = context.Docentes.Where(x => x.DocenteId == docenteId).FirstOrDefault();
            docente.Comisao = false;
            context.SaveChanges();
            return RedirectToAction("ListarDocentes", "Admin");
        }
    }
}