namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDB_Column : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommonTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        ModelId = c.Int(),
                        Title = c.String(nullable: false, maxLength: 200),
                        FullTitle = c.String(maxLength: 500),
                        ShortTitle = c.String(maxLength: 100),
                        Hits = c.Int(nullable: false),
                        DayHits = c.Int(nullable: false),
                        WeekHits = c.Int(nullable: false),
                        MonthHits = c.Int(nullable: false),
                        DefaultPicUrl = c.String(maxLength: 200),
                        Keyword = c.String(maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Info = c.String(maxLength: 500),
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
                        Name = c.String(nullable: false, maxLength: 50),
                        TableName = c.String(nullable: false, maxLength: 50),
                        Remarks = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Content_Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        Guide = c.String(maxLength: 500),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Column", t => t.ColumnId)
                .Index(t => t.ColumnId);
            
            CreateTable(
                "dbo.Content_Lawyer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Avatar = c.String(maxLength: 200),
                        Position = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Guide = c.String(maxLength: 500),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Content_Article", "ColumnId", "dbo.Column");
            DropForeignKey("dbo.CommonTitle", "ModelId", "dbo.Model");
            DropForeignKey("dbo.CommonTitle", "ColumnId", "dbo.Column");
            DropIndex("dbo.Content_Article", new[] { "ColumnId" });
            DropIndex("dbo.CommonTitle", new[] { "ModelId" });
            DropIndex("dbo.CommonTitle", new[] { "ColumnId" });
            DropTable("dbo.Content_Lawyer");
            DropTable("dbo.Content_Article");
            DropTable("dbo.Model");
            DropTable("dbo.CommonTitle");
        }
    }
}
