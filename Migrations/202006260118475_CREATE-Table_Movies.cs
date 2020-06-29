namespace ASPTute_Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CREATETable_Movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Movies",
                    c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable : false),
                    })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
