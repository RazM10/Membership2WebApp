namespace Membership2WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7AddAddDateInMovieClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AddDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AddDate");
        }
    }
}
