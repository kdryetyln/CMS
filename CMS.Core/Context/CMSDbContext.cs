using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Context
{
    public class CMSDbContext:DbContext
    {
        public CMSDbContext():base("MyCMSConnStr")
        {

        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<PageLayout> PageLayouts { get; set; }
        public DbSet<PLItem> PLItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
