namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        PrimeiroNome = c.String(),
                        Apelido = c.String(),
                        Email = c.String(),
                        Ramo = c.Int(),
                        PropostaId = c.Int(nullable: false),
                        NumeroCadeirasConcluidas = c.Int(nullable: false),
                        Media = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoId);
            
            CreateTable(
                "dbo.CandidaturaPropostas",
                c => new
                    {
                        CandidaturaPropostaId = c.Int(nullable: false, identity: true),
                        PropostaId = c.Int(nullable: false),
                        AlunoId = c.Int(nullable: false),
                        Aprovado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidaturaPropostaId)
                .ForeignKey("dbo.Alunoes", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Propostas", t => t.PropostaId, cascadeDelete: true)
                .Index(t => t.PropostaId)
                .Index(t => t.AlunoId);
            
            CreateTable(
                "dbo.Propostas",
                c => new
                    {
                        PropostaId = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        AlunoId = c.Int(nullable: false),
                        DocenteId = c.Int(nullable: false),
                        Aprovado = c.Boolean(nullable: false),
                        Descricao = c.String(),
                        Tipo = c.Int(nullable: false),
                        Local = c.String(),
                        Ramos = c.Int(),
                        MediaMin = c.Double(nullable: false),
                        NumeroCadeirasMinimas = c.Int(nullable: false),
                        AnoLetivo = c.DateTime(nullable: false),
                        Docente_DocenteId = c.Int(),
                    })
                .PrimaryKey(t => t.PropostaId)
                .ForeignKey("dbo.Docentes", t => t.Docente_DocenteId)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId)
                .Index(t => t.Docente_DocenteId);
            
            CreateTable(
                "dbo.Docentes",
                c => new
                    {
                        DocenteId = c.Int(nullable: false, identity: true),
                        PrimeiroNome = c.String(),
                        Apelido = c.String(),
                        Email = c.String(),
                        Comisao = c.Boolean(nullable: false),
                        NumeroMaxCandidaturas = c.Int(nullable: false),
                        Proposta_PropostaId = c.Int(),
                        Mensagem_MensagemID = c.Int(),
                    })
                .PrimaryKey(t => t.DocenteId)
                .ForeignKey("dbo.Propostas", t => t.Proposta_PropostaId)
                .ForeignKey("dbo.Mensagems", t => t.Mensagem_MensagemID)
                .Index(t => t.Proposta_PropostaId)
                .Index(t => t.Mensagem_MensagemID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sede = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Mensagems",
                c => new
                    {
                        MensagemID = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        Texto = c.String(),
                    })
                .PrimaryKey(t => t.MensagemID)
                .ForeignKey("dbo.Alunoes", t => t.AlunoId, cascadeDelete: true)
                .Index(t => t.AlunoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Docentes", "Mensagem_MensagemID", "dbo.Mensagems");
            DropForeignKey("dbo.Mensagems", "AlunoId", "dbo.Alunoes");
            DropForeignKey("dbo.CandidaturaPropostas", "PropostaId", "dbo.Propostas");
            DropForeignKey("dbo.Propostas", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Docentes", "Proposta_PropostaId", "dbo.Propostas");
            DropForeignKey("dbo.Propostas", "Docente_DocenteId", "dbo.Docentes");
            DropForeignKey("dbo.CandidaturaPropostas", "AlunoId", "dbo.Alunoes");
            DropIndex("dbo.Mensagems", new[] { "AlunoId" });
            DropIndex("dbo.Docentes", new[] { "Mensagem_MensagemID" });
            DropIndex("dbo.Docentes", new[] { "Proposta_PropostaId" });
            DropIndex("dbo.Propostas", new[] { "Docente_DocenteId" });
            DropIndex("dbo.Propostas", new[] { "EmpresaId" });
            DropIndex("dbo.CandidaturaPropostas", new[] { "AlunoId" });
            DropIndex("dbo.CandidaturaPropostas", new[] { "PropostaId" });
            DropTable("dbo.Mensagems");
            DropTable("dbo.Empresas");
            DropTable("dbo.Docentes");
            DropTable("dbo.Propostas");
            DropTable("dbo.CandidaturaPropostas");
            DropTable("dbo.Alunoes");
        }
    }
}
