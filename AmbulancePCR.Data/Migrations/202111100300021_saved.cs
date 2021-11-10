namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incident", "IncidentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Incident", "UnitNotified", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "EnRoute", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "OnScene", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "Transporting", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "Destination", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "InService", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Vitals", "VitalSignsTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vitals", "VitalSignsTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "InService", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "Destination", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "Transporting", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "OnScene", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "EnRoute", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "UnitNotified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Incident", "IncidentDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
