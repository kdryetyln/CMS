using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class PageContent:BaseEntity
    {
        public Page Page { get; set; }
        public int PageId { get; set; }

        public string Content { get; set; }
        public int divId { get; set; }
    }
}
