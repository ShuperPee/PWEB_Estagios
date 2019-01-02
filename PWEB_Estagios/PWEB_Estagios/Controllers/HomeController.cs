using PWEB_Estagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PWEB_Estagios.Controllers
{
    public class HomeController : Controller
    {
        private PropostasContext context = new PropostasContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //falta fazer
        public ActionResult ListaPropostas()
        {
            return View(context.Propostas.Where(x => x.Aprovado == true));
        }

        //falta fazer
        public ActionResult Estatisticas()
        {
            Estatisticas stats = new Estatisticas()
            {
                EmpresaMaisProcurada = new Empresa(),
                NAlunos = context.Alunos.Count(),
                NPropostas = context.Propostas.Count(),
                NDocentes = context.Docentes.Count(),
                NCandidaturas = context.Candidaturas.Count(),
                NEmpresas = context.Empresas.Count(),
            };

            int maior = 0;
            int idPropostaMaior = context.Candidaturas.FirstOrDefault().PropostaId;
            int auxmaior = 0;
            IList<CandidaturaProposta> listaCandidaturas = new List<CandidaturaProposta>();
            foreach(CandidaturaProposta i in context.Candidaturas)
            {
                listaCandidaturas.Add(i);
            }
            foreach (CandidaturaProposta i in context.Candidaturas)
            {

                foreach(CandidaturaProposta j in listaCandidaturas)
                {
                    if(j.PropostaId == i.PropostaId)
                    {
                        auxmaior++;
                    }
                }
                auxmaior = auxmaior - 1; // tirar aquela do i
                if(maior < auxmaior)
                {
                    idPropostaMaior = i.PropostaId;
                    maior = auxmaior;
                }
            }
            int empresaId = context.Propostas.Where(x => x.PropostaId == idPropostaMaior).FirstOrDefault().EmpresaId;
            stats.EmpresaMaisProcurada = context.Empresas.Where(x => x.EmpresaId == empresaId).FirstOrDefault();
            return View(stats);
        }
    }
}