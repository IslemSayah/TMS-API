namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "FilePaths", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "FilePaths");
        }
    }
}
