using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class WindowsServiceStatus
    {
        public Int64 HeartBeatId { get; set; }
        public string ServiceName { get; set; }
        public string RunningServerName { get; set; }

        public Int64 UserId { get; set; }

        public DateTime HeartBeatValue { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int64 ModifiedBy { get; set; }
    }
}
