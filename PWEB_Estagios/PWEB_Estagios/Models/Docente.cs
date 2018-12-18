using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    public class Docente
    {
        //[Required]
        //[Key]
        [Display(Name = "ID BD")]
        public int DocenteId { get; set; }

        [Required]
        [MaxLength(100)]
        //[Display(Name = "Primeiro Nome")]
        public string PrimeiroNome { get; set; }

        //[Required]
        [MaxLength(100)]
        [Display(Name = "Ultimo Nome")]
        public string Apelido { get; set; }

        [Display(Name = "Numero de Docente")]
        public int NumeroDocente { get; set; }

        [Required]
        public string Email { get; set; }

        public Boolean Comisao { get; set; } = false;
        
        public int NumeroMaxCandidaturas { get; set; } = 0;

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Docente()
        {

        }
    }
}