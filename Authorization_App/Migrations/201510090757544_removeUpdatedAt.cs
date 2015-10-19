namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUpdatedAt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "UpdatedAt", c => c.DateTime());
        }
    }
}
