using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    public class Estatisticas
    {
        IList<Empresa> empresasMaisProcuradas { get; set; }
        int NAlunos { get; set; }
        int NPropostas { get; set; }
        int NDocentes { get; set; }
        int NCandidaturas { get; set; }
        int NEmpresas { get; set; }
        /*
         * 
         * . É de interesse que a própria comissão de estágios
tenha acesso a uma secção de estatísticas o qual possa encontrar informação como: empresas mais procuradas
por ano, total de estágios/projetos concluídos em determinado ano letivo, entre outras. É de referir que todas
os estágios devem ter um orientador do DEIS, como tal, deverá ser possível ao docente ver a proposta que
está a orientar, bem como o perfil do aluno. 
         */
    }
}