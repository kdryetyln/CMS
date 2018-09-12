namespace CMS.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sliders", "PageId", "dbo.Pages");
            DropIndex("dbo.Sliders", new[] { "PageId" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Slider_Image");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Slider_Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SliderId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Sliders", "PageId");
            AddForeignKey("dbo.Sliders", "PageId", "dbo.Pages", "Id", cascadeDelete: true);
        }
    }
}
