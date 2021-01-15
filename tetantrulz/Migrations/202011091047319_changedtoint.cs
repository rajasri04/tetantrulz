namespace tetantrulz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtoint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "demo_Id", "dbo.demoes");
            DropIndex("dbo.Customers", new[] { "demo_Id" });
            DropColumn("dbo.Customers", "demoId");
            RenameColumn(table: "dbo.Customers", name: "demo_Id", newName: "demoId");
            AlterColumn("dbo.Customers", "demoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "demoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "demoId");
            AddForeignKey("dbo.Customers", "demoId", "dbo.demoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "demoId", "dbo.demoes");
            DropIndex("dbo.Customers", new[] { "demoId" });
            AlterColumn("dbo.Customers", "demoId", c => c.Int());
            AlterColumn("dbo.Customers", "demoId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "demoId", newName: "demo_Id");
            AddColumn("dbo.Customers", "demoId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "demo_Id");
            AddForeignKey("dbo.Customers", "demo_Id", "dbo.demoes", "Id");
        }
    }
}
