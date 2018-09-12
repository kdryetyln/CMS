using CMS.Common.Models.Layout;
using CMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Admin.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        #region Layout operation
        public ActionResult Insert()
        {
            var model = new LayoutDto();
            TempData["InsertModel"] = model;
            return View(model);
        }
        public ActionResult NewLayout(string Name, Array List)
        {
            Service.LayoutService.NewLayout(Name, List);
            var model = new LayoutDto();
            TempData["InsertModel"] = model;
            return View("Insert",model);
        }

        public ActionResult List()
        {
            var list = Service.LayoutService.List();
            return View("LayoutList",list);
        }

        #endregion

        public ActionResult Update(int id)
        {
            var model = Service.LayoutService.GetLayouts(id);
            return View("UpdateLayout",model);
        }
        public ActionResult UpdateLayout(int id,Array List, Array Order)
        {
            Service.LayoutService.UpdateLayout(id, List, Order);
            var model = Service.LayoutService.GetLayouts(id);
            return View("UpdateLayout", model);
        }
    }
}