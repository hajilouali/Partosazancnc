namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980328 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Menus");
        }
        
        public override void Down()
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
    }
}
