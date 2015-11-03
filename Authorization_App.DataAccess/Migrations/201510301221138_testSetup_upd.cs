namespace Authorization_App.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testSetup_upd : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TestSetups", "Code", unique: true, name: "UQ_TestSetup_Code");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TestSetups", "UQ_TestSetup_Code");
        }
    }
}
