namespace Movease.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PulledMovieClassUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Movie_MovieId", c => c.Int());
            AlterColumn("dbo.Comment", "Text", c => c.String(nullable: false));
            CreateIndex("dbo.Comment", "Movie_MovieId");
            AddForeignKey("dbo.Comment", "Movie_MovieId", "dbo.Movie", "MovieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.Comment", new[] { "Movie_MovieId" });
            AlterColumn("dbo.Comment", "Text", c => c.String());
            DropColumn("dbo.Comment", "Movie_MovieId");
        }
    }
}
