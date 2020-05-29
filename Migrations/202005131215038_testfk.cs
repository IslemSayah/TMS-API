namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testfk : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Departments", "ManagerId");
            AddForeignKey("dbo.Departments", "ManagerId", "dbo.StaffMembers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "ManagerId", "dbo.StaffMembers");
            DropIndex("dbo.Departments", new[] { "ManagerId" });
        }
    }
}
