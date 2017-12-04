namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
