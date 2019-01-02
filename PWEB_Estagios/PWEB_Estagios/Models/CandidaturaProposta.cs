using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    [Table("Candidaturas")]
    public class CandidaturaProposta
    {
        [Required]
        //[Key]
        [Display(Name = "Numero de Candidatura")]
        public int CandidaturaPropostaId { get; set; }

        [Required]
        [ForeignKey("Proposta")]
        [Display(Name = "Proposta ID")]
        public int PropostaId { get; set; }
        public Proposta Proposta { get; set; }

        [Required]
        [ForeignKey("Aluno")]
        [Display(Name = "Aluno ID")]
        public int AlunoId { get; set; }

        public String AlunoNome { get; set; }

        public Aluno Aluno { get; set; }

        public Boolean Aprovado { get; set; } = false;
        [Display(Name = "Nota")]
        public int NotaProposta { get; set; }

        public CandidaturaProposta()
        {

        }
    }
}