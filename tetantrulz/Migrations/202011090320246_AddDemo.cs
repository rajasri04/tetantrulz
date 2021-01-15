namespace tetantrulz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDemo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "demoId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "demo_Id", c => c.Int());
            AddColumn("dbo.demoes", "signupfee", c => c.Short(nullable: false));
            AddColumn("dbo.demoes", "discount", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "demo_Id");
            AddForeignKey("dbo.Customers", "demo_Id", "dbo.demoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "demo_Id", "dbo.demoes");
            DropIndex("dbo.Customers", new[] { "demo_Id" });
            DropColumn("dbo.demoes", "discount");
            DropColumn("dbo.demoes", "signupfee");
            DropColumn("dbo.Customers", "demo_Id");
            DropColumn("dbo.Customers", "demoId");
        }
    }
}
