namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170308_update_column_修改主键为栏目标识 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Column", "ParentId", "dbo.Column");
            DropIndex("dbo.Column", new[] { "ParentId" });
            DropPrimaryKey("dbo.Column");
            AlterColumn("dbo.Column", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Column", "ParentId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Column", "Id");
            CreateIndex("dbo.Column", "ParentId");
            AddForeignKey("dbo.Column", "ParentId", "dbo.Column", "Id");
            DropColumn("dbo.Column", "ColumnIdentify");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Column", "ColumnIdentify", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Column", "ParentId", "dbo.Column");
            DropIndex("dbo.Column", new[] { "ParentId" });
            DropPrimaryKey("dbo.Column");
            AlterColumn("dbo.Column", "ParentId", c => c.Int());
            AlterColumn("dbo.Column", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Column", "Id");
            CreateIndex("dbo.Column", "ParentId");
            AddForeignKey("dbo.Column", "ParentId", "dbo.Column", "Id");
        }
    }
}
