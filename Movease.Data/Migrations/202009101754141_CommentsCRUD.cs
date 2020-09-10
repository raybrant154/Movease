namespace Movease.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsCRUD : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movie", "Released");
            DropColumn("dbo.Movie", "Writer");
            DropColumn("dbo.Movie", "Language");
            DropColumn("dbo.Movie", "Country");
            DropColumn("dbo.Movie", "Awards");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Awards", c => c.String());
            AddColumn("dbo.Movie", "Country", c => c.String());
            AddColumn("dbo.Movie", "Language", c => c.String());
            AddColumn("dbo.Movie", "Writer", c => c.String());
            AddColumn("dbo.Movie", "Released", c => c.String());
        }
    }
}
