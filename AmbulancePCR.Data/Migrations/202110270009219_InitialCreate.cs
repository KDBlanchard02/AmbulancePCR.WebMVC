namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                        PrimaryCareProvider = c.String(nullable: false),
                        AmbulanceDriver = c.String(nullable: false),
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
                        ReportingCrewMember = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IncidentNumber);
            
            CreateTable(
                "dbo.QAIssue",
                c => new
                    {
                        IssueID = c.Int(nullable: false, identity: true),
                        IncidentNumber = c.Int(nullable: false),
                        Note = c.String(nullable: false),
                        PrimaryCareProvider = c.String(nullable: false),
                        PtLastName = c.String(nullable: false),
                        IsResolved = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.IssueID)
                .ForeignKey("dbo.Incident", t => t.IncidentNumber, cascadeDelete: true)
                .ForeignKey("dbo.PatientInformation", t => t.IncidentNumber, cascadeDelete: true)
                .Index(t => t.IncidentNumber);
            
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
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vitals", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.PatientInformation");
            DropForeignKey("dbo.PatientInformation", "IncidentNumber", "dbo.Incident");
            DropForeignKey("dbo.QAIssue", "IncidentNumber", "dbo.Incident");
            DropIndex("dbo.Vitals", new[] { "IncidentNumber" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.PatientInformation", new[] { "IncidentNumber" });
            DropIndex("dbo.QAIssue", new[] { "IncidentNumber" });
            DropTable("dbo.Vitals");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PatientInformation");
            DropTable("dbo.QAIssue");
            DropTable("dbo.Incident");
        }
    }
}
