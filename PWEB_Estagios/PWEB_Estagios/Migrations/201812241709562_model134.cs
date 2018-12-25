namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model134 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Propostas", "DocentesSelect", c => c.String());
            AlterColumn("dbo.Propostas", "EmpresasSelect", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Propostas", "EmpresasSelect", c => c.String(nullable: false));
            AlterColumn("dbo.Propostas", "DocentesSelect", c => c.String(nullable: false));
        }
    }
}
