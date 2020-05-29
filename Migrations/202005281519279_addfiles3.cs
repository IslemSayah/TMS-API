namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfiles3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketFiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketFiles", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketFiles", new[] { "TicketId" });
            DropTable("dbo.TicketFiles");
        }
    }
}
