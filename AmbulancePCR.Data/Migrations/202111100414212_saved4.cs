namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saved4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QAIssue", "SupervisorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QAIssue", "SupervisorName");
        }
    }
}
