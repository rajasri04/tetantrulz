namespace tetantrulz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataToMembership : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert demoes on");
            Sql("INSERT INTO demoes(Id,name,signupfee,discount) VALUES(1,'raja',0,0)");
            Sql("INSERT INTO demoes(Id,name,signupfee,discount) VALUES(2,'dem',0,0)");
            Sql("INSERT INTO demoes(Id,name,signupfee,discount) VALUES(3,'gold',0,0)");
            Sql("INSERT INTO demoes(Id,name,signupfee,discount) VALUES(4,'diamond',0,0)");
            Sql("INSERT INTO demoes(Id,name,signupfee,discount) VALUES(5,'gold',0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
