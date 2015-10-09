namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AuthorId", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "AuthorId");
        }
    }
}
