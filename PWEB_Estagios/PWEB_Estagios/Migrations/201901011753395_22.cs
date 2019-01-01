namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Propostas", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Propostas", "NotaProposta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Propostas", "NotaProposta");
            DropColumn("dbo.Propostas", "Ativo");
        }
    }
}
