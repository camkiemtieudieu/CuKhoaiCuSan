namespace CuKhoaiCuSan.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusFromItemOption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemOption", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemOption", "Status");
        }
    }
}
