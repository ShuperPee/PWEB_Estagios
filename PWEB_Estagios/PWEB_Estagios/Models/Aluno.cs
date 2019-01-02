using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    [Table ("Alunos")]
    public class Aluno
    {
        [Display(Name = "Aluno ID")]
        public int AlunoId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Primeiro Nome")]
        public string PrimeiroNome { get; set; }
        
        [MaxLength(100)]
        [Display(Name = "Ultimo Nome")]
        public string Apelido { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        public Ramo? Ramo { get; set; }

        public IList<CandidaturaProposta> CandidaturaProposta { get; set; }

        [Display(Name = "Numero de Aluno")]
        public int NumeroAluno { get; set; }

        
        [Display(Name = "Numero de Cadeiras Concluidas")]
        public int NumeroCadeirasConcluidas { get; set; }
        
        [Display(Name = "Media do Curso")]
        public double Media { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Aluno()
        {

        }
    }
}