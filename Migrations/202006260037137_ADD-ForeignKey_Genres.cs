namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDForeignKey_Genres : DbMigration
    {
        public override void Up()
        {
            //AddForeignKey("Customers","MembershipTypeId","Genres","Id");
        }
        
        public override void Down()
        {
        }
    }
}
