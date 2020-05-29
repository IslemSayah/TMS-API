namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics");
            DropForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers");
            DropIndex("dbo.Tickets", new[] { "AssignedStaffId" });
            DropIndex("dbo.Tickets", new[] { "LastRespondentId" });
            DropIndex("dbo.Tickets", new[] { "EditorStaffId" });
            DropIndex("dbo.Tickets", new[] { "HelpTopicId" });
            DropIndex("dbo.Tickets", new[] { "CreatorStaffId" });
            AlterColumn("dbo.Tickets", "Subject", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tickets", "Message", c => c.String());
            AlterColumn("dbo.Tickets", "AssignedStaffId", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tickets", "LastRespondentId", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tickets", "EditorStaffId", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tickets", "HelpTopicId", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tickets", "CreatorStaffId", c => c.String(maxLength: 255));
            CreateIndex("dbo.Tickets", "AssignedStaffId");
            CreateIndex("dbo.Tickets", "LastRespondentId");
            CreateIndex("dbo.Tickets", "EditorStaffId");
            CreateIndex("dbo.Tickets", "HelpTopicId");
            CreateIndex("dbo.Tickets", "CreatorStaffId");
            AddForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics", "Id");
            AddForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics");
            DropForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers");
            DropIndex("dbo.Tickets", new[] { "CreatorStaffId" });
            DropIndex("dbo.Tickets", new[] { "HelpTopicId" });
            DropIndex("dbo.Tickets", new[] { "EditorStaffId" });
            DropIndex("dbo.Tickets", new[] { "LastRespondentId" });
            DropIndex("dbo.Tickets", new[] { "AssignedStaffId" });
            AlterColumn("dbo.Tickets", "CreatorStaffId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tickets", "HelpTopicId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tickets", "EditorStaffId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tickets", "LastRespondentId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tickets", "AssignedStaffId", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tickets", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Subject", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Tickets", "CreatorStaffId");
            CreateIndex("dbo.Tickets", "HelpTopicId");
            CreateIndex("dbo.Tickets", "EditorStaffId");
            CreateIndex("dbo.Tickets", "LastRespondentId");
            CreateIndex("dbo.Tickets", "AssignedStaffId");
            AddForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers", "Id", cascadeDelete: true);
        }
    }
}
