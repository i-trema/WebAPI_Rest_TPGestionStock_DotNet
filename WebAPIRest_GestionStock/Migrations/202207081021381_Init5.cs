namespace WebAPIRest_GestionStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Designation", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "QteMini", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "Prix", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Prix", c => c.Double());
            AlterColumn("dbo.Articles", "QteMini", c => c.Int());
            AlterColumn("dbo.Articles", "Designation", c => c.String());
        }
    }
}
