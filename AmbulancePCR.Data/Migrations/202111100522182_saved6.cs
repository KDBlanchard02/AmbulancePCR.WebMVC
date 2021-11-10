namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saved6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QAIssue", "PrimaryCareProvider", c => c.String());
            AlterColumn("dbo.QAIssue", "PtLastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QAIssue", "PtLastName", c => c.String(nullable: false));
            AlterColumn("dbo.QAIssue", "PrimaryCareProvider", c => c.String(nullable: false));
        }
    }
}
