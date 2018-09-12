using CMS.Common.Models.General;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models.Layout
{
    public class LayoutDto :BaseDto
    {
        public LayoutDto()
        {
            this.Items = new List<PLItemDto>() { new PLItemDto() };
        }
        public string Name { get; set; }
        public IEnumerable<PLItemDto> Items { get; set; }
        public IEnumerable<PLItem> PLItems { get; set; }
    }
    
    public class PLItemDto :BaseDto
    {
        public PLItemDto()
        {
            Sizes = new List<ParametreDto>()
            {
                new ParametreDto{ Name="Small",Value="col-sm"},
                new ParametreDto{ Name="Medium",Value="col-md"},
                new ParametreDto{ Name="Lage",Value="col-lg"}
            };
        }
        public IEnumerable<ParametreDto> Sizes { get; set; }        
        public int SelectedColumn { get; set; }
        public string SizeValue { get; set; }
        public string Size { get; set; }
    }

}
