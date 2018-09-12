using CMS.Common.Models.Layout;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Interfaces
{
    public interface ILayoutService:IService
    {
        void NewLayout(string Name, Array List);
        IEnumerable<LayoutDto> List();
        LayoutDto GetLayouts(int id);
        void UpdateLayout(int id, Array List, Array Order);
    }
}
