namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supprDuree : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Evenements", "Duree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Duree", c => c.Int(nullable: false));
        }
    }
}
