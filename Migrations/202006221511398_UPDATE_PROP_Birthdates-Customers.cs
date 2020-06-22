namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_PROP_BirthdatesCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate=\"1996-07-31 00:00:00\" WHERE id=1");
            Sql("UPDATE Customers SET Birthdate=null WHERE id=2");
        }
        
        public override void Down()
        {
        }
    }
}
