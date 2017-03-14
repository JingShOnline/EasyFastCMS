namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170308_update_column_修改标识为ColumnIdentify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Column", "ColumnIdentify", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Column", "ColumnIdentify", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Column", new[] { "ColumnIdentify" });
            AlterColumn("dbo.Column", "ColumnIdentify", c => c.String(maxLength: 50));
        }
    }
}
