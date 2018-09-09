using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerStatusChecker
{
    class ServiceCore
    {
        private readonly IScheduler _scheduler;

        public ServiceCore(IScheduler scheduler)
        {
            if (scheduler == null) throw new ArgumentNullException(nameof(scheduler));

            _scheduler = scheduler;
        }

        public bool Start()
        {

            if (!_scheduler.IsStarted)
            {
                _scheduler.Start();
            }
            return true;
        }

        public bool Stop()
        {
            _scheduler.Shutdown(true);

            return true;
        }
    }
}
