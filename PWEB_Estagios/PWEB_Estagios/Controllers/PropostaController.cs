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

        [Authorize(Roles = "Docente, Empresa")]
        public ActionResult Create()
        {
            IList<String> nomeDocentes = new List<String>();
            IList<String> nomeEmpresas = new List<String>();
            IList<String> tipoProposta = new List<String>();
            IList<String> ramos = new List<String>();
            foreach (var i in context.Docentes)
            {
                //nomeDocentes.Add(i.PrimeiroNome+" " + i.Apelido + " : " + i.NumeroDocente);
                nomeDocentes.Add(i.NumeroDocente.ToString());
            }
            foreach (var i in context.Empresas)
            {
                //nomeEmpresas.Add(i.Nome + " " + i.Sede + " : " + i.EmpresaNIF);
                nomeEmpresas.Add(i.EmpresaNIF.ToString());
            }
            tipoProposta.Add(TipoProposta.Estagio.ToString());
            tipoProposta.Add(TipoProposta.Projeto.ToString());
            ramos.Add(Ramo.DA.ToString());
            ramos.Add(Ramo.RAD.ToString());
            ramos.Add(Ramo.SI.ToString());
            ViewBag.Docentes = new SelectList(nomeDocentes.ToList());
            ViewBag.Empresas = new SelectList(nomeEmpresas.ToList());
            ViewBag.Tipos = new SelectList(tipoProposta.ToList());
            ViewBag.Ramos = new SelectList(ramos.ToList());
            return View();
        }
        [HttpPost]
        public ActionResult Create(Proposta proposta)
        {
            Proposta newProposta = new Proposta();
            int j;
            if(int.TryParse(proposta.DocentesSelect, out j)){
                newProposta.DocenteId = j;
                newProposta.Docente = context.Docentes.Where(x => x.DocenteId == j).FirstOrDefault();
            }
            if(int.TryParse(proposta.EmpresasSelect,out j))
            {
                newProposta.Empresa = context.Empresas.Where(x => x.EmpresaNIF == j).FirstOrDefault();
                newProposta.EmpresaId = newProposta.Empresa.EmpresaId;
            }
            newProposta.Descricao = proposta.Descricao;
            newProposta.Tipo = proposta.Tipo;
            newProposta.Ramos = proposta.Ramos;
            newProposta.Local = proposta.Local;
            newProposta.MediaMin = proposta.MediaMin;
            newProposta.NumeroCadeirasMinimas = proposta.NumeroCadeirasMinimas;
            newProposta.AnoLetivo = new DateTime();
            newProposta.Aprovado = false;
            newProposta.Alunos = new List<Aluno>();
            newProposta.DocentesAuxiliares = new List<Docente>();
            context.Propostas.Add(newProposta);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}