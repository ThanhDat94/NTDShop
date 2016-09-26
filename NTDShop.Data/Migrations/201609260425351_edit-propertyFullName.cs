namespace NTDShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editpropertyFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "FulName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FulName", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
