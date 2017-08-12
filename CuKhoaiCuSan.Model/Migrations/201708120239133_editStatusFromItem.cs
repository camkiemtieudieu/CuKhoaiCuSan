namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editStatusFromItem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Status", c => c.Boolean());
        }
    }
}
