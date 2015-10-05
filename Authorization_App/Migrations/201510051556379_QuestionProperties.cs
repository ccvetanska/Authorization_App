namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(maxLength: 1028),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isCorrect = c.Boolean(nullable: false),
                        QuestionRefId = c.Int(nullable: false),
                        Content_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.Content_Id)
                .ForeignKey("dbo.Questions", t => t.QuestionRefId, cascadeDelete: true)
                .Index(t => t.QuestionRefId)
                .Index(t => t.Content_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionOptions", "QuestionRefId", "dbo.Questions");
            DropForeignKey("dbo.QuestionOptions", "Content_Id", "dbo.Contents");
            DropIndex("dbo.QuestionOptions", new[] { "Content_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionRefId" });
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.Contents");
        }
    }
}
