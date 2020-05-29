namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCompleteModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketEventsHistories", "DoerId", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TicketThreadMessages", "StaffAuthorId", c => c.String(maxLength: 255));
            AddColumn("dbo.TicketThreadMessages", "UserAuthorId", c => c.String(maxLength: 255));
            CreateIndex("dbo.TicketEventsHistories", "TicketId");
            CreateIndex("dbo.TicketEventsHistories", "DoerId");
            CreateIndex("dbo.TicketThreadMessages", "TicketId");
            CreateIndex("dbo.TicketThreadMessages", "StaffAuthorId");
            CreateIndex("dbo.TicketThreadMessages", "UserAuthorId");
            AddForeignKey("dbo.TicketEventsHistories", "DoerId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TicketThreadMessages", "StaffAuthorId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TicketThreadMessages", "UserAuthorId", "dbo.Users", "Id");
            DropColumn("dbo.TicketEventsHistories", "DoerById");
            DropColumn("dbo.TicketThreadMessages", "AuthorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketThreadMessages", "AuthorID", c => c.String(nullable: false));
            AddColumn("dbo.TicketEventsHistories", "DoerById", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.TicketThreadMessages", "UserAuthorId", "dbo.Users");
            DropForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketThreadMessages", "StaffAuthorId", "dbo.StaffMembers");
            DropForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketEventsHistories", "DoerId", "dbo.StaffMembers");
            DropIndex("dbo.TicketThreadMessages", new[] { "UserAuthorId" });
            DropIndex("dbo.TicketThreadMessages", new[] { "StaffAuthorId" });
            DropIndex("dbo.TicketThreadMessages", new[] { "TicketId" });
            DropIndex("dbo.TicketEventsHistories", new[] { "DoerId" });
            DropIndex("dbo.TicketEventsHistories", new[] { "TicketId" });
            DropColumn("dbo.TicketThreadMessages", "UserAuthorId");
            DropColumn("dbo.TicketThreadMessages", "StaffAuthorId");
            DropColumn("dbo.TicketEventsHistories", "DoerId");
        }
    }
}
