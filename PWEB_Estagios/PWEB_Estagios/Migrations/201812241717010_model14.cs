namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Propostas", "Descricao", c => c.String(maxLength: 500));
            AlterColumn("dbo.Propostas", "Local", c => c.String(maxLength: 100));
            AlterColumn("dbo.Propostas", "Ramos", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Propostas", "Ramos", c => c.Int(nullable: false));
            AlterColumn("dbo.Propostas", "Local", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Propostas", "Descricao", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
