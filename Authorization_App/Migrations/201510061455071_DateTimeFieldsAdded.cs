namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFieldsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "UpdatedAt");
            DropColumn("dbo.Questions", "CreatedAt");
            DropColumn("dbo.Questions", "AuthorId");
        }
    }
}
