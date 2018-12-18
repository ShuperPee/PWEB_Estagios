using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWEB_Estagios.Models
{
    public class Empresa
    {

        //[Required]
        //[Key]
        [Display(Name = "ID BD")]
        public int EmpresaId { get; set; }

        [Required]
        [MaxLength(100)]
        //[Display(Name = "Nome")]
        public string Nome { get; set; }
   
        //[Required]
        [MaxLength(100)]
        public string Sede { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public IList<Proposta> Propostas { get; set; }

        [Display(Name = "NIF")]
        public int EmpresaNIF { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Empresa()
        {

        }
    }
}