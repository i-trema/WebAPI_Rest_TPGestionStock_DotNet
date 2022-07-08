namespace WebAPI_RestPremiereApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abonnes");
        }
    }
}
