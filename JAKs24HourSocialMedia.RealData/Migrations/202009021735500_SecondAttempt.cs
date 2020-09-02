namespace JAKs24HourSocialMedia.RealData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondAttempt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Liker_Id", "dbo.User");
            DropIndex("dbo.Comment", new[] { "Liker_Id" });
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.Post", "Title", c => c.String());
            AlterColumn("dbo.Post", "Text", c => c.String());
            DropTable("dbo.Comment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Author = c.Int(nullable: false),
                        CommentPost = c.Int(nullable: false),
                        ReplyText = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Liker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Post", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Comment", "Liker_Id");
            AddForeignKey("dbo.Comment", "Liker_Id", "dbo.User", "Id");
        }
    }
}
