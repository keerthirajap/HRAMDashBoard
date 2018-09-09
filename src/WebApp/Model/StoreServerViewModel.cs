using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class StoreServerViewModel 
    {
        public Int64 StoreServerId { get; set; }
        public Int64 StoreNo { get; set; }
        public Int64 HRAMStoreId { get; set; }
        public string StoreName { get; set; }

        public string ISSName { get; set; }
        public string ISSFullName { get; set; }
        public string ISSIpAddress { get; set; }
        public string ISSDomain { get; set; }

        public string Domain { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

        public Int64 UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int64 ModifiedBy { get; set; }

        //Server Status
        public Int64 ServerStatusBatchId { get; set; }
        public bool IsServerActive { get; set; }
        public int ServerResponseTime { get; set; }

    }
}
