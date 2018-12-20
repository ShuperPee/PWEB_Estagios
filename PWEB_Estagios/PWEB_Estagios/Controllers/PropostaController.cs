using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class PropostaController : Controller
    {
        private PropostasContext context = new PropostasContext();
        // GET: Proposta
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Docente")]
        public ActionResult Create()
        {
            IList<String> nomeDocentes = new List<String>();
            IList<String> nomeEmpresas = new List<String>();
            foreach (var i in context.Docentes)
            {
                nomeDocentes.Add(i.PrimeiroNome+" " + i.Apelido + " : " + i.NumeroDocente);
            }
            foreach (var i in context.Empresas)
            {
                nomeEmpresas.Add(i.Nome + " " + i.Sede + " : " + i.EmpresaNIF);
            }
            ViewBag.Docentes = new SelectList(nomeDocentes.ToList());
            ViewBag.Empresas = new SelectList(nomeEmpresas.ToList());
            return View();
        }
        [HttpPost]
        public ActionResult Create(Proposta proposta)
        {

            return View(proposta);
        }
    }
}