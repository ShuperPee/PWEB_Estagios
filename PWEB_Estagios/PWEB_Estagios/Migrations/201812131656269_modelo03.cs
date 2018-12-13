namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alunos", "Proposta_PropostaId", c => c.Int());
            CreateIndex("dbo.Alunos", "Proposta_PropostaId");
            AddForeignKey("dbo.Alunos", "Proposta_PropostaId", "dbo.Propostas", "PropostaId");
            DropColumn("dbo.Alunos", "PropostaId");
            DropColumn("dbo.Propostas", "AlunoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Propostas", "AlunoId", c => c.Int(nullable: false));
            AddColumn("dbo.Alunos", "PropostaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Alunos", "Proposta_PropostaId", "dbo.Propostas");
            DropIndex("dbo.Alunos", new[] { "Proposta_PropostaId" });
            DropColumn("dbo.Alunos", "Proposta_PropostaId");
        }
    }
}
