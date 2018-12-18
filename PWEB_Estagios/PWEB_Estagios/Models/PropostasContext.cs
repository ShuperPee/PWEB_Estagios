using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace PWEB_Estagios.Models
{
    public class PropostasContext : ApplicationDbContext
    {
        public PropostasContext() //: base("name=DefaultConnection")
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Proposta> Propostas { get; set; }
        public DbSet<CandidaturaProposta> Candidaturas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }

    }
}