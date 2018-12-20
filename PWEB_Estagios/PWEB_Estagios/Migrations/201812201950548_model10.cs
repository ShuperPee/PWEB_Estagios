namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Propostas", "DocentesSelect", c => c.String(nullable: false));
            AddColumn("dbo.Propostas", "EmpresasSelect", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Propostas", "EmpresasSelect");
            DropColumn("dbo.Propostas", "DocentesSelect");
        }
    }
}
