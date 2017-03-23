namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170323_Update_SiteConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SiteConfig", "LogoUrl", c => c.String());
            AlterColumn("dbo.SiteConfig", "BannerUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SiteConfig", "BannerUrl", c => c.String(maxLength: 50));
            AlterColumn("dbo.SiteConfig", "LogoUrl", c => c.String(maxLength: 50));
        }
    }
}
