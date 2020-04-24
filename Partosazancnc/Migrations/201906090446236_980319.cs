namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980319 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductProperties", "value", c => c.String(nullable: false));
            AlterColumn("dbo.ProductProperties", "Title", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.ProductProperties", "PropertyTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductProperties", "PropertyTitle", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductProperties", "Title", c => c.String(maxLength: 150));
            DropColumn("dbo.ProductProperties", "value");
        }
    }
}
