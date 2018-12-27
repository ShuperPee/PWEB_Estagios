namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Docentes", "Mensagem_MensagemID", "dbo.Mensagens");
            DropIndex("dbo.Docentes", new[] { "Mensagem_MensagemID" });
            AddColumn("dbo.Mensagens", "DocentId", c => c.Int(nullable: false));
            AddColumn("dbo.Mensagens", "Docente_DocenteId", c => c.Int());
            CreateIndex("dbo.Mensagens", "Docente_DocenteId");
            AddForeignKey("dbo.Mensagens", "Docente_DocenteId", "dbo.Docentes", "DocenteId");
            DropColumn("dbo.Docentes", "Mensagem_MensagemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Docentes", "Mensagem_MensagemID", c => c.Int());
            DropForeignKey("dbo.Mensagens", "Docente_DocenteId", "dbo.Docentes");
            DropIndex("dbo.Mensagens", new[] { "Docente_DocenteId" });
            DropColumn("dbo.Mensagens", "Docente_DocenteId");
            DropColumn("dbo.Mensagens", "DocentId");
            CreateIndex("dbo.Docentes", "Mensagem_MensagemID");
            AddForeignKey("dbo.Docentes", "Mensagem_MensagemID", "dbo.Mensagens", "MensagemID");
        }
    }
}
