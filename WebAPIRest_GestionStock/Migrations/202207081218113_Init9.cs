namespace WebAPIRest_GestionStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Categorie_Id" });
            AddColumn("dbo.Articles", "Category_Id", c => c.Int());
            AlterColumn("dbo.Articles", "info", c => c.String(maxLength: 10));
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            AlterColumn("dbo.Articles", "info", c => c.String(maxLength: 10, unicode: false));
            DropColumn("dbo.Articles", "Category_Id");
            CreateIndex("dbo.Articles", "Categorie_Id");
            AddForeignKey("dbo.Articles", "Categorie_Id", "dbo.Categories", "Id");
        }
    }
}
