using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Common.Models.Layout;
using CMS.Core.Services;

namespace CMS.Admin.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult GetCreatePage()
        {

            var list = Service.PageService.GetLayouts();
            return View("CreatePage",list);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePage(string namepage, int id,Array text, Array order)
        {
            Service.PageService.CreatePage(namepage, id, text, order);
            var list = Service.PageService.GetLayouts();
            return View("CreatePage", list);
        }

        public ActionResult EditPage()
        {
            var list = Service.PageService.GetPage();
            return View(list);
        }

        public PartialViewResult GetItems(int id)
        {
            var model = Service.PageService.GetContent(id);
            return PartialView("_DisplayLayoutItem", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContent(int id , Array text, Array order)
        {
            Service.PageService.AddContents(id, text, order);
            var list = Service.PageService.GetPage();
            return View("EditPage",list);
        }

        public ActionResult Preview(int id)
        {
            var list = Service.PageService.GetContent(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult DeletePage(int id)
        {
            Service.PageService.DeletePage(id);
            var model = Service.PageService.GetPage();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public PartialViewResult GetLayoutItems(int id)
        {
            var model = Service.PageService.GetPLItems(id);
            return PartialView("_GetPLItems",model);
        }
        [HttpPost]
        public ActionResult PublishPage(int id)
        {
            Service.PageService.PublishPage(id);
            return RedirectToAction("EditPage");
        }
    }
}