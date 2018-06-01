namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajout_image : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Url = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        Evenement_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Evenements", t => t.Evenement_id)
                .Index(t => t.Evenement_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Evenement_id", "dbo.Evenements");
            DropIndex("dbo.Images", new[] { "Evenement_id" });
            DropTable("dbo.Images");
        }
    }
}
