namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        BankID = c.Guid(nullable: false),
                        BankAccount = c.String(maxLength: 150),
                        BankName = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.BankID);
            
            CreateTable(
                "dbo.BankTransfer",
                c => new
                    {
                        VoucherID = c.Guid(nullable: false),
                        VoucherType = c.Int(),
                        VoucherDate = c.DateTime(storeType: "date"),
                        TotalAmountOC = c.Decimal(storeType: "money"),
                        TotalAmount = c.Decimal(storeType: "money"),
                        AccountID = c.Guid(),
                    })
                .PrimaryKey(t => t.VoucherID);
            
            CreateTable(
                "dbo.BankTransferDetail",
                c => new
                    {
                        VoucherDetailID = c.Guid(nullable: false),
                        VoucherID = c.Guid(),
                        FromBankAccount = c.String(maxLength: 50),
                        ToBankAccount = c.String(maxLength: 100),
                        FromBankName = c.String(maxLength: 255),
                        ToBankName = c.String(maxLength: 255),
                        AmountOC = c.Decimal(storeType: "money"),
                        Amount = c.Decimal(storeType: "money"),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.VoucherDetailID)
                .ForeignKey("dbo.BankTransfer", t => t.VoucherID)
                .Index(t => t.VoucherID);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        BranchID = c.Guid(nullable: false),
                        BranchCode = c.String(maxLength: 50),
                        BranchName = c.String(maxLength: 10, fixedLength: true),
                        Address = c.String(maxLength: 10, fixedLength: true),
                        TelephoneNumber = c.String(maxLength: 10, fixedLength: true),
                        Email = c.String(maxLength: 10, fixedLength: true),
                        Status = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        StockID = c.Guid(nullable: false),
                        StockName = c.String(maxLength: 150),
                        StockCode = c.String(maxLength: 150, unicode: false),
                        Desription = c.String(maxLength: 500),
                        Status = c.Boolean(),
                        BranchID = c.Guid(),
                    })
                .PrimaryKey(t => t.StockID)
                .ForeignKey("dbo.Branch", t => t.BranchID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.InvoiceType",
                c => new
                    {
                        InvoiceTypeID = c.Guid(nullable: false),
                        InvoiceTypeCode = c.String(nullable: false, maxLength: 25),
                        ParentID = c.Guid(),
                        InvoiceTypeName = c.String(nullable: false, maxLength: 255),
                        Inactive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceTypeID);
            
            CreateTable(
                "dbo.PublicInvoiceTypeDetail",
                c => new
                    {
                        PublicInvoiceTypeDetailID = c.Guid(nullable: false),
                        PublicInvoiceTypeID = c.Guid(nullable: false),
                        InvoiceTypeID = c.Guid(nullable: false),
                        InvoiceTypeName = c.String(nullable: false, maxLength: 100),
                        InvoiceSeries = c.String(nullable: false, maxLength: 50),
                        FromInvNo = c.String(nullable: false, maxLength: 20),
                        ToInvNo = c.String(nullable: false, maxLength: 20),
                        Quantity = c.Int(nullable: false),
                        UseDate = c.DateTime(nullable: false, storeType: "date"),
                        CompanyPrintedName = c.String(maxLength: 255),
                        CompanyPrintedTax = c.String(maxLength: 50),
                        ContractNo = c.String(maxLength: 50),
                        ContractDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PublicInvoiceTypeDetailID)
                .ForeignKey("dbo.PublicInvoiceType", t => t.PublicInvoiceTypeID)
                .ForeignKey("dbo.InvoiceType", t => t.InvoiceTypeID)
                .Index(t => t.PublicInvoiceTypeID)
                .Index(t => t.InvoiceTypeID);
            
            CreateTable(
                "dbo.PublicInvoiceType",
                c => new
                    {
                        PublicInvoiceTypeID = c.Guid(nullable: false),
                        PublicDate = c.DateTime(nullable: false),
                        PublicNo = c.String(nullable: false, maxLength: 50),
                        CompanyTaxName = c.String(maxLength: 255),
                        ContactName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PublicInvoiceTypeID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        CreateDate = c.DateTime(nullable: false),
                        ItemID = c.Guid(),
                        Barcode = c.String(maxLength: 15, unicode: false),
                        Name = c.String(maxLength: 250),
                        CreateBy = c.String(maxLength: 150),
                        Unit = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Brand = c.String(maxLength: 150),
                        Tags = c.String(maxLength: 50),
                        Weigh = c.String(maxLength: 10, fixedLength: true),
                        BranchID = c.Guid(),
                        StockID = c.Guid(),
                        ItemCategoryID = c.Guid(),
                        ModifiedDate = c.DateTime(storeType: "date"),
                        ModifiedBy = c.String(maxLength: 150),
                        TaxRate = c.Decimal(precision: 18, scale: 8),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.CreateDate)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryID)
                .Index(t => t.ItemCategoryID);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(maxLength: 150),
                        ItemCategoryName = c.String(maxLength: 250),
                        ParentId = c.Guid(),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemOption",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Color = c.String(maxLength: 150),
                        Size = c.String(maxLength: 150),
                        Material = c.String(maxLength: 150),
                        SalePrice = c.Decimal(storeType: "money"),
                        PurchasePrice = c.Decimal(storeType: "money"),
                        ItemID = c.Guid(),
                        Image1 = c.String(maxLength: 150),
                        Image2 = c.String(maxLength: 150),
                        Image3 = c.String(maxLength: 150),
                        Image4 = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Object",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false),
                        ObjectCode = c.String(maxLength: 50),
                        ObjectName = c.String(maxLength: 255),
                        ObjectCategoryID = c.Guid(),
                        ObjectAddress = c.String(maxLength: 255),
                        Tel = c.String(maxLength: 50),
                        BankAccount = c.String(maxLength: 50),
                        BankName = c.String(maxLength: 255),
                        TaxCode = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        DiscountRate = c.Decimal(storeType: "money"),
                        BirthdayDate = c.DateTime(),
                        AccumulativePoint = c.Int(),
                        Debt = c.Decimal(storeType: "money"),
                        ObjectKind = c.Int(),
                    })
                .PrimaryKey(t => t.ObjectID)
                .ForeignKey("dbo.ObjectCategory", t => t.ObjectCategoryID)
                .Index(t => t.ObjectCategoryID);
            
            CreateTable(
                "dbo.ObjectCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(),
                        PricePolicyID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PricePolicy", t => t.PricePolicyID)
                .Index(t => t.PricePolicyID);
            
            CreateTable(
                "dbo.PricePolicy",
                c => new
                    {
                        PricePolicyID = c.Guid(nullable: false),
                        PricePolicyCode = c.String(maxLength: 50),
                        PricePolicyName = c.String(maxLength: 150),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.PricePolicyID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 10, fixedLength: true),
                        Password = c.String(maxLength: 50),
                        ObjectID = c.Guid(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Object", t => t.ObjectID)
                .Index(t => t.ObjectID);
            
            CreateTable(
                "dbo.RoleDetail",
                c => new
                    {
                        RoleID = c.Guid(nullable: false),
                        AccountID = c.Guid(nullable: false),
                        Status = c.Int(),
                        User_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.AccountID })
                .ForeignKey("dbo.Role", t => t.RoleID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.RoleID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Guid(nullable: false),
                        RoleCode = c.String(maxLength: 50),
                        RoleName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.ObjectKind",
                c => new
                    {
                        ObjectKindID = c.Guid(nullable: false),
                        ObjectKindName = c.String(maxLength: 100),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ObjectKindID);
            
            CreateTable(
                "dbo.PurchaseInvoice",
                c => new
                    {
                        VoucherID = c.Guid(nullable: false),
                        INVoucherDate = c.DateTime(storeType: "date"),
                        INVoucherNo = c.String(maxLength: 20),
                        VoucherType = c.Int(nullable: false),
                        ObjectID = c.Guid(),
                        ObjectName = c.String(maxLength: 255),
                        ObjectAddress = c.String(maxLength: 255),
                        INContactName = c.String(maxLength: 255),
                        INJournalMemo = c.String(maxLength: 255),
                        OriginalVoucherNo = c.String(maxLength: 20),
                        CABAVoucherDate = c.DateTime(storeType: "date"),
                        CABAVoucherNo = c.String(maxLength: 20),
                        AccountingObjectBankAccount = c.String(maxLength: 50),
                        AccountingObjectBankName = c.String(maxLength: 255),
                        CABAContactName = c.String(maxLength: 255),
                        BankAccount = c.String(maxLength: 50),
                        BankName = c.String(maxLength: 255),
                        CreditCardNo = c.String(maxLength: 50),
                        BillReceived = c.Boolean(nullable: false),
                        CurrencyKindID = c.String(maxLength: 3),
                        ExchangeRate = c.Decimal(precision: 22, scale: 8),
                        PaymentTermID = c.Guid(),
                        DueDate = c.DateTime(storeType: "date"),
                        ShippingMethodID = c.Guid(),
                        EmployeeID = c.Guid(),
                        IsImportPurchase = c.Boolean(nullable: false),
                        SpecialConsumeTax = c.Boolean(nullable: false),
                        TotalAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalImportTaxAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalImportTaxAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalVATAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalVATAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalDiscountAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalDiscountAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalFreightAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalFreightAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalOutwardAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalOutwardAmount = c.Decimal(nullable: false, storeType: "money"),
                        ReconciledDate = c.DateTime(storeType: "date"),
                        Reconciled = c.Boolean(nullable: false),
                        IsPosted = c.Boolean(nullable: false),
                        LayoutID = c.Guid(),
                        SortOrder = c.Int(nullable: false),
                        EditVersion = c.Int(),
                        PostVersion = c.Int(),
                        IsAttachList = c.Boolean(nullable: false),
                        ListCommonNameInventory = c.String(maxLength: 255),
                        IsShowUnitConvert = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        ModifiedBy = c.String(maxLength: 100),
                        TotalImportTaxExpenseAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalImportTaxExpenseAmount = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.VoucherID);
            
            CreateTable(
                "dbo.PurchaseInvoiceDetail",
                c => new
                    {
                        VoucherDetailID = c.Guid(nullable: false),
                        VoucherID = c.Guid(nullable: false),
                        ItemID = c.Guid(),
                        Description = c.String(maxLength: 255),
                        StockID = c.Guid(),
                        DebitAccount = c.String(maxLength: 20),
                        CreditAccount = c.String(maxLength: 20),
                        Unit = c.String(maxLength: 50),
                        UnitConvert = c.String(maxLength: 50),
                        Quantity = c.Decimal(nullable: false, precision: 22, scale: 8),
                        QuantityConvert = c.Decimal(nullable: false, precision: 22, scale: 8),
                        UnitPriceOC = c.Decimal(nullable: false, storeType: "money"),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceConvertOC = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceConvert = c.Decimal(nullable: false, storeType: "money"),
                        AmountOC = c.Decimal(nullable: false, storeType: "money"),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        DiscountRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        DiscountAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        DiscountAmount = c.Decimal(nullable: false, storeType: "money"),
                        DiscountAccount = c.String(maxLength: 20),
                        ImportTaxRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        ImportTaxAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        ImportTaxAmount = c.Decimal(nullable: false, storeType: "money"),
                        ImportTaxAccount = c.String(maxLength: 20),
                        VATRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        VATAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        VATAmount = c.Decimal(nullable: false, storeType: "money"),
                        VATAccount = c.String(maxLength: 20),
                        InvType = c.Int(),
                        InvDate = c.DateTime(storeType: "date"),
                        InvSeries = c.String(maxLength: 20),
                        InvNo = c.String(maxLength: 20),
                        InventoryAccount = c.String(maxLength: 20),
                        COGAccount = c.String(maxLength: 20),
                        OutwardPriceOC = c.Decimal(nullable: false, storeType: "money"),
                        OutwardPrice = c.Decimal(nullable: false, storeType: "money"),
                        OutwardAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        OutwardAmount = c.Decimal(nullable: false, storeType: "money"),
                        PurchasePurposeID = c.Guid(),
                        DeductionDebitAccount = c.String(maxLength: 20),
                        CustomsUnitPriceOC = c.Decimal(nullable: false, storeType: "money"),
                        CustomsUnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        SpecialConsumeTaxRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        SpecialConsumeTaxAmount = c.Decimal(nullable: false, storeType: "money"),
                        SpecialConsumeTaxAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        SpecialConsumeTaxAccount = c.String(maxLength: 20),
                        FreightAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        FreightAmount = c.Decimal(nullable: false, storeType: "money"),
                        AccountingObjectID = c.Guid(),
                        ContractID = c.Guid(),
                        StatisticItemID = c.Guid(),
                        DepartmentID = c.Guid(),
                        ExpiryDate = c.DateTime(storeType: "date"),
                        LotNo = c.String(maxLength: 50),
                        VATPaid = c.Boolean(nullable: false),
                        PaymentVoucherID = c.Guid(),
                        SortOrder = c.Int(),
                        VATPostedDate = c.DateTime(storeType: "date"),
                        CompanyTaxCode = c.String(maxLength: 50),
                        AccountingObjectTaxID = c.Guid(),
                        AccountingObjectTaxName = c.String(maxLength: 255),
                        InvoiceTypeID = c.String(maxLength: 50),
                        ConvertRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        UnitPriceAfterTaxOC = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceAfterTax = c.Decimal(nullable: false, storeType: "money"),
                        AmountAfterTaxOC = c.Decimal(nullable: false, storeType: "money"),
                        AmountAfterTax = c.Decimal(nullable: false, storeType: "money"),
                        ImportTaxExpenseAmount = c.Decimal(nullable: false, storeType: "money"),
                        ImportTaxExpenseAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        DiscountAmountAfterTax = c.Decimal(nullable: false, precision: 22, scale: 8),
                        DiscountAmountAfterTaxOC = c.Decimal(nullable: false, precision: 22, scale: 8),
                        UnReasonableCosts = c.Boolean(nullable: false),
                        OrderVoucherID = c.Guid(),
                        OrderVoucherNo = c.String(maxLength: 25),
                        ExpenseItemID = c.Guid(),
                        JobID = c.Guid(),
                        OutwardPriceConvertOC = c.Decimal(nullable: false, storeType: "money"),
                        OutwardPriceConvert = c.Decimal(nullable: false, storeType: "money"),
                        TransporterID = c.Guid(),
                    })
                .PrimaryKey(t => t.VoucherDetailID)
                .ForeignKey("dbo.PurchaseInvoice", t => t.VoucherID)
                .Index(t => t.VoucherID);
            
            CreateTable(
                "dbo.SaleInvoice",
                c => new
                    {
                        VoucherID = c.Guid(nullable: false),
                        VoucherDate = c.DateTime(storeType: "date"),
                        VoucherType = c.Int(),
                        ObjectID = c.Guid(),
                        CABAVoucherDate = c.DateTime(storeType: "date"),
                        CABAContactName = c.String(maxLength: 255),
                        BankAccount = c.String(maxLength: 50),
                        BankName = c.String(maxLength: 50),
                        BillPaid = c.Boolean(),
                        InvType = c.Int(),
                        InvDate = c.DateTime(storeType: "date"),
                        InvSeries = c.String(maxLength: 20),
                        InvNo = c.String(maxLength: 20),
                        InvJournalMemo = c.String(maxLength: 255),
                        InvContactName = c.String(maxLength: 255),
                        CompanyTaxCode = c.String(maxLength: 50),
                        CurrencyKindID = c.String(maxLength: 3),
                        ExchangeRate = c.Decimal(precision: 22, scale: 8),
                        DueDate = c.DateTime(storeType: "date"),
                        ShippingMethodID = c.Guid(),
                        EmployeeID = c.Guid(),
                        TotalAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalDiscountAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalDiscountAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalVATAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        TotalVATAmount = c.Decimal(nullable: false, storeType: "money"),
                        TotalOutwardAmount = c.Decimal(nullable: false, storeType: "money"),
                        IsPosted = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        InvoiceForm = c.Int(),
                        InvoiceTypeID = c.Guid(),
                        OutwardVoucherID = c.Guid(),
                        CommisionRate = c.Decimal(precision: 22, scale: 8),
                        CommisionAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        CommisionAmount = c.Decimal(nullable: false, storeType: "money"),
                        ListNo = c.String(maxLength: 20),
                        ListDate = c.DateTime(storeType: "date"),
                        IsAttachList = c.Boolean(nullable: false),
                        IsShowUnitConvert = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        ModifiedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.VoucherID);
            
            CreateTable(
                "dbo.SaleInvoiceDetail",
                c => new
                    {
                        VoucherDetailID = c.Guid(nullable: false),
                        VoucherID = c.Guid(nullable: false),
                        ItemID = c.Guid(),
                        Description = c.String(maxLength: 255),
                        StockID = c.Guid(),
                        DebitAccount = c.String(maxLength: 20),
                        CreditAccount = c.String(maxLength: 20),
                        Unit = c.String(maxLength: 50),
                        UnitConvert = c.String(maxLength: 50),
                        Quantity = c.Decimal(nullable: false, precision: 22, scale: 8),
                        QuantityConvert = c.Decimal(nullable: false, precision: 22, scale: 8),
                        UnitPriceOC = c.Decimal(nullable: false, storeType: "money"),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceConvertOC = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceConvert = c.Decimal(nullable: false, storeType: "money"),
                        AmountOC = c.Decimal(nullable: false, storeType: "money"),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        DiscountRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        DiscountAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        DiscountAmount = c.Decimal(nullable: false, storeType: "money"),
                        DiscountAccount = c.String(maxLength: 20),
                        VATRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        VATAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        VATAmount = c.Decimal(nullable: false, storeType: "money"),
                        VATAccount = c.String(maxLength: 20),
                        InventoryAccount = c.String(maxLength: 20),
                        COGAccount = c.String(maxLength: 20),
                        OutwardPrice = c.Decimal(nullable: false, storeType: "money"),
                        OutwardAmount = c.Decimal(nullable: false, storeType: "money"),
                        ConfrontingVoucherID = c.Guid(),
                        ExpiryDate = c.DateTime(storeType: "date"),
                        LotNo = c.String(maxLength: 50),
                        Warranty = c.String(maxLength: 255),
                        AccountingObjectID = c.Guid(),
                        ContractID = c.Guid(),
                        StatisticItemID = c.Guid(),
                        SortOrder = c.Int(),
                        SpecialConsumeTaxRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        SpecialConsumeTaxAmountOC = c.Decimal(nullable: false, storeType: "money"),
                        SpecialConsumeTaxAmount = c.Decimal(nullable: false, storeType: "money"),
                        SpecialConsumeUnitPriceOC = c.Decimal(nullable: false, storeType: "money"),
                        SpecialConsumeUnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        ConvertRate = c.Decimal(nullable: false, precision: 22, scale: 8),
                        UnitPriceAfterTaxOC = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceAfterTax = c.Decimal(nullable: false, storeType: "money"),
                        AmountAfterTaxOC = c.Decimal(nullable: false, storeType: "money"),
                        AmountAfterTax = c.Decimal(nullable: false, storeType: "money"),
                        DiscountAmountAfterTax = c.Decimal(nullable: false, precision: 22, scale: 8),
                        DiscountAmountAfterTaxOC = c.Decimal(nullable: false, precision: 22, scale: 8),
                        DepartmentID = c.Guid(),
                        CreditAccountingObjectID = c.Guid(),
                        ConfrontingVoucherDetailID = c.Guid(),
                        ContractVoucherDetailID = c.Guid(),
                        OutwardPurpose = c.Int(),
                        JobID = c.Guid(),
                        ExpenseItemID = c.Guid(),
                        OutwardPriceConvert = c.Decimal(nullable: false, storeType: "money"),
                        TransporterID = c.Guid(),
                        PurchasePurposeID = c.Guid(),
                        VATPostedDate = c.DateTime(storeType: "date"),
                        InvType = c.Int(),
                        InvDate = c.DateTime(storeType: "date"),
                        InvSeries = c.String(maxLength: 20),
                        InvNo = c.String(maxLength: 20),
                        CompanyTaxCode = c.String(maxLength: 50),
                        AccountingObjectTaxID = c.Guid(),
                        AccountingObjectTaxName = c.String(maxLength: 255),
                        InvoiceTypeID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.VoucherDetailID)
                .ForeignKey("dbo.SaleInvoice", t => t.VoucherID)
                .Index(t => t.VoucherID);
            
            CreateTable(
                "dbo.StockTransfer",
                c => new
                    {
                        VoucherID = c.Guid(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        VoucherDate = c.DateTime(nullable: false),
                        VoucherNo = c.String(nullable: false, maxLength: 20),
                        ObjectID = c.Guid(),
                        ObjectName = c.String(maxLength: 255),
                        ObjectAddress = c.String(maxLength: 255),
                        JournalMemo = c.String(maxLength: 255),
                        InwardStockKeeper = c.String(maxLength: 255),
                        OutwardStockKeeper = c.String(maxLength: 255),
                        TotalAmount = c.Decimal(nullable: false, storeType: "money"),
                        IsPosted = c.Boolean(nullable: false),
                        PostVersion = c.Int(),
                        EditVersion = c.Int(),
                        SortOrder = c.Int(nullable: false),
                        IsExport = c.Boolean(),
                        InvoiceTypeID = c.Guid(),
                        InvSeries = c.String(maxLength: 20),
                        ContractNo = c.String(maxLength: 50),
                        Transport = c.String(maxLength: 255),
                        MobilizationNo = c.String(maxLength: 255),
                        MobilizationDate = c.DateTime(),
                        MobilizationOf = c.String(maxLength: 255),
                        MobilizationFor = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 100),
                        ModifiedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.VoucherID);
            
            CreateTable(
                "dbo.StockTransferDetail",
                c => new
                    {
                        VoucherDetailID = c.Guid(nullable: false),
                        VoucherID = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 22, scale: 8),
                        QuantityConvert = c.Decimal(nullable: false, precision: 22, scale: 8),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitPriceConvert = c.Decimal(nullable: false, storeType: "money"),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        ItemID = c.Guid(),
                        Description = c.String(maxLength: 255),
                        FromStockID = c.Guid(),
                        ToStockID = c.Guid(),
                        Unit = c.String(maxLength: 50),
                        ConfrontingVoucherID = c.Guid(),
                        EmployeeID = c.Guid(),
                        ObjectID = c.Guid(),
                        StatisticItemID = c.Guid(),
                        SortOrder = c.Int(),
                        UnitConvert = c.String(maxLength: 20),
                        ConvertRate = c.Decimal(precision: 22, scale: 8),
                        ExpiryDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.VoucherDetailID, t.VoucherID, t.Quantity, t.QuantityConvert, t.UnitPrice, t.UnitPriceConvert, t.Amount })
                .ForeignKey("dbo.StockTransfer", t => t.VoucherID)
                .Index(t => t.VoucherID);
            
            CreateTable(
                "dbo.StoreInfo",
                c => new
                    {
                        Version = c.String(nullable: false, maxLength: 150),
                        CreateDate = c.DateTime(storeType: "date"),
                        DomainName = c.String(maxLength: 50, unicode: false),
                        Desription = c.String(maxLength: 250),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Version);
            
            CreateTable(
                "dbo.SYSAuditingLog",
                c => new
                    {
                        SYSAuditingLogID = c.Int(nullable: false),
                        ActionName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.SYSAuditingLogID, t.ActionName, t.UserName, t.CreateDate });
            
            CreateTable(
                "dbo.Transporter",
                c => new
                    {
                        TransporterID = c.Guid(nullable: false),
                        TransporterCode = c.String(nullable: false, maxLength: 50),
                        TransporterName = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.TransporterID, t.TransporterCode, t.TransporterName });
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 150),
                        UnitConvertRate = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        ItemOptionID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VoucherCheck",
                c => new
                    {
                        VoucherID = c.Guid(nullable: false),
                        VoucherType = c.Int(),
                        VoucherDate = c.DateTime(),
                        ObjectID = c.Guid(),
                        StockID = c.Guid(),
                        Tags = c.String(maxLength: 50, unicode: false),
                        Note = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.VoucherID);
            
            CreateTable(
                "dbo.VoucherCheckDetail",
                c => new
                    {
                        VoucherCheckDetailID = c.Guid(nullable: false),
                        VoucherCheckID = c.Guid(),
                        ItemID = c.Guid(),
                        InStock = c.Decimal(precision: 18, scale: 8),
                        AfterCheck = c.Decimal(precision: 18, scale: 8),
                        Reason = c.String(maxLength: 150),
                        Result = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.VoucherCheckDetailID);
            
            CreateTable(
                "dbo.VoucherType",
                c => new
                    {
                        VoucherType = c.Int(nullable: false, identity: true),
                        VoucherName = c.String(maxLength: 250),
                        Status = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.VoucherType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockTransferDetail", "VoucherID", "dbo.StockTransfer");
            DropForeignKey("dbo.SaleInvoiceDetail", "VoucherID", "dbo.SaleInvoice");
            DropForeignKey("dbo.PurchaseInvoiceDetail", "VoucherID", "dbo.PurchaseInvoice");
            DropForeignKey("dbo.RoleDetail", "User_ID", "dbo.User");
            DropForeignKey("dbo.RoleDetail", "RoleID", "dbo.Role");
            DropForeignKey("dbo.User", "ObjectID", "dbo.Object");
            DropForeignKey("dbo.ObjectCategory", "PricePolicyID", "dbo.PricePolicy");
            DropForeignKey("dbo.Object", "ObjectCategoryID", "dbo.ObjectCategory");
            DropForeignKey("dbo.Item", "ItemCategoryID", "dbo.ItemCategory");
            DropForeignKey("dbo.PublicInvoiceTypeDetail", "InvoiceTypeID", "dbo.InvoiceType");
            DropForeignKey("dbo.PublicInvoiceTypeDetail", "PublicInvoiceTypeID", "dbo.PublicInvoiceType");
            DropForeignKey("dbo.Stock", "BranchID", "dbo.Branch");
            DropForeignKey("dbo.BankTransferDetail", "VoucherID", "dbo.BankTransfer");
            DropIndex("dbo.StockTransferDetail", new[] { "VoucherID" });
            DropIndex("dbo.SaleInvoiceDetail", new[] { "VoucherID" });
            DropIndex("dbo.PurchaseInvoiceDetail", new[] { "VoucherID" });
            DropIndex("dbo.RoleDetail", new[] { "User_ID" });
            DropIndex("dbo.RoleDetail", new[] { "RoleID" });
            DropIndex("dbo.User", new[] { "ObjectID" });
            DropIndex("dbo.ObjectCategory", new[] { "PricePolicyID" });
            DropIndex("dbo.Object", new[] { "ObjectCategoryID" });
            DropIndex("dbo.Item", new[] { "ItemCategoryID" });
            DropIndex("dbo.PublicInvoiceTypeDetail", new[] { "InvoiceTypeID" });
            DropIndex("dbo.PublicInvoiceTypeDetail", new[] { "PublicInvoiceTypeID" });
            DropIndex("dbo.Stock", new[] { "BranchID" });
            DropIndex("dbo.BankTransferDetail", new[] { "VoucherID" });
            DropTable("dbo.VoucherType");
            DropTable("dbo.VoucherCheckDetail");
            DropTable("dbo.VoucherCheck");
            DropTable("dbo.Unit");
            DropTable("dbo.Transporter");
            DropTable("dbo.SYSAuditingLog");
            DropTable("dbo.StoreInfo");
            DropTable("dbo.StockTransferDetail");
            DropTable("dbo.StockTransfer");
            DropTable("dbo.SaleInvoiceDetail");
            DropTable("dbo.SaleInvoice");
            DropTable("dbo.PurchaseInvoiceDetail");
            DropTable("dbo.PurchaseInvoice");
            DropTable("dbo.ObjectKind");
            DropTable("dbo.Role");
            DropTable("dbo.RoleDetail");
            DropTable("dbo.User");
            DropTable("dbo.PricePolicy");
            DropTable("dbo.ObjectCategory");
            DropTable("dbo.Object");
            DropTable("dbo.ItemOption");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.Item");
            DropTable("dbo.PublicInvoiceType");
            DropTable("dbo.PublicInvoiceTypeDetail");
            DropTable("dbo.InvoiceType");
            DropTable("dbo.Stock");
            DropTable("dbo.Branch");
            DropTable("dbo.BankTransferDetail");
            DropTable("dbo.BankTransfer");
            DropTable("dbo.Bank");
        }
    }
}
