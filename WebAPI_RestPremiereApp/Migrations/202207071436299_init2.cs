namespace WebAPI_RestPremiereApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Abonnes", "Activite_Id", c => c.Int());
            CreateIndex("dbo.Abonnes", "Activite_Id");
            AddForeignKey("dbo.Abonnes", "Activite_Id", "dbo.Activites", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abonnes", "Activite_Id", "dbo.Activites");
            DropIndex("dbo.Abonnes", new[] { "Activite_Id" });
            DropColumn("dbo.Abonnes", "Activite_Id");
            DropTable("dbo.Activites");
        }
    }
}
