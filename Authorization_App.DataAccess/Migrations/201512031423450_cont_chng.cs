namespace Authorization_App.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cont_chng : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Content_Id", "dbo.Contents");
            DropForeignKey("dbo.QuestionOptions", "Content_Id", "dbo.Contents");
            DropIndex("dbo.Questions", new[] { "Content_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "Content_Id" });
            AddColumn("dbo.Questions", "Content", c => c.String());
            AddColumn("dbo.Questions", "ContentType", c => c.Int(nullable: false));
            AddColumn("dbo.QuestionOptions", "Content", c => c.String());
            AddColumn("dbo.QuestionOptions", "ContentType", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Content_Id");
            DropColumn("dbo.QuestionOptions", "Content_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionOptions", "Content_Id", c => c.Int());
            AddColumn("dbo.Questions", "Content_Id", c => c.Int());
            DropColumn("dbo.QuestionOptions", "ContentType");
            DropColumn("dbo.QuestionOptions", "Content");
            DropColumn("dbo.Questions", "ContentType");
            DropColumn("dbo.Questions", "Content");
            CreateIndex("dbo.QuestionOptions", "Content_Id");
            CreateIndex("dbo.Questions", "Content_Id");
            AddForeignKey("dbo.QuestionOptions", "Content_Id", "dbo.Contents", "Id");
            AddForeignKey("dbo.Questions", "Content_Id", "dbo.Contents", "Id");
        }
    }
}
