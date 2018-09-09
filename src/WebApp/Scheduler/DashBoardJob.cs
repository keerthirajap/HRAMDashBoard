using Autofac;
using AutoMapper;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Scheduler
{
    public class DashBoardJob 
    {
        private readonly ILifetimeScope _jobScope;
        private readonly IMapper _mapper;
        IStoreServerService _IStoreServerService;

        public DashBoardJob(IStoreServerService iStoreServerService, IMapper mapper, ILifetimeScope scope)
        {
            this._IStoreServerService = iStoreServerService;
            _mapper = mapper;
            _jobScope = scope.BeginLifetimeScope();
        }

        public void Execute()
        {
            var vv = this._IStoreServerService.GetStoresDetails();
            Debug.WriteLine("DashBoardJob");
        }

        public void RecouringExecute()
        {
            var vv = this._IStoreServerService.GetStoresDetails();
            Debug.WriteLine("RecouringExecute " + DateTime.Now.ToString() + " " + vv.Count.ToString());
        }
        public void Dispose()
        {
            _jobScope.Dispose();
        }

    }
}
