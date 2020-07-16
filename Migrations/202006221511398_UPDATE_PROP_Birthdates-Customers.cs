namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_PROP_BirthdatesCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.Customers ON");
            Sql("INSERT INTO Customers (Id,Name,IsSubscribedToNewsletter,MembershipTypeId) VALUES (1,'Nathan Linsley',0,1)");
            Sql("INSERT INTO Customers (Id,Name,IsSubscribedToNewsletter,MembershipTypeId) VALUES (2,'Jasmine Linsley',0,1)");
            Sql("SET IDENTITY_INSERT dbo.Customers OFF");
            //AddColumn("Customers","Birthdate",(c => c.DateTime))
            //Sql("UPDATE Customers SET Birthdate=\"1996-07-31 00:00:00\" WHERE id=1");
            //Sql("UPDATE Customers SET Birthdate=null WHERE id=2");
        }
        
        public override void Down()
        {
        }
    }
}
