using CMS.Common.Models.General;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models.Page
{
    public class PageDto:BaseDto
    {
        public string PageName { get; set; }
        public string LayoutName { get; set; }
        public int LayoutId { get; set; }
        public int PageId { get; set; }
        public bool IsPublish { get; set; }

    }
    public class PageContentDto : BaseDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int divs { get; set; }
        public string classtype { get; set; }
    }
    public class PageUpdateDto : BaseDto
    {
        public int Pageid { get; set; }
        public int LayoutId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int divs { get; set; }
        public string classtype { get; set; }
    }
    public class SliderDto : BaseDto
    {
        public string Name { get; set; }
    }
    public class PagePreviewDto : BaseDto
    {
        public List<SliderDto> SD { get; set; }
        public List<PageContentDto> PCD { get; set; }
    }
}
