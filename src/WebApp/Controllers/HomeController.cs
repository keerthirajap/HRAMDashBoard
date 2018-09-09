using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceInterface;
using WebApp.Model;
using DomainModel;
using AutoMapper;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IStoreServerService _IStoreServerService;

        private readonly IMapper _mapper;

        public HomeController(IStoreServerService iStoreServerService, IMapper mapper)
        {
            this._IStoreServerService = iStoreServerService;
            _mapper = mapper;

        }
        public IActionResult Index()
        {

            var i = 0;
            var result = 42 / i;

            var vv = this._IStoreServerService.GetStoresDetails();
            List<StoreViewModel> storesViewModelList = new List<StoreViewModel>();
            List<StoreModel> storesList = new List<StoreModel>();
            storesList = this._IStoreServerService.GetStoresDetails();

            this._mapper.Map(storesList, storesViewModelList);

          
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
