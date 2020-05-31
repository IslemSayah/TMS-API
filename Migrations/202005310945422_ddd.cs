namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics");
            DropForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers");
            DropForeignKey("dbo.Tickets", "LicenseId", "dbo.Licenses");
            DropIndex("dbo.Tickets", new[] { "LicenseId" });
            DropIndex("dbo.Tickets", new[] { "AssignedStaffId" });
            DropIndex("dbo.Tickets", new[] { "LastRespondentId" });
            DropIndex("dbo.Tickets", new[] { "EditorStaffId" });
            DropIndex("dbo.Tickets", new[] { "HelpTopicId" });
            DropIndex("dbo.Tickets", new[] { "CreatorStaffId" });
            DropColumn("dbo.Tickets", "LicenseId");
            DropColumn("dbo.Tickets", "AssignedStaffId");
            DropColumn("dbo.Tickets", "LastRespondentId");
            DropColumn("dbo.Tickets", "EditorStaffId");
            DropColumn("dbo.Tickets", "HelpTopicId");
            DropColumn("dbo.Tickets", "IsCreatedByStaff");
            DropColumn("dbo.Tickets", "CreatorStaffId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "CreatorStaffId", c => c.Guid());
            AddColumn("dbo.Tickets", "IsCreatedByStaff", c => c.Boolean());
            AddColumn("dbo.Tickets", "HelpTopicId", c => c.Guid());
            AddColumn("dbo.Tickets", "EditorStaffId", c => c.Guid());
            AddColumn("dbo.Tickets", "LastRespondentId", c => c.Guid());
            AddColumn("dbo.Tickets", "AssignedStaffId", c => c.Guid());
            AddColumn("dbo.Tickets", "LicenseId", c => c.Guid());
            CreateIndex("dbo.Tickets", "CreatorStaffId");
            CreateIndex("dbo.Tickets", "HelpTopicId");
            CreateIndex("dbo.Tickets", "EditorStaffId");
            CreateIndex("dbo.Tickets", "LastRespondentId");
            CreateIndex("dbo.Tickets", "AssignedStaffId");
            CreateIndex("dbo.Tickets", "LicenseId");
            AddForeignKey("dbo.Tickets", "LicenseId", "dbo.Licenses", "Id");
            AddForeignKey("dbo.Tickets", "LastRespondentId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.Tickets", "HelpTopicId", "dbo.HelpTopics", "Id");
            AddForeignKey("dbo.Tickets", "EditorStaffId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.Tickets", "CreatorStaffId", "dbo.StaffMembers", "Id");
            AddForeignKey("dbo.Tickets", "AssignedStaffId", "dbo.StaffMembers", "Id");
        }
    }
}
