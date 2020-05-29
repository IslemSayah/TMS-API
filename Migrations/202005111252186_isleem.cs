namespace TMS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isleem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        LicenseId = c.String(),
                        TicketStatus = c.Int(nullable: false),
                        Subject = c.String(),
                        Message = c.String(),
                        Source = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        LastResponse = c.DateTime(nullable: false),
                        LastMessage = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        IsOverdue = c.Boolean(nullable: false),
                        AssignedStaffID = c.String(),
                        LastRespondentTD = c.String(),
                        EditedByStaffId = c.String(),
                        helpTopicId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
