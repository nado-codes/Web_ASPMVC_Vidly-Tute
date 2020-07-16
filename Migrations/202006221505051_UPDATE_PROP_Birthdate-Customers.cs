namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_PROP_BirthdateCustomers : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Customers", "BirthDate");
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: true));
            
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
