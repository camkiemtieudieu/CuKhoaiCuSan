namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editForeiKeyItemID : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Item", "ItemID");
            AddForeignKey("dbo.Item", "ItemID", "dbo.ItemOption", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ItemID", "dbo.ItemOption");
            DropIndex("dbo.Item", new[] { "ItemID" });
        }
    }
}
