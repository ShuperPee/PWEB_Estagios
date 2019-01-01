using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    public enum TipoProposta
    {
        Estagio = 1,
        Projeto
    }
    [Table("Propostas")]
    public class Proposta
    {
        //[Required]
        //[Key]
        public int PropostaId { get; set; }

        [Required]
        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public String NomeEmpresa { get; set; }
       
        public IList<Aluno> Alunos { get; set; }

        [Required]
        [ForeignKey("Docente")]
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }

        public String NomeDocente { get; set; }

        public IList<Docente> DocentesAuxiliares { get; set; }

        public Boolean Aprovado { get; set; } = false;

        public Boolean Ativo { get; set; } = true;

        // [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

       // [Required]
        public TipoProposta Tipo { get; set; }

        //[Required]
        [MaxLength(100)]
        public string Local { get; set; }

        //[Required]
        public Ramo? Ramos { get; set; }

       // [Required]
        [Range(0,20)]
        public double MediaMin { get; set; }
    
        //[Required]
        [Range(0,30)]
        public int NumeroCadeirasMinimas { get; set; }

        //[Required]
        //[DisplayFormat (DataFormatString = "(yyyy)",ApplyFormatInEditMode = true)]
        public DateTime AnoLetivo { get; set; }

        //[Required]
        [Display(Name = "Seleciona Docente Responsável")]
        public string DocentesSelect { get; set; }
        //[Required]
        [Display(Name = "Seleciona Empresa")]
        public string EmpresasSelect { get; set; }
    }
    
}