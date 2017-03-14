namespace EasyFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170313_updateColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Common_Model", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Common_Model", "ItemId", c => c.Int(nullable: false));
        }
    }
}
