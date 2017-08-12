namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDatabase : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StockTransferDetail");
            DropPrimaryKey("dbo.SYSAuditingLog");
            DropPrimaryKey("dbo.Transporter");
            AlterColumn("dbo.StockTransferDetail", "ItemID", c => c.Guid(nullable: false));
            AlterColumn("dbo.StockTransferDetail", "FromStockID", c => c.Guid(nullable: false));
            AlterColumn("dbo.StockTransferDetail", "ToStockID", c => c.Guid(nullable: false));
            AlterColumn("dbo.StockTransferDetail", "EmployeeID", c => c.Guid(nullable: false));
            AlterColumn("dbo.StockTransferDetail", "ObjectID", c => c.Guid(nullable: false));
            AlterColumn("dbo.StockTransferDetail", "StatisticItemID", c => c.Guid(nullable: false));
            AlterColumn("dbo.SYSAuditingLog", "ActionName", c => c.String(maxLength: 50));
            AlterColumn("dbo.SYSAuditingLog", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Transporter", "TransporterCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.Transporter", "TransporterName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Unit", "ItemOptionID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.StockTransferDetail", "VoucherDetailID");
            AddPrimaryKey("dbo.SYSAuditingLog", "SYSAuditingLogID");
            AddPrimaryKey("dbo.Transporter", "TransporterID");
            DropColumn("dbo.StockTransferDetail", "Quantity");
            DropColumn("dbo.StockTransferDetail", "QuantityConvert");
            DropColumn("dbo.StockTransferDetail", "UnitPrice");
            DropColumn("dbo.StockTransferDetail", "UnitPriceConvert");
            DropColumn("dbo.StockTransferDetail", "Amount");
            DropColumn("dbo.StockTransferDetail", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockTransferDetail", "Unit", c => c.String(maxLength: 50));
            AddColumn("dbo.StockTransferDetail", "Amount", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.StockTransferDetail", "UnitPriceConvert", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.StockTransferDetail", "UnitPrice", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.StockTransferDetail", "QuantityConvert", c => c.Decimal(nullable: false, precision: 22, scale: 8));
            AddColumn("dbo.StockTransferDetail", "Quantity", c => c.Decimal(nullable: false, precision: 22, scale: 8));
            DropPrimaryKey("dbo.Transporter");
            DropPrimaryKey("dbo.SYSAuditingLog");
            DropPrimaryKey("dbo.StockTransferDetail");
            AlterColumn("dbo.Unit", "ItemOptionID", c => c.Guid());
            AlterColumn("dbo.Transporter", "TransporterName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Transporter", "TransporterCode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SYSAuditingLog", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SYSAuditingLog", "ActionName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StockTransferDetail", "StatisticItemID", c => c.Guid());
            AlterColumn("dbo.StockTransferDetail", "ObjectID", c => c.Guid());
            AlterColumn("dbo.StockTransferDetail", "EmployeeID", c => c.Guid());
            AlterColumn("dbo.StockTransferDetail", "ToStockID", c => c.Guid());
            AlterColumn("dbo.StockTransferDetail", "FromStockID", c => c.Guid());
            AlterColumn("dbo.StockTransferDetail", "ItemID", c => c.Guid());
            AddPrimaryKey("dbo.Transporter", new[] { "TransporterID", "TransporterCode", "TransporterName" });
            AddPrimaryKey("dbo.SYSAuditingLog", new[] { "SYSAuditingLogID", "ActionName", "UserName", "CreateDate" });
            AddPrimaryKey("dbo.StockTransferDetail", new[] { "VoucherDetailID", "VoucherID", "Quantity", "QuantityConvert", "UnitPrice", "UnitPriceConvert", "Amount" });
        }
    }
}
