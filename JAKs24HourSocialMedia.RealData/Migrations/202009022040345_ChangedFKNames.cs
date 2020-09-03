namespace JAKs24HourSocialMedia.RealData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFKNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Like", name: "Id", newName: "UserId");
            RenameColumn(table: "dbo.Post", name: "Id", newName: "UserId");
            RenameIndex(table: "dbo.Like", name: "IX_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Post", name: "IX_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Post", name: "IX_UserId", newName: "IX_Id");
            RenameIndex(table: "dbo.Like", name: "IX_UserId", newName: "IX_Id");
            RenameColumn(table: "dbo.Post", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.Like", name: "UserId", newName: "Id");
        }
    }
}
