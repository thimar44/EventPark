namespace EventPark.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supprHoraire : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Evenements", "Horaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Horaire", c => c.String());
        }
    }
}
