namespace Movease.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieOnList",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        MovieId = c.Int(nullable: false),
                        CollectionId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: false)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: false)
                .ForeignKey("dbo.MyMoviesCollection", t => t.CollectionId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.MovieId)
                .Index(t => t.CollectionId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.MyMoviesCollection",
                c => new
                    {
                        CollectionId = c.Int(nullable: false, identity: true),
                        CollectionTitle = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CollectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieOnList", "UserId", "dbo.User");
            DropForeignKey("dbo.MovieOnList", "CollectionId", "dbo.MyMoviesCollection");
            DropForeignKey("dbo.MovieOnList", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieOnList", "CommentId", "dbo.Comment");
            DropIndex("dbo.MovieOnList", new[] { "CommentId" });
            DropIndex("dbo.MovieOnList", new[] { "CollectionId" });
            DropIndex("dbo.MovieOnList", new[] { "MovieId" });
            DropIndex("dbo.MovieOnList", new[] { "UserId" });
            DropTable("dbo.MyMoviesCollection");
            DropTable("dbo.MovieOnList");
        }
    }
}
