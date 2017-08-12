namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editForeiKeyItemID03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankTransferDetail", "VoucherID", "dbo.BankTransfer");
            DropIndex("dbo.BankTransferDetail", new[] { "VoucherID" });
            DropPrimaryKey("dbo.Item");
            AlterColumn("dbo.BankTransferDetail", "VoucherID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Item", "ItemID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Item", "ItemID");
            CreateIndex("dbo.BankTransferDetail", "VoucherID");
            CreateIndex("dbo.ItemOption", "ItemID");
            AddForeignKey("dbo.ItemOption", "ItemID", "dbo.Item", "ItemID", cascadeDelete: true);
            AddForeignKey("dbo.BankTransferDetail", "VoucherID", "dbo.BankTransfer", "VoucherID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankTransferDetail", "VoucherID", "dbo.BankTransfer");
            DropForeignKey("dbo.ItemOption", "ItemID", "dbo.Item");
            DropIndex("dbo.ItemOption", new[] { "ItemID" });
            DropIndex("dbo.BankTransferDetail", new[] { "VoucherID" });
            DropPrimaryKey("dbo.Item");
            AlterColumn("dbo.Item", "ItemID", c => c.Guid());
            AlterColumn("dbo.BankTransferDetail", "VoucherID", c => c.Guid());
            AddPrimaryKey("dbo.Item", "CreateDate");
            CreateIndex("dbo.BankTransferDetail", "VoucherID");
            AddForeignKey("dbo.BankTransferDetail", "VoucherID", "dbo.BankTransfer", "VoucherID");
        }
    }
}
