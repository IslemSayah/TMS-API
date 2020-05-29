namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullbalefortest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "TicketStatus", c => c.Int());
            AlterColumn("dbo.Tickets", "IsCreatedByStaff", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "IsCreatedByStaff", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tickets", "TicketStatus", c => c.Int(nullable: false));
        }
    }
}
