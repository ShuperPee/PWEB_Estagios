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
        public int PropostaId { get; set; }
        public Proposta Proposta { get; set; }

        [Required]
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }

        public Boolean Aprovado { get; set; } = false;

        [Display(Name = "Seleciona Proposta")]
        public string PropostasSelect { get; set; }
    }
}