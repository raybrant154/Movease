namespace Movease.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingStuffBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieOnList", "UserId", "dbo.User");
            DropForeignKey("dbo.Movie", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.Movie", new[] { "UserId" });
            DropIndex("dbo.MovieOnList", new[] { "UserId" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.Comment", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movie", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieOnList", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", "Id");
            CreateIndex("dbo.Comment", "UserId");
            CreateIndex("dbo.Movie", "UserId");
            CreateIndex("dbo.MovieOnList", "UserId");
            AddForeignKey("dbo.MovieOnList", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movie", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "UserId", "dbo.User", "Id", cascadeDelete: true);
            DropColumn("dbo.MyMoviesCollection", "CreatedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyMoviesCollection", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Movie", "UserId", "dbo.User");
            DropForeignKey("dbo.MovieOnList", "UserId", "dbo.User");
            DropIndex("dbo.MovieOnList", new[] { "UserId" });
            DropIndex("dbo.Movie", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieOnList", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Movie", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Comment", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.User", "UserId");
            CreateIndex("dbo.MovieOnList", "UserId");
            CreateIndex("dbo.Movie", "UserId");
            CreateIndex("dbo.Comment", "UserId");
            AddForeignKey("dbo.Comment", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movie", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieOnList", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
