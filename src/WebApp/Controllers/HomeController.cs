using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceInterface;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IStoreServerService _IStoreServerService;
        public HomeController(IStoreServerService iStoreServerService)
        {
            this._IStoreServerService = iStoreServerService;
        }
        public IActionResult Index()
        {
            var vv = this._IStoreServerService.GetStoresDetails();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
