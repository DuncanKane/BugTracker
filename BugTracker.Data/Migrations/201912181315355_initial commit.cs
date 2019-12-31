namespace BugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Status = c.Byte(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RelatedTicketId = c.Guid(nullable: false),
                        AdditionalUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.RelatedTicketId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RelatedTicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        PriorityTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LogToTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Guid(nullable: false),
                        LogId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logs", t => t.LogId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogToTickets", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.LogToTickets", "LogId", "dbo.Logs");
            DropForeignKey("dbo.Logs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bugs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bugs", "RelatedTicketId", "dbo.Tickets");
            DropIndex("dbo.LogToTickets", new[] { "LogId" });
            DropIndex("dbo.LogToTickets", new[] { "TicketId" });
            DropIndex("dbo.Logs", new[] { "UserId" });
            DropIndex("dbo.Bugs", new[] { "RelatedTicketId" });
            DropIndex("dbo.Bugs", new[] { "UserId" });
            DropTable("dbo.LogToTickets");
            DropTable("dbo.Logs");
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Bugs");
        }
    }
}
