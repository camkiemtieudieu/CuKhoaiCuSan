namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editForeiKeyItemID02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "ItemID", "dbo.ItemOption");
            DropIndex("dbo.Item", new[] { "ItemID" });
            AlterColumn("dbo.ItemOption", "ItemID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemOption", "ItemID", c => c.Guid());
            CreateIndex("dbo.Item", "ItemID");
            AddForeignKey("dbo.Item", "ItemID", "dbo.ItemOption", "ID");
        }
    }
}
