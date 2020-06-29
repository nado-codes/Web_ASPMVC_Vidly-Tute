namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELETE_Movies : DbMigration
    {
        public override void Up()
        {
            DropTable("Movies");
        }
        
        public override void Down()
        {
        }
    }
}
