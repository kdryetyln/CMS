using CMS.Common.Models.Page;
using CMS.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMS.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult _menu()
        {
            string url = "http://localhost:57680/api/CmsApi/GetMenu";
            WebClient client = new WebClient();
            //client.Headers.Add("user-agent")
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject<string>(json);
            ViewBag.Menu = model;
            return PartialView();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Preview(int id)
        {
            string url = "http://localhost:57680/api/CmsApi/Preview/" + id;
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject<List<ContentDto>>(json);
            return View(model);
        }

        [HttpGet]
        public ActionResult GetSlider()
        {
            
            string url = "http://localhost:57680/api/CmsApi/GetSlider";
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject<List<Slider>>(json);
            return View(model);
        }

    }
}