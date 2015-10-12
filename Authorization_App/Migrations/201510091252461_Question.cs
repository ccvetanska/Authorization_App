namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Question : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(),
                        Title = c.String(maxLength: 256),
                        Description = c.String(maxLength: 512),
                        Tags = c.String(maxLength: 1028),
                        Level = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
        }
    }
}
