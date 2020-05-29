namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Source", c => c.Int());
            AlterColumn("dbo.Tickets", "CreationDateTime", c => c.DateTime());
            AlterColumn("dbo.Tickets", "DueDate", c => c.DateTime());
            AlterColumn("dbo.Tickets", "LastResponse", c => c.DateTime());
            AlterColumn("dbo.Tickets", "LastMessage", c => c.DateTime());
            AlterColumn("dbo.Tickets", "Number", c => c.Int());
            AlterColumn("dbo.Tickets", "IsOverdue", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "IsOverdue", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tickets", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "LastMessage", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "LastResponse", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "CreationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "Source", c => c.Int(nullable: false));
        }
    }
}
