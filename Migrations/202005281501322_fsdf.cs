namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fsdf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "FilePaths");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "FilePaths", c => c.String());
        }
    }
}
