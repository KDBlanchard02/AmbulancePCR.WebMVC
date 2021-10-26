namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Incident", "AmbulanceDriver_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Incident", "PrimaryCareProvider_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Incident", "ReportingCrewMember_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.QAIssue", "PrimaryCareProvider_PSID", "dbo.ApplicationUser");
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.IdentityUserClaim", name: "ApplicationUser_Id", newName: "ApplicationUser_PSID");
            RenameColumn(table: "dbo.IdentityUserLogin", name: "ApplicationUser_Id", newName: "ApplicationUser_PSID");
            RenameColumn(table: "dbo.IdentityUserRole", name: "ApplicationUser_Id", newName: "ApplicationUser_PSID");
            DropPrimaryKey("dbo.ApplicationUser");
            CreateTable(
                "dbo.Incident",
                c => new
                    {
                        IncidentNumber = c.Int(nullable: false, identity: true),
                        AuthorID = c.Guid(nullable: false),
                        Disposition = c.String(nullable: false),
                        SceneAddress = c.String(nullable: false),
                        CmsLevel = c.String(nullable: false),
                        VehicleNumber = c.Int(nullable: false),
                        IncidentDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UnitNotified = c.DateTimeOffset(nullable: false, precision: 7),
                        EnRoute = c.DateTimeOffset(nullable: false, precision: 7),
                        OnScene = c.DateTimeOffset(nullable: false, precision: 7),
                        Transporting = c.DateTimeOffset(nullable: false, precision: 7),
                        Destination = c.DateTimeOffset(nullable: false, precision: 7),
                        InService = c.DateTimeOffset(nullable: false, precision: 7),
                        LoadMileage = c.Double(nullable: false),
                        DestinationAddress = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        PtPosition = c.String(nullable: false),
                        PrimarySymptom = c.String(nullable: false),
                        PrimaryImpression = c.String(nullable: false),
                        SecondaryImpression = c.String(nullable: false),
                        AlcDrugUse = c.String(nullable: false),
                        PCRNarrative = c.String(nullable: false),
                        AmbulanceDriver_PSID = c.Int(nullable: false),
                        PrimaryCareProvider_PSID = c.Int(nullable: false),
                        ReportingCrewMember_PSID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncidentNumber)
                .ForeignKey("dbo.ApplicationUser", t => t.AmbulanceDriver_PSID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.PrimaryCareProvider_PSID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.ReportingCrewMember_PSID, cascadeDelete: true)
                .Index(t => t.AmbulanceDriver_PSID)
                .Index(t => t.PrimaryCareProvider_PSID)
                .Index(t => t.ReportingCrewMember_PSID);
            
            CreateTable(
                "dbo.QAIssue",
                c => new
                    {
                        IssueID = c.Int(nullable: false, identity: true),
                        IncidentNumber = c.Int(nullable: false),
                        Note = c.String(nullable: false),
                        PtLastName = c.String(nullable: false),
                        IsResolved = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        PrimaryCareProvider_PSID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IssueID)
                .ForeignKey("dbo.Incident", t => t.IncidentNumber, cascadeDelete: true)
                .ForeignKey("dbo.PatientInformation", t => t.IncidentNumber, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.PrimaryCareProvider_PSID, cascadeDelete: true)
                .Index(t => t.IncidentNumber)
                .Index(t => t.PrimaryCareProvider_PSID);
            
            CreateTable(
                "dbo.PatientInformation",
                c => new
                    {
                        IncidentNumber = c.Int(nullable: false),
                        PtFirstName = c.String(nullable: false),
                        PtLastName = c.String(nullable: false),
                        PtAge = c.Int(nullable: false),
                        PtDateOfBirth = c.DateTime(nullable: false),
                        PtGender = c.String(nullable: false),
                        PtWeight = c.Double(nullable: false),
                        PatientAddress = c.String(nullable: false),
                        PtPhoneNumber = c.Int(nullable: false),
                        PtSSN = c.Int(nullable: false),
                        PtHistory = c.String(nullable: false),
                        PtAdvanceDirectives = c.String(),
                        PtAllergiesMeds = c.String(),
                        PtAllergiesOther = c.String(),
                        PtMedications = c.String(),
                    })
                .PrimaryKey(t => t.IncidentNumber)
                .ForeignKey("dbo.Incident", t => t.IncidentNumber)
                .Index(t => t.IncidentNumber);
            
            CreateTable(
                "dbo.Vitals",
                c => new
                    {
                        IncidentNumber = c.Int(nullable: false),
                        SystolicBloodPressure = c.Int(nullable: false),
                        DiastolicBloodPressure = c.Int(nullable: false),
                        HeartRate = c.Int(nullable: false),
                        RespiratoryRate = c.Int(nullable: false),
                        RespEffort = c.String(),
                        Rhythm = c.String(),
                        BPMethod = c.String(),
                        HRType = c.String(),
                        Oximetry = c.Int(nullable: false),
                        GCSVerbal = c.Int(nullable: false),
                        GCSMotor = c.Int(nullable: false),
                        GCSEyes = c.Int(nullable: false),
                        BloodGlucose = c.Int(nullable: false),
                        Temperature = c.Double(nullable: false),
                        VitalSignsTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.IncidentNumber)
                .ForeignKey("dbo.Incident", t => t.IncidentNumber)
                .Index(t => t.IncidentNumber);
            
            AddColumn("dbo.ApplicationUser", "PSID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "Certification", c => c.String(nullable: false));
            AlterColumn("dbo.IdentityUserRole", "ApplicationUser_PSID", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "Id", c => c.String());
            AlterColumn("dbo.IdentityUserClaim", "ApplicationUser_PSID", c => c.Int());
            AlterColumn("dbo.IdentityUserLogin", "ApplicationUser_PSID", c => c.Int());
            AddPrimaryKey("dbo.ApplicationUser", "PSID");
            CreateIndex("dbo.IdentityUserClaim", "ApplicationUser_PSID");
            CreateIndex("dbo.IdentityUserLogin", "ApplicationUser_PSID");
            CreateIndex("dbo.IdentityUserRole", "ApplicationUser_PSID");
            AddForeignKey("dbo.IdentityUserClaim", "ApplicationUser_PSID", "dbo.ApplicationUser", "PSID");
            AddForeignKey("dbo.IdentityUserLogin", "ApplicationUser_PSID", "dbo.ApplicationUser", "PSID");
            AddForeignKey("dbo.IdentityUserRole", "ApplicationUser_PSID", "dbo.ApplicationUser", "PSID");
            DropTable("dbo.PatientCareReport");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientCareReport",
                c => new
                    {
                        IncidentNumber = c.Int(nullable: false, identity: true),
                        AuthorID = c.Guid(nullable: false),
                        Disposition = c.String(nullable: false),
                        SceneAddress = c.String(nullable: false),
                        CmsLevel = c.String(nullable: false),
                        VehicleNumber = c.Int(nullable: false),
                        IncidentDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UnitNotified = c.DateTimeOffset(nullable: false, precision: 7),
                        EnRoute = c.DateTimeOffset(nullable: false, precision: 7),
                        OnScene = c.DateTimeOffset(nullable: false, precision: 7),
                        Transporting = c.DateTimeOffset(nullable: false, precision: 7),
                        Destination = c.DateTimeOffset(nullable: false, precision: 7),
                        InService = c.DateTimeOffset(nullable: false, precision: 7),
                        LoadMileage = c.Double(nullable: false),
                        PtFirstName = c.String(nullable: false),
                        PtLastName = c.String(nullable: false),
                        PtAge = c.Int(nullable: false),
                        PtDateOfBirth = c.DateTime(nullable: false),
                        PtGender = c.String(nullable: false),
                        PtWeight = c.Double(nullable: false),
                        PatientAddress = c.String(nullable: false),
                        PtPhoneNumber = c.Int(nullable: false),
                        PtSSN = c.Int(nullable: false),
                        PtHistory = c.String(nullable: false),
                        PtAdvanceDirectives = c.String(),
                        PtAllergiesMeds = c.String(),
                        PtAllergiesOther = c.String(),
                        PtMedications = c.String(),
                        PCRNarrative = c.String(nullable: false),
                        DestinationAddress = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        PtPosition = c.String(nullable: false),
                        SystolicBloodPressure = c.Int(nullable: false),
                        DiastolicBloodPressure = c.Int(nullable: false),
                        MeanPressure = c.Int(nullable: false),
                        HeartRate = c.Int(nullable: false),
                        RespiratoryRate = c.Int(nullable: false),
                        RespEffort = c.String(),
                        Rhythm = c.String(),
                        BPMethod = c.String(),
                        HRType = c.String(),
                        Oximetry = c.Int(nullable: false),
                        GCSVerbal = c.Int(nullable: false),
                        GCSMotor = c.Int(nullable: false),
                        GCSEyes = c.Int(nullable: false),
                        GCSTotal = c.Int(nullable: false),
                        BloodGlucose = c.Int(nullable: false),
                        Temperature = c.Double(nullable: false),
                        VitalSignsTime = c.DateTimeOffset(nullable: false, precision: 7),
                        PrimarySymptom = c.String(nullable: false),
                        PrimaryImpression = c.String(nullable: false),
                        SecondaryImpression = c.String(nullable: false),
                        AlcDrugUse = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IncidentNumber);
            
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Vitals", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.QAIssue", "PrimaryCareProvider_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.PatientInformation");
            DropForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.Incident", "ReportingCrewMember_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Incident", "PrimaryCareProvider_PSID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Incident", "AmbulanceDriver_PSID", "dbo.ApplicationUser");
            DropIndex("dbo.Vitals", new[] { "IncidentNumber" });
            DropIndex("dbo.PatientInformation", new[] { "IncidentNumber" });
            DropIndex("dbo.QAIssue", new[] { "PrimaryCareProvider_PSID" });
            DropIndex("dbo.QAIssue", new[] { "IncidentNumber" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_PSID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_PSID" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_PSID" });
            DropIndex("dbo.Incident", new[] { "ReportingCrewMember_PSID" });
            DropIndex("dbo.Incident", new[] { "PrimaryCareProvider_PSID" });
            DropIndex("dbo.Incident", new[] { "AmbulanceDriver_PSID" });
            DropPrimaryKey("dbo.ApplicationUser");
            AlterColumn("dbo.IdentityUserLogin", "ApplicationUser_PSID", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityUserClaim", "ApplicationUser_PSID", c => c.String(maxLength: 128));
            AlterColumn("dbo.ApplicationUser", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserRole", "ApplicationUser_PSID", c => c.String(maxLength: 128));
            DropColumn("dbo.ApplicationUser", "Certification");
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
            DropColumn("dbo.ApplicationUser", "PSID");
            DropTable("dbo.Vitals");
            DropTable("dbo.PatientInformation");
            DropTable("dbo.QAIssue");
            DropTable("dbo.Incident");
            AddPrimaryKey("dbo.ApplicationUser", "Id");
            RenameColumn(table: "dbo.IdentityUserRole", name: "ApplicationUser_PSID", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogin", name: "ApplicationUser_PSID", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserClaim", name: "ApplicationUser_PSID", newName: "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserLogin", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserClaim", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserRole", "ApplicationUser_Id");
            AddForeignKey("dbo.QAIssue", "PrimaryCareProvider_PSID", "dbo.ApplicationUser", "PSID", cascadeDelete: true);
            AddForeignKey("dbo.Incident", "ReportingCrewMember_PSID", "dbo.ApplicationUser", "PSID", cascadeDelete: true);
            AddForeignKey("dbo.Incident", "PrimaryCareProvider_PSID", "dbo.ApplicationUser", "PSID", cascadeDelete: true);
            AddForeignKey("dbo.Incident", "AmbulanceDriver_PSID", "dbo.ApplicationUser", "PSID", cascadeDelete: true);
            AddForeignKey("dbo.IdentityUserRole", "ApplicationUser_PSID", "dbo.ApplicationUser", "PSID");
            AddForeignKey("dbo.IdentityUserLogin", "ApplicationUser_PSID", "dbo.ApplicationUser", "PSID");
            AddForeignKey("dbo.IdentityUserClaim", "ApplicationUser_PSID", "dbo.ApplicationUser", "PSID");
        }
    }
}
