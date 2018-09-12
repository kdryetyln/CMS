namespace CMS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Menus", new[] { "MenuId" });
            AlterColumn("dbo.Menus", "MenuId", c => c.Int());
            CreateIndex("dbo.Menus", "MenuId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Menus", new[] { "MenuId" });
            AlterColumn("dbo.Menus", "MenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "MenuId");
        }
    }
}
