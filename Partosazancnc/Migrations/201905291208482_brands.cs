namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brands : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 150),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brands");
        }
    }
}
