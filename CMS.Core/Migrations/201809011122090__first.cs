namespace CMS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: false)
                .Index(t => t.PageId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PageLayoutId = c.Int(nullable: false),
                        Slug = c.String(),
                        meta = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageLayouts", t => t.PageLayoutId, cascadeDelete: false)
                .Index(t => t.PageLayoutId);
            
            CreateTable(
                "dbo.PageLayouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PLItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        SelectedColumn = c.Int(nullable: false),
                        SizeValue = c.Int(nullable: false),
                        PageLayoutId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageLayouts", t => t.PageLayoutId, cascadeDelete: false)
                .Index(t => t.PageLayoutId);
            
            CreateTable(
                "dbo.PageContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Content = c.String(),
                        divId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: false)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterLayout = c.String(),
                        SiteName = c.String(),
                        SiteFooter = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageContents", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Menus", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Pages", "PageLayoutId", "dbo.PageLayouts");
            DropForeignKey("dbo.PLItems", "PageLayoutId", "dbo.PageLayouts");
            DropForeignKey("dbo.Menus", "MenuId", "dbo.Menus");
            DropIndex("dbo.PageContents", new[] { "PageId" });
            DropIndex("dbo.PLItems", new[] { "PageLayoutId" });
            DropIndex("dbo.Pages", new[] { "PageLayoutId" });
            DropIndex("dbo.Menus", new[] { "MenuId" });
            DropIndex("dbo.Menus", new[] { "PageId" });
            DropTable("dbo.Sites");
            DropTable("dbo.PageContents");
            DropTable("dbo.PLItems");
            DropTable("dbo.PageLayouts");
            DropTable("dbo.Pages");
            DropTable("dbo.Menus");
        }
    }
}
