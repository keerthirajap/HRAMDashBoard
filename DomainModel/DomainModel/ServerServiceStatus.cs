using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class ServerServiceStatus
    {
        public Int64 StoreNo { get; set; }
        public Int64 HRAMServiceConfigId { get; set; }


        public string ServiceName { get; set; }

        public bool IsServiceActive { get; set; }

        public Int64 UserId { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int64 ModifiedBy { get; set; }
    }
}
