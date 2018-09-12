namespace CMS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PLItems", "SizeValue", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PLItems", "SizeValue", c => c.Int(nullable: false));
        }
    }
}
