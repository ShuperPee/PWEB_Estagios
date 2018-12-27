namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidaturas", "PropostasSelect");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidaturas", "PropostasSelect", c => c.String());
        }
    }
}
