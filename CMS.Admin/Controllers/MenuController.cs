using CMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult GetPages()
        {
            var model = Service.MenuService.GetPage();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateMenu(int id)
        {
            Service.MenuService.CreateMenu(id);
            return RedirectToAction("GetPages");
        }

        public PartialViewResult GetMenu()
        {
            var model = Service.MenuService.GetMenu();
            return PartialView("_GetMenu",model);
        }
        public PartialViewResult GetMenu2()
        {
            var model = Service.MenuService.GetMenu();
            return PartialView("_GetMenu2", model);
        }

        [HttpPost]
        public ActionResult CreateSubMenu(int menuid,int subid)
        {
            Service.MenuService.CreateSubMenu(menuid, subid);
            return RedirectToAction("GetPages");
        }

        [HttpPost]
        public JsonResult GetMenuResult(int id)
        {
            var menuItem = Service.MenuService.GetSubItem(id);
            return Json(menuItem, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var menuUi = Service.MenuService.GetMenuRecursion();
            ViewBag.Menu = menuUi;
            return View();
        }

        [HttpPost]
        public ActionResult RemoveMenu(int id)
        {
            Service.MenuService.RemoveMenu(id);
            return RedirectToAction("GetPages");
        }
    }
}