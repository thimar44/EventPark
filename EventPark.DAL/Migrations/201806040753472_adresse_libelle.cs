namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adresse_libelle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adresses", "Libelle", c => c.String());
            AddColumn("dbo.Adresses", "UrlGoogle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adresses", "UrlGoogle");
            DropColumn("dbo.Adresses", "Libelle");
        }
    }
}
