namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model04 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Propostas", "Docente_DocenteId", "dbo.Docentes");
            DropIndex("dbo.Propostas", new[] { "Docente_DocenteId" });
            DropColumn("dbo.Propostas", "DocenteId");
            RenameColumn(table: "dbo.Propostas", name: "Docente_DocenteId", newName: "DocenteId");
            AlterColumn("dbo.Propostas", "Descricao", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Propostas", "Local", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Propostas", "Ramos", c => c.Int(nullable: false));
            AlterColumn("dbo.Propostas", "DocenteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Propostas", "DocenteId");
            AddForeignKey("dbo.Propostas", "DocenteId", "dbo.Docentes", "DocenteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Propostas", "DocenteId", "dbo.Docentes");
            DropIndex("dbo.Propostas", new[] { "DocenteId" });
            AlterColumn("dbo.Propostas", "DocenteId", c => c.Int());
            AlterColumn("dbo.Propostas", "Ramos", c => c.Int());
            AlterColumn("dbo.Propostas", "Local", c => c.String());
            AlterColumn("dbo.Propostas", "Descricao", c => c.String());
            RenameColumn(table: "dbo.Propostas", name: "DocenteId", newName: "Docente_DocenteId");
            AddColumn("dbo.Propostas", "DocenteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Propostas", "Docente_DocenteId");
            AddForeignKey("dbo.Propostas", "Docente_DocenteId", "dbo.Docentes", "DocenteId");
        }
    }
}
