using CMS.Common.Models.Layout;
using CMS.Common.Models.Menu;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Interfaces
{
    public interface IMenuService:IService
    {
        List<Page> GetPage();
        void CreateMenu(int id);
        List<MenuDto> GetMenu();
        void CreateSubMenu(int menuid, int subid);
        List<MenuDto> GetSubItem(int id);
        string GetMenuRecursion();
        void AddChildItem(Menu childItem, StringBuilder strBuilder);
        void RemoveMenu(int id);

    }
}
