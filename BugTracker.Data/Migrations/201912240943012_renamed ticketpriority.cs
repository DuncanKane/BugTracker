namespace BugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedticketpriority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketPriority", c => c.Byte(nullable: false));
            DropColumn("dbo.Tickets", "PriorityTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "PriorityTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Tickets", "TicketPriority");
        }
    }
}
