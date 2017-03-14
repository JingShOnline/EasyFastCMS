namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170308_update_column_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Column", "ColumnIdentify", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Column", "ColumnIdentify", c => c.String());
        }
    }
}
