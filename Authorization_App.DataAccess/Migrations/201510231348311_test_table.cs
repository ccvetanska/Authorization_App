namespace Authorization_App.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "TestRefId", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "TestRefId" });
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Question_Id })
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Question_Id);
            
            DropColumn("dbo.Questions", "TestRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "TestRefId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TestQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_Id", "dbo.Tests");
            DropIndex("dbo.TestQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TestQuestions", new[] { "Test_Id" });
            DropTable("dbo.TestQuestions");
            CreateIndex("dbo.Questions", "TestRefId");
            AddForeignKey("dbo.Questions", "TestRefId", "dbo.Tests", "Id", cascadeDelete: true);
        }
    }
}
