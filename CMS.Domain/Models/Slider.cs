using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        //public int PageId { get; set; }
        public bool IsActive { get; set; }
    }
}
