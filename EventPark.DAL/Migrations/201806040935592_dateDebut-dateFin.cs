namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateDebutdateFin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "DateDebut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Evenements", "DateFin", c => c.DateTime(nullable: false));
            DropColumn("dbo.Evenements", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Evenements", "DateFin");
            DropColumn("dbo.Evenements", "DateDebut");
        }
    }
}
