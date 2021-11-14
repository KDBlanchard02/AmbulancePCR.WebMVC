namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savedChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vitals", "GCSVerbal", c => c.String(nullable: false));
            AlterColumn("dbo.Vitals", "GCSMotor", c => c.String(nullable: false));
            AlterColumn("dbo.Vitals", "GCSEyes", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vitals", "GCSEyes", c => c.Int(nullable: false));
            AlterColumn("dbo.Vitals", "GCSMotor", c => c.Int(nullable: false));
            AlterColumn("dbo.Vitals", "GCSVerbal", c => c.Int(nullable: false));
        }
    }
}
