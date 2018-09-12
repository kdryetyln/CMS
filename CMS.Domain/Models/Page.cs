using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class Page:BaseEntity
    {
        public string Name { get; set; }
        public PageLayout PageLayout { get; set; }
        public int PageLayoutId { get; set; }
        public string Slug { get; set; }//adres çubuğunda ne yazacağı
        public string meta { get; set; }
        public bool IsPublish { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
