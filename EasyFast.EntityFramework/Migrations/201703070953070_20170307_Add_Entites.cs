namespace EasyFast.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _20170307_Add_Entites : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            CreateTable(
                "dbo.Column",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnTypeEnum = c.Int(nullable: false),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Dir = c.String(nullable: false),
                        ImageUrl = c.String(maxLength: 200),
                        Tooltip = c.String(maxLength: 500),
                        Info = c.String(maxLength: 500),
                        Keywords = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                        IndexTemplate = c.String(maxLength: 100),
                        ListTemplate = c.String(maxLength: 100),
                        ContentTemplate = c.String(maxLength: 100),
                        IsIndexHtml = c.Boolean(nullable: false),
                        IndexHtmlRule = c.String(maxLength: 100),
                        IsListHtml = c.Boolean(nullable: false),
                        ListHtmlRule = c.String(maxLength: 100),
                        IsContentHtml = c.Boolean(nullable: false),
                        ContentHtmlRule = c.String(maxLength: 100),
                        IsCreateSingle = c.Boolean(nullable: false),
                        SingleTemplate = c.String(maxLength: 100),
                        SingleHtmlRule = c.String(maxLength: 100),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Column", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.SiteConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteName = c.String(maxLength: 50),
                        SiteTitle = c.String(maxLength: 50),
                        SiteUrl = c.String(maxLength: 50),
                        LogoUrl = c.String(maxLength: 50),
                        BannerUrl = c.String(maxLength: 50),
                        Webmaster = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        CopyRitht = c.String(maxLength: 50),
                        Keywords = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        HTMLDir = c.String(maxLength: 50),
                        TemplateDir = c.String(nullable: false, maxLength: 50),
                        TagDir = c.String(nullable: false, maxLength: 50),
                        PageDir = c.String(nullable: false, maxLength: 50),
                        CodeDir = c.String(nullable: false, maxLength: 50),
                        TenantId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SiteConfig_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id");
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id");
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.Column", "ParentId", "dbo.Column");
            DropIndex("dbo.Column", new[] { "ParentId" });
            DropTable("dbo.SiteConfig",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SiteConfig_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Column");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id", cascadeDelete: true);
        }
    }
}
