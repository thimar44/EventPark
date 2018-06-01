namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Evenements", new[] { "adresse_id" });
            CreateIndex("dbo.Evenements", "Adresse_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Evenements", new[] { "Adresse_id" });
            CreateIndex("dbo.Evenements", "adresse_id");
        }
    }
}
