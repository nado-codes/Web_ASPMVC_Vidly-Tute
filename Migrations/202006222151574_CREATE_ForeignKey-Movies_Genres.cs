namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CREATE_ForeignKeyMovies_Genres : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
        }
    }
}
