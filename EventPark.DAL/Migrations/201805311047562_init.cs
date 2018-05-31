namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        rue = c.String(),
                        codePostal = c.String(),
                        ville = c.String(),
                        coordX = c.Single(nullable: false),
                        coordY = c.Single(nullable: false),
                        epsg = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        theme = c.String(),
                        date = c.DateTime(nullable: false),
                        horaire = c.String(),
                        duree = c.Int(nullable: false),
                        description = c.String(),
                        tarif = c.Single(nullable: false),
                        adresse_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Adresses", t => t.adresse_id)
                .Index(t => t.adresse_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "adresse_id", "dbo.Adresses");
            DropIndex("dbo.Evenements", new[] { "adresse_id" });
            DropTable("dbo.Evenements");
            DropTable("dbo.Adresses");
        }
    }
}
