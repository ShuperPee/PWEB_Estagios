namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alunos", "NumeroAluno", c => c.Int(nullable: false));
            AddColumn("dbo.Docentes", "NumeroDocente", c => c.Int(nullable: false));
            AddColumn("dbo.Empresas", "EmpresaNIF", c => c.Int(nullable: false));
            AlterColumn("dbo.Alunos", "Apelido", c => c.String(maxLength: 100));
            AlterColumn("dbo.Alunos", "Ramo", c => c.Int());
            AlterColumn("dbo.Docentes", "Apelido", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresas", "Sede", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "Sede", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Docentes", "Apelido", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Alunos", "Ramo", c => c.Int(nullable: false));
            AlterColumn("dbo.Alunos", "Apelido", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Empresas", "EmpresaNIF");
            DropColumn("dbo.Docentes", "NumeroDocente");
            DropColumn("dbo.Alunos", "NumeroAluno");
        }
    }
}
