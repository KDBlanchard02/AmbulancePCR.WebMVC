namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savedchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.PatientInformation");
            DropForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.QAIssue", "PatientInformation_PatientID", "dbo.PatientInformation");
            DropPrimaryKey("dbo.PatientInformation");
            AddColumn("dbo.QAIssue", "PatientInformation_PatientID", c => c.Int());
            AddColumn("dbo.PatientInformation", "PatientID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PatientInformation", "PatientID");
            CreateIndex("dbo.QAIssue", "PatientInformation_PatientID");
            AddForeignKey("dbo.QAIssue", "PatientInformation_PatientID", "dbo.PatientInformation", "PatientID");
            AddForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident", "IncidentNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.QAIssue", "PatientInformation_PatientID", "dbo.PatientInformation");
            DropIndex("dbo.QAIssue", new[] { "PatientInformation_PatientID" });
            DropPrimaryKey("dbo.PatientInformation");
            DropColumn("dbo.PatientInformation", "PatientID");
            DropColumn("dbo.QAIssue", "PatientInformation_PatientID");
            AddPrimaryKey("dbo.PatientInformation", "IncidentNumber");
            AddForeignKey("dbo.QAIssue", "PatientInformation_PatientID", "dbo.PatientInformation", "PatientID");
            AddForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident", "IncidentNumber");
            AddForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.PatientInformation", "IncidentNumber", cascadeDelete: true);
        }
    }
}
