namespace Stories.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Content = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.UserId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GroupStories",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.StoryId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.StoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupStories", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.GroupStories", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.GroupUsers", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Stories", "UserId", "dbo.Users");
            DropIndex("dbo.GroupStories", new[] { "StoryId" });
            DropIndex("dbo.GroupStories", new[] { "GroupId" });
            DropIndex("dbo.GroupUsers", new[] { "UserId" });
            DropIndex("dbo.GroupUsers", new[] { "GroupId" });
            DropIndex("dbo.Stories", new[] { "UserId" });
            DropTable("dbo.GroupStories");
            DropTable("dbo.GroupUsers");
            DropTable("dbo.Stories");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
        }
    }
}
