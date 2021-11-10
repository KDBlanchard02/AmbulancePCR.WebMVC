namespace AmbulancePCR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saved5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QAIssue", "DateModified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.QAIssue", "AuthorID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QAIssue", "AuthorID");
            DropColumn("dbo.QAIssue", "DateModified");
        }
    }
}
