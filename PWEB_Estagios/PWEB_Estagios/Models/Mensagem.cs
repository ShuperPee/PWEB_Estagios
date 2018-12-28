using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    [Table("Mensagens")]
    public class Mensagem
    {
        //[Required]
        //[Key]
        public int MensagemID { get; set; }

        //[Required]
        //[ForeignKey("Aluno")]
        public int AlunoId { get; set; }

        //[Required]
        public Aluno Aluno { get; set; }

        public int DocentId { get; set; }

        public Docente Docente { get; set; }

        //[Required]
        public string Texto { get; set; }

        //[Required]
        [Display(Name = "Seleciona Docente")]
        public string DocentesSelect { get; set; }
        //[Required]
        [Display(Name = "Selecione Aluno")]
        public string AlunosSelect { get; set; }
    }
}