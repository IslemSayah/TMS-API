namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class islem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StaffMembers", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.StaffMembers", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.StaffMembers", "UserName", c => c.String(maxLength: 255));
            AlterColumn("dbo.StaffMembers", "EmailAdress", c => c.String());
            AlterColumn("dbo.StaffMembers", "OfficePhone", c => c.String());
            AlterColumn("dbo.StaffMembers", "MobilePhone", c => c.String());
            AlterColumn("dbo.StaffMembers", "Password", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StaffMembers", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.StaffMembers", "MobilePhone", c => c.String(nullable: false));
            AlterColumn("dbo.StaffMembers", "OfficePhone", c => c.String(nullable: false));
            AlterColumn("dbo.StaffMembers", "EmailAdress", c => c.String(nullable: false));
            AlterColumn("dbo.StaffMembers", "UserName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.StaffMembers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.StaffMembers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
