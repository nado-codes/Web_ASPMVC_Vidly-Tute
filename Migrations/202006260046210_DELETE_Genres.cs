namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELETE_Genres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Movies","GenreId","Genres");
            //DropTable("Genres");
        }
        
        public override void Down()
        {
        }
    }
}
