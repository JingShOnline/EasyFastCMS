namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170322_Update_Column : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Column", "IsCreateSingle");
            DropColumn("dbo.Column", "SingleTemplate");
            DropColumn("dbo.Column", "SingleHtmlRule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Column", "SingleHtmlRule", c => c.String(maxLength: 100));
            AddColumn("dbo.Column", "SingleTemplate", c => c.String(maxLength: 100));
            AddColumn("dbo.Column", "IsCreateSingle", c => c.Boolean(nullable: false));
        }
    }
}
