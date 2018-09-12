using CMS.Common.Models.Page;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Interfaces
{
    public interface IPageService
    {
        void CreatePage(string namepage, int id, Array text, Array order);
        List<PageLayout> GetLayouts();
        List<PageDto> GetPage();
        List<PLItem> GetPLItems(int id);
        void AddContents(int id, Array text, Array order);
        List<ContentDto> GetContent(int id);
        void DeletePage(int id);
        List<ContentDto> GetPageContent(int id);//for UI
        void PublishPage(int id);
    }
}
