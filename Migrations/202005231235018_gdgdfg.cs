namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gdgdfg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets");
            DropIndex("dbo.InternalNotes", new[] { "TicketId" });
            DropIndex("dbo.TicketEventsHistories", new[] { "TicketId" });
            DropIndex("dbo.TicketThreadMessages", new[] { "TicketId" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.InternalNotes", "TicketId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tickets", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TicketEventsHistories", "TicketId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TicketThreadMessages", "TicketId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tickets", "Id");
            CreateIndex("dbo.InternalNotes", "TicketId");
            CreateIndex("dbo.TicketEventsHistories", "TicketId");
            CreateIndex("dbo.TicketThreadMessages", "TicketId");
            AddForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketThreadMessages", new[] { "TicketId" });
            DropIndex("dbo.TicketEventsHistories", new[] { "TicketId" });
            DropIndex("dbo.InternalNotes", new[] { "TicketId" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.TicketThreadMessages", "TicketId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TicketEventsHistories", "TicketId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tickets", "Id", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.InternalNotes", "TicketId", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Tickets", "Id");
            CreateIndex("dbo.TicketThreadMessages", "TicketId");
            CreateIndex("dbo.TicketEventsHistories", "TicketId");
            CreateIndex("dbo.InternalNotes", "TicketId");
            AddForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
