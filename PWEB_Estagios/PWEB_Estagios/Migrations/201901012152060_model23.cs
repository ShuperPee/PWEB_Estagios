namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidaturas", "NotaProposta", c => c.Int(nullable: false));
            DropColumn("dbo.Propostas", "NotaProposta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Propostas", "NotaProposta", c => c.Int(nullable: false));
            DropColumn("dbo.Candidaturas", "NotaProposta");
        }
    }
}
