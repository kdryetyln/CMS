using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class Site:BaseEntity
    {
        public string MasterLayout { get; set; }
        public string SiteName { get; set; }
        public string SiteFooter { get; set; }
    }
}
