using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class StoreServerModel
    {
        public Int64 StoreServerId { get; set; }
        public Int64 StoreNo { get; set; }
        public Int64 HRAMStoreId { get; set; }
        public string StoreName { get; set; }
        public string Domain { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int64 ModifiedBy { get; set; }

        //Server Status
        public Int64 ServerStatusBatchId { get; set; }
        public bool IsServerActive { get; set; }


    }
}
