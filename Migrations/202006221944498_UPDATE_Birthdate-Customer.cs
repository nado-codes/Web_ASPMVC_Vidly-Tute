namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_BirthdateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate=\'1996-07-31 00:00:00\' WHERE id=1");
        }
        
        public override void Down()
        {
        }
    }
}
