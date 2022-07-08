namespace WebAPI_RestPremiereApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abonnes", "Prenom", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Abonnes", "Mail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abonnes", "Mail", c => c.String());
            AlterColumn("dbo.Abonnes", "Prenom", c => c.String());
        }
    }
}
