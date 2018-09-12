using CMS.Core.Services;
using CMS.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services
{
    public class Service
    {
        public static ILayoutService LayoutService
        {
            get
            {
                //Todo: Injection
                return (ILayoutService)new LayoutService();
            }
        }
        public static IPageService PageService
        {
            get
            {
                //Todo: Injection
                return (IPageService)new PageService();
            }
        }
        public static IMenuService MenuService
        {
            get
            {
                //Todo: Injection
                return (IMenuService)new MenuService();
            }
        }
        public static ISliderService SliderService
        {
            get { return (ISliderService)new SliderService(); }
        }

    }
}
