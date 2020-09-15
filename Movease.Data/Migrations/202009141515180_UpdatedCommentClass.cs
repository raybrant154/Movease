namespace Movease.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCommentClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.Comment", new[] { "Movie_MovieId" });
            RenameColumn(table: "dbo.Comment", name: "Movie_MovieId", newName: "MovieId");
            AlterColumn("dbo.Comment", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "MovieId");
            AddForeignKey("dbo.Comment", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "MovieId", "dbo.Movie");
            DropIndex("dbo.Comment", new[] { "MovieId" });
            AlterColumn("dbo.Comment", "MovieId", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "MovieId", newName: "Movie_MovieId");
            CreateIndex("dbo.Comment", "Movie_MovieId");
            AddForeignKey("dbo.Comment", "Movie_MovieId", "dbo.Movie", "MovieId");
        }
    }
}
