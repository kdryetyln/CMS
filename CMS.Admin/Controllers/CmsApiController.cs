using CMS.Common.Models.Page;
using CMS.Core.Services;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Admin.Controllers
{
    public class CmsApiController : ApiController
    {
        // GET: api/CmsApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CmsApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CmsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CmsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CmsApi/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public List<PageDto> GetPages()
        {
            var pagelist = Service.PageService.GetPage();
            return pagelist;
            //pageList
        }
        [HttpGet]
        public string GetMenu()
        {
            var menuList = Service.MenuService.GetMenuRecursion();
            return menuList;
        }
        [HttpGet]
        public List<ContentDto> Preview(int id)
        {
            var list = Service.PageService.GetPageContent(id);
            return list;
        }

        [HttpGet]
        public List<Slider> GetSlider()
        {
            var model = Service.SliderService.ActiveImage();
            return model;
        }
    }
}
