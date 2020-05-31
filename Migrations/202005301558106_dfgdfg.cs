namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfgdfg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            AlterColumn("dbo.Tickets", "UserId", c => c.Guid());
            CreateIndex("dbo.Tickets", "UserId");
            AddForeignKey("dbo.Tickets", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            AlterColumn("dbo.Tickets", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tickets", "UserId");
            AddForeignKey("dbo.Tickets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
