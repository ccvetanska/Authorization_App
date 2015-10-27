namespace Authorization_App.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestSetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        AuthorId = c.String(),
                        Code = c.String(maxLength: 8),
                        ExpiresAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestSetups");
        }
    }
}
