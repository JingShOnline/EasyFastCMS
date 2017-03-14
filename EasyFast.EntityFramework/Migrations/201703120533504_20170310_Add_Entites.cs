namespace EasyFast.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _20170310_Add_Entites : DbMigration
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
                        ColumnIdentify = c.String(nullable: false, maxLength: 50),
                        Dir = c.String(nullable: false),
                        ImageUrl = c.String(maxLength: 200),
                        Tooltip = c.String(maxLength: 500),
                        Info = c.String(maxLength: 500),
                        Keyword = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                        IndexTemplate = c.String(maxLength: 100),
                        ListTemplate = c.String(maxLength: 100),
                        ContentTemplate = c.String(maxLength: 100),
                        IndexHtmlRule = c.String(maxLength: 100),
                        IsIndexHtml = c.Boolean(nullable: false),
                        ListHtmlRule = c.String(maxLength: 100),
                        IsListHtml = c.Boolean(nullable: false),
                        ContentHtmlRule = c.String(maxLength: 100),
                        IsContentHtml = c.Boolean(nullable: false),
                        IsStaticHtml = c.Boolean(nullable: false),
                        SingleTemplate = c.String(maxLength: 100),
                        SingleHtmlRule = c.String(maxLength: 100),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Column", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.ColumnIdentify, unique: true);
            
            CreateTable(
                "dbo.Common_Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        Keyword = c.String(),
                        Info = c.String(),
                        Title = c.String(),
                        Hits = c.Int(nullable: false),
                        DayHits = c.Int(nullable: false),
                        WeekHits = c.Int(nullable: false),
                        MonthHits = c.Int(nullable: false),
                        DefaultPicUrl = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Common_Model_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Column", t => t.ColumnId)
                .ForeignKey("dbo.ModelRecord", t => t.ModelId)
                .Index(t => t.ColumnId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.ModelRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Description = c.String(),
                        Unit = c.String(),
                        IsCountHits = c.Boolean(nullable: false),
                        TableName = c.String(),
                        ManagerControlerPath = c.String(),
                        ContentTemplatePath = c.String(),
                        SearchPageTamplatePath = c.String(),
                        SearchResultTemplatePath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ModelRecord_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Content_Article",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullTitle = c.String(),
                        ShortTitle = c.String(),
                        Content = c.String(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Content_Article_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Common_Model", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Content_lawyer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        Position = c.String(),
                        Bureaux = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Content = c.String(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Content_Lawyer_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Common_Model", t => t.Id)
                .Index(t => t.Id);
            
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
            DropForeignKey("dbo.Content_lawyer", "Id", "dbo.Common_Model");
            DropForeignKey("dbo.Content_Article", "Id", "dbo.Common_Model");
            DropForeignKey("dbo.Common_Model", "ModelId", "dbo.ModelRecord");
            DropForeignKey("dbo.Common_Model", "ColumnId", "dbo.Column");
            DropForeignKey("dbo.Column", "ParentId", "dbo.Column");
            DropIndex("dbo.Content_lawyer", new[] { "Id" });
            DropIndex("dbo.Content_Article", new[] { "Id" });
            DropIndex("dbo.Common_Model", new[] { "ModelId" });
            DropIndex("dbo.Common_Model", new[] { "ColumnId" });
            DropIndex("dbo.Column", new[] { "ColumnIdentify" });
            DropIndex("dbo.Column", new[] { "ParentId" });
            DropTable("dbo.Content_lawyer",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Content_Lawyer_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Content_Article",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Content_Article_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SiteConfig");
            DropTable("dbo.ModelRecord",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ModelRecord_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Common_Model",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Common_Model_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
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
