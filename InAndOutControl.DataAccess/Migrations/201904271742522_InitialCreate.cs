namespace InAndOutControl.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogBooks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EntryTime = c.DateTime(nullable: false),
                        ExitTime = c.DateTime(nullable: true),
                        VisitorId = c.Guid(nullable: false),
                        VisitPurpose = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Visitors", t => t.VisitorId, cascadeDelete: true)
                .Index(t => t.VisitorId);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        PassportNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogBooks", "VisitorId", "dbo.Visitors");
            DropIndex("dbo.LogBooks", new[] { "VisitorId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.LogBooks");
        }
    }
}
