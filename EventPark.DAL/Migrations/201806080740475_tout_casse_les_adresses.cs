namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tout_casse_les_adresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evenements", "Adresse_id", "dbo.Adresses");
            DropIndex("dbo.Evenements", new[] { "Adresse_id" });
            AddColumn("dbo.Evenements", "LibelleAdresse", c => c.String());
            AddColumn("dbo.Evenements", "Adresse", c => c.String());
            AddColumn("dbo.Evenements", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Evenements", "lng", c => c.Double(nullable: false));
            DropColumn("dbo.Evenements", "Adresse_id");
            DropTable("dbo.Adresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Libelle = c.String(),
                        Rue = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                        UrlGoogle = c.String(),
                        CoordX = c.Single(nullable: false),
                        CoordY = c.Single(nullable: false),
                        Epsg = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Evenements", "Adresse_id", c => c.Guid());
            DropColumn("dbo.Evenements", "lng");
            DropColumn("dbo.Evenements", "lat");
            DropColumn("dbo.Evenements", "Adresse");
            DropColumn("dbo.Evenements", "LibelleAdresse");
            CreateIndex("dbo.Evenements", "Adresse_id");
            AddForeignKey("dbo.Evenements", "Adresse_id", "dbo.Adresses", "id");
        }
    }
}
