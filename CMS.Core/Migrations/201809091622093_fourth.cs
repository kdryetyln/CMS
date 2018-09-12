namespace CMS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "IsPublish", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "PublishDate");
            DropColumn("dbo.Pages", "IsPublish");
        }
    }
}
