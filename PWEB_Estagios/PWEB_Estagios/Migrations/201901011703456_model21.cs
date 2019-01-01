namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidaturas", "AlunoNome", c => c.String());
            AddColumn("dbo.Propostas", "NomeEmpresa", c => c.String());
            AddColumn("dbo.Propostas", "NomeDocente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Propostas", "NomeDocente");
            DropColumn("dbo.Propostas", "NomeEmpresa");
            DropColumn("dbo.Candidaturas", "AlunoNome");
        }
    }
}
