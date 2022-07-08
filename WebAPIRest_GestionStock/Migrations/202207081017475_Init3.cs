namespace WebAPIRest_GestionStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        QteMini = c.Int(),
                        Prix = c.Double(),
                        Categorie_Id = c.Int(),
                        info = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .Index(t => t.Categorie_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Categorie_Id" });
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
