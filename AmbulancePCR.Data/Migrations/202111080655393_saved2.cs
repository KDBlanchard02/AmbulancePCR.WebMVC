namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saved2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.Vitals", "IncidentNumber", "dbo.Incident");
            DropIndex("dbo.PatientInformation", new[] { "IncidentNumber" });
            DropIndex("dbo.Vitals", new[] { "IncidentNumber" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Vitals", "IncidentNumber");
            CreateIndex("dbo.PatientInformation", "IncidentNumber");
            AddForeignKey("dbo.Vitals", "IncidentNumber", "dbo.Incident", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident", "Id", cascadeDelete: true);
        }
    }
}
