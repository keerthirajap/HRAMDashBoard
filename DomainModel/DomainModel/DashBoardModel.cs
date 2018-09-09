using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class DashBoardModel
    {
        //Server Status
        public Int64 ServerStatusBatchId { get; set; }
        public Int64 TotalNoHRAMISS02Servers { get; set; }

        public Int64 TotalNoHRAMISS02ServersActive { get; set; }

        public Int64 TotalNoHRAMISS02ServersInActive { get; set; }

        public DateTime ServerStatusCheckedOn { get; set; }



    }
}
