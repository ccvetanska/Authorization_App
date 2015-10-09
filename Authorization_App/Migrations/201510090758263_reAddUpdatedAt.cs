namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reAddUpdatedAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "UpdatedAt");
        }
    }
}
