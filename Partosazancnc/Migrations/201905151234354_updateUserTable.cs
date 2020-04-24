namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PhoneNumer", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PhoneNumer");
        }
    }
}
