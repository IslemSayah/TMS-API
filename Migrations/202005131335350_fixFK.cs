namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "LastRespondentId", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Tickets", "EditorStaffId", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Tickets", "IsCreatedByStaff", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "CreatorStaffId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.InternalNotes", "TicketId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.InternalNotes", "AuthorId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Licenses", "UserID", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tickets", "UserId", c => c.String(maxLength: 255));
            CreateIndex("dbo.InternalNotes", "TicketId");
            CreateIndex("dbo.InternalNotes", "AuthorId");
            CreateIndex("dbo.Tickets", "UserId");
            CreateIndex("dbo.Tickets", "LicenseId");
            CreateIndex("dbo.Tickets", "AssignedStaffId");
            CreateIndex("dbo.Tickets", "LastRespondentId");
            CreateIndex("dbo.Tickets", "EditorStaffId");
            CreateIndex("dbo.Tickets", "HelpTopicId");
            CreateIndex("dbo.Tickets", "CreatorStaffId");
            CreateIndex("dbo.Licenses", "UserID");
            CreateIndex("dbo.StaffLogs", "StaffMemberId");
            AddForeignKey("dbo.InternalNotes", "AuthorId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Licenses", "UserID", "dbo.Users", "Id");
            AddForeignKey("dbo.Tickets", "LicenseId", "dbo.Licenses", "Id");
            AddForeignKey("dbo.Tickets", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: false);
            AddForeignKey("dbo.StaffLogs", "StaffMemberId", "dbo.StaffMembers", "Id", cascadeDelete: false);
            DropColumn("dbo.Tickets", "LastRespondentTD");
            DropColumn("dbo.Tickets", "EditedByStaffId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "EditedByStaffId", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Tickets", "LastRespondentTD", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.StaffLogs", "StaffMemberId", "dbo.StaffMembers");
            DropForeignKey("dbo.InternalNotes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "LicenseId", "dbo.Licenses");
            DropForeignKey("dbo.Licenses", "UserID", "dbo.Users");
            DropForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics");
            DropForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.InternalNotes", "AuthorId", "dbo.StaffMembers");
            DropIndex("dbo.StaffLogs", new[] { "StaffMemberId" });
            DropIndex("dbo.Licenses", new[] { "UserID" });
            DropIndex("dbo.Tickets", new[] { "CreatorStaffId" });
            DropIndex("dbo.Tickets", new[] { "HelpTopicId" });
            DropIndex("dbo.Tickets", new[] { "EditorStaffId" });
            DropIndex("dbo.Tickets", new[] { "LastRespondentId" });
            DropIndex("dbo.Tickets", new[] { "AssignedStaffId" });
            DropIndex("dbo.Tickets", new[] { "LicenseId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.InternalNotes", new[] { "AuthorId" });
            DropIndex("dbo.InternalNotes", new[] { "TicketId" });
            AlterColumn("dbo.Tickets", "UserId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Licenses", "UserID", c => c.String());
            AlterColumn("dbo.InternalNotes", "AuthorId", c => c.String(nullable: false));
            AlterColumn("dbo.InternalNotes", "TicketId", c => c.String(nullable: false));
            DropColumn("dbo.Tickets", "CreatorStaffId");
            DropColumn("dbo.Tickets", "IsCreatedByStaff");
            DropColumn("dbo.Tickets", "EditorStaffId");
            DropColumn("dbo.Tickets", "LastRespondentId");
        }
    }
}
