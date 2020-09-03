namespace JAKs24HourSocialMedia.RealData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommentAndReply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CommentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: false)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Reply", "UserId", "dbo.User");
            DropIndex("dbo.Reply", new[] { "UserId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
        }
    }
}
