namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDayCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDay");
        }
    }
}
