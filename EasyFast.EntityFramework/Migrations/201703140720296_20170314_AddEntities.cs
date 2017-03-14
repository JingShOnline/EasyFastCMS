namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170314_AddEntities : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Column", "ParentId");
            RenameColumn(table: "dbo.Column", name: "Column_Id", newName: "ParentId");
            RenameIndex(table: "dbo.Column", name: "IX_Column_Id", newName: "IX_ParentId");
            CreateTable(
                "dbo.Common_Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        Keyword = c.String(),
                        Info = c.String(),
                        Title = c.String(),
                        Hits = c.Int(nullable: false),
                        DayHits = c.Int(nullable: false),
                        WeekHits = c.Int(nullable: false),
                        MonthHits = c.Int(nullable: false),
                        DefaultPicUrl = c.String(),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Column", t => t.ColumnId)
                .ForeignKey("dbo.Model", t => t.ModelId)
                .Index(t => t.ColumnId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Model",
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Content_Article",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullTitle = c.String(maxLength: 50),
                        ShortTitle = c.String(maxLength: 25),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Common_Model", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Content_Lawyer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Position = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Common_Model", t => t.Id)
                .Index(t => t.Id);
            
            CreateIndex("dbo.Column", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Content_Lawyer", "Id", "dbo.Common_Model");
            DropForeignKey("dbo.Content_Article", "Id", "dbo.Common_Model");
            DropForeignKey("dbo.Common_Model", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Common_Model", "ColumnId", "dbo.Column");
            DropIndex("dbo.Content_Lawyer", new[] { "Id" });
            DropIndex("dbo.Content_Article", new[] { "Id" });
            DropIndex("dbo.Common_Model", new[] { "ModelId" });
            DropIndex("dbo.Common_Model", new[] { "ColumnId" });
            DropIndex("dbo.Column", new[] { "Name" });
            DropTable("dbo.Content_Lawyer");
            DropTable("dbo.Content_Article");
            DropTable("dbo.Model");
            DropTable("dbo.Common_Model");
            RenameIndex(table: "dbo.Column", name: "IX_ParentId", newName: "IX_Column_Id");
            RenameColumn(table: "dbo.Column", name: "ParentId", newName: "Column_Id");
            AddColumn("dbo.Column", "ParentId", c => c.Int());
        }
    }
}
