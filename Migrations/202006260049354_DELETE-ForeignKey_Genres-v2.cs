namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELETEForeignKey_Genresv2 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE dbo.Movies DROP CONSTRAINT Genres.GenreId");
        }
    }
}
