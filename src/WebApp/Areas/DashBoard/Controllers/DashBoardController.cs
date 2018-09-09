using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceInterface;
using AutoMapper;
using WebApp.Areas.DashBoard.Models;
using DomainModel;
using TimeAgo;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    [Route("DashBoard")]
    public class DashBoardController : Controller
    {
        IDashBoardService _IDashBoardService;

        private readonly IMapper _mapper;

        public DashBoardController(IDashBoardService iDashBoardService, IMapper mapper)
        {
            this._IDashBoardService = iDashBoardService;
            _mapper = mapper;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "DashBoard";
            var vv = this._IDashBoardService.GetDashBoardWidgetDetails();
            DashBoardViewModel dashBoardViewModel = new DashBoardViewModel();
            DashBoardModel dashBoardModel = new DashBoardModel();

            dashBoardModel = this._IDashBoardService.GetDashBoardWidgetDetails();
            this._mapper.Map(dashBoardModel, dashBoardViewModel);
            var vssv = dashBoardViewModel.ServerStatusCheckedOn.TimeAgo();

            dashBoardViewModel.ServerStatusCheckedAgo = "Status Checked " + dashBoardViewModel.ServerStatusCheckedOn.TimeAgo().ToString();
            //dashBoardViewModel.ServerStatusCheckedAgo = dashBoardViewModel.ServerStatusCheckedAgo.Replace(" ", "&nbsp;");
            return View("Index", dashBoardViewModel);
        }
    }
}
