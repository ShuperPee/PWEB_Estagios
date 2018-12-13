namespace PWEB_Estagios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo01 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alunoes", newName: "Alunos");
            RenameTable(name: "dbo.Mensagems", newName: "Mensagens");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Mensagens", newName: "Mensagems");
            RenameTable(name: "dbo.Alunos", newName: "Alunoes");
        }
    }
}
