using CMS.Common.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models.Page
{
    public class ContentDto:BaseDto
    {
        public int DivId { get; set; }
        public string Content { get; set; }
        public string Size { get; set; }
        public int PageID { get; set; }
        public string PageName { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
