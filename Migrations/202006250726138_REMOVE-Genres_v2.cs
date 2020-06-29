namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REMOVEGenres_v2 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Movies","Genres");
            //DropTable("Genres");
        }
        
        public override void Down()
        {
            //DropForeignKey("Movies", "Genres");
            //DropTable("Genres");
        }
    }
}
