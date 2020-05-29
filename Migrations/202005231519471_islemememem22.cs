namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class islemememem22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets");
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tickets", "Id");
            AddForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets");
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tickets", "Id");
            AddForeignKey("dbo.TicketThreadMessages", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketEventsHistories", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
