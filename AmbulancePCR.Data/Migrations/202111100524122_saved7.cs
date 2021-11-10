namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saved7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.Incident");
            DropIndex("dbo.QAIssue", new[] { "IncidentNumber" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.QAIssue", "IncidentNumber");
            AddForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.Incident", "PatientCareReportId", cascadeDelete: true);
        }
    }
}
