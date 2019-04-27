namespace InAndOutControl.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullForExitTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogBooks", "ExitTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogBooks", "ExitTime", c => c.DateTime(nullable: false));
        }
    }
}
