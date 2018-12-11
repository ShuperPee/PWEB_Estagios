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
        [Required]
        [Key]
        public int MensagemID { get; set; }

        [Required]
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }

        [Required]
        public Aluno Aluno { get; set; }

        [Required]
        public IList<Docente> Docentes { get; set; }

        [Required]
        public string Texto { get; set; }
    }
}