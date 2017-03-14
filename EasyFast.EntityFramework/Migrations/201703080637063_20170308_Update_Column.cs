namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170308_Update_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Column", "ColumnIdentify", c => c.String());
            AddColumn("dbo.Column", "IsStaticHtml", c => c.Boolean(nullable: false));
            DropColumn("dbo.Column", "IsCreateSingle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Column", "IsCreateSingle", c => c.Boolean(nullable: false));
            DropColumn("dbo.Column", "IsStaticHtml");
            DropColumn("dbo.Column", "ColumnIdentify");
        }
    }
}
