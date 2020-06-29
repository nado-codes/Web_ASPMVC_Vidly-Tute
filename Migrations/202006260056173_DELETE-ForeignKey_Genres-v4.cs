namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELETEForeignKey_Genresv4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Movies", "GenreId");
        }
        
        public override void Down()
        {
        }
    }
}
