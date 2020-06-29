namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELETEForeignKey_Genres : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Movies", "GenreId", "Genres");
        }
        
        public override void Down()
        {
            DropForeignKey("Movies", "GenreId", "Genres");
        }
    }
}
