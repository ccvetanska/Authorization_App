namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Content : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentType = c.Int(nullable: false),
                        Body = c.String(maxLength: 1028),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "Content_Id", c => c.Int());
            CreateIndex("dbo.Questions", "Content_Id");
            AddForeignKey("dbo.Questions", "Content_Id", "dbo.Contents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Content_Id", "dbo.Contents");
            DropIndex("dbo.Questions", new[] { "Content_Id" });
            DropColumn("dbo.Questions", "Content_Id");
            DropTable("dbo.Contents");
        }
    }
}
