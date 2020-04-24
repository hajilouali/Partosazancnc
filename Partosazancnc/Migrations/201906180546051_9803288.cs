namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9803288 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenusID = c.Int(nullable: false, identity: true),
                        MenuTitle = c.String(),
                        URL = c.String(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.MenusID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
