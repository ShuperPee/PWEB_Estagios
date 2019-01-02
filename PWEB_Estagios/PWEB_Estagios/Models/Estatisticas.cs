using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    public class Estatisticas
    {
        [Display(Name = "Empresa mais procurada")]
        public Empresa EmpresaMaisProcurada { get; set; }
        [Display(Name = "Numero de Alunos")]
        public int NAlunos { get; set; }

        [Display(Name = "Numero de Propostas")]
        public int NPropostas { get; set; }

        [Display(Name = "Numero de Docentes")]
        public int NDocentes { get; set; }

        [Display(Name = "Numero de Candidaturas")]
        public int NCandidaturas { get; set; }

        [Display(Name = "Numero de Empresas")]
        public int NEmpresas { get; set; }
        /*
         *  É de interesse que a própria comissão de estágios
         *  tenha acesso a uma secção de estatísticas o qual possa encontrar informação como: empresas mais procuradas
         *  por ano, total de estágios/projetos concluídos em determinado ano letivo, entre outras. É de referir que todas
         *  os estágios devem ter um orientador do DEIS, como tal, deverá ser possível ao docente ver a proposta que
         *  está a orientar, bem como o perfil do aluno. 
         */
         public Estatisticas()
        {

        }
    }
}