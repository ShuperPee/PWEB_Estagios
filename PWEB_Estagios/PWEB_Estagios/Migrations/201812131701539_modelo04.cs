namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo04 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CandidaturaPropostas", newName: "Candidaturas");
            AlterColumn("dbo.Alunos", "PrimeiroNome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Alunos", "Apelido", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Alunos", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Alunos", "Ramo", c => c.Int(nullable: false));
            AlterColumn("dbo.Docentes", "PrimeiroNome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Docentes", "Apelido", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Docentes", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Empresas", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Empresas", "Sede", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Empresas", "Email", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "Email", c => c.String());
            AlterColumn("dbo.Empresas", "Sede", c => c.String());
            AlterColumn("dbo.Empresas", "Nome", c => c.String());
            AlterColumn("dbo.Docentes", "Email", c => c.String());
            AlterColumn("dbo.Docentes", "Apelido", c => c.String());
            AlterColumn("dbo.Docentes", "PrimeiroNome", c => c.String());
            AlterColumn("dbo.Alunos", "Ramo", c => c.Int());
            AlterColumn("dbo.Alunos", "Email", c => c.String());
            AlterColumn("dbo.Alunos", "Apelido", c => c.String());
            AlterColumn("dbo.Alunos", "PrimeiroNome", c => c.String());
            RenameTable(name: "dbo.Candidaturas", newName: "CandidaturaPropostas");
        }
    }
}
