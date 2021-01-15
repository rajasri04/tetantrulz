namespace tetantrulz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialmodel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.demoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.demoes");
        }
    }
}
