namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staffmember : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StaffMembers", "Status", c => c.Int());
            AlterColumn("dbo.StaffMembers", "IsAdministrator", c => c.Boolean());
            AlterColumn("dbo.StaffMembers", "IsOnVacation", c => c.Boolean());
            AlterColumn("dbo.StaffMembers", "IsLoggedIn", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StaffMembers", "IsLoggedIn", c => c.Boolean(nullable: false));
            AlterColumn("dbo.StaffMembers", "IsOnVacation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.StaffMembers", "IsAdministrator", c => c.Boolean(nullable: false));
            AlterColumn("dbo.StaffMembers", "Status", c => c.Int(nullable: false));
        }
    }
}
