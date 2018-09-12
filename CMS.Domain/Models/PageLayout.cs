using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class PageLayout:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PLItem>  PLItems { get; set; }
    }
}
