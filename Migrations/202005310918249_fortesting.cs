namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fortesting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "CreatedById", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "ModifiedById", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "PasswordHash", c => c.String());
            AlterColumn("dbo.Users", "EmailAdress", c => c.String());
            AlterColumn("dbo.Users", "Status", c => c.Int());
            AlterColumn("dbo.Users", "IsValid", c => c.Boolean());
            DropColumn("dbo.Users", "SupervisorId");
            DropColumn("dbo.Users", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CustomerId", c => c.Guid());
            AddColumn("dbo.Users", "SupervisorId", c => c.Guid());
            AlterColumn("dbo.Users", "IsValid", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "EmailAdress", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ModifiedById", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "CreatedById", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
