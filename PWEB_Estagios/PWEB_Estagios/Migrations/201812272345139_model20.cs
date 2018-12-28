namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagens", "DocentesSelect", c => c.String());
            AddColumn("dbo.Mensagens", "AlunosSelect", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mensagens", "AlunosSelect");
            DropColumn("dbo.Mensagens", "DocentesSelect");
        }
    }
}
