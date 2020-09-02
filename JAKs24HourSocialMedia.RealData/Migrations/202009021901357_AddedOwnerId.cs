namespace JAKs24HourSocialMedia.RealData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOwnerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "Id", "dbo.User");
            DropForeignKey("dbo.Like", "Id", "dbo.User");
            DropIndex("dbo.Like", new[] { "Id" });
            DropIndex("dbo.Post", new[] { "Id" });
            DropPrimaryKey("dbo.User");
            AddColumn("dbo.User", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Like", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Post", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AddPrimaryKey("dbo.User", "Id");
            CreateIndex("dbo.Like", "Id");
            CreateIndex("dbo.Post", "Id");
            AddForeignKey("dbo.Post", "Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Like", "Id", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "Id", "dbo.User");
            DropForeignKey("dbo.Post", "Id", "dbo.User");
            DropIndex("dbo.Post", new[] { "Id" });
            DropIndex("dbo.Like", new[] { "Id" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Post", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Like", "Id", c => c.Guid(nullable: false));
            DropColumn("dbo.User", "OwnerId");
            AddPrimaryKey("dbo.User", "Id");
            CreateIndex("dbo.Post", "Id");
            CreateIndex("dbo.Like", "Id");
            AddForeignKey("dbo.Like", "Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Post", "Id", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
