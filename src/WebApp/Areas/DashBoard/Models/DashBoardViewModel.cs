using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.DashBoard.Models
{
    public class DashBoardViewModel
    {
        //Server Status
        public Int64 ServerStatusBatchId { get; set; }
        public Int64 TotalNoHRAMISS02Servers { get; set; }
        public Int64 TotalNoHRAMISS02ServersActive { get; set; }
        public Int64 TotalNoHRAMISS02ServersInActive { get; set; }
        public DateTime ServerStatusCheckedOn { get; set; }
        public string ServerStatusCheckedAgo { get; set; }

    }
}
