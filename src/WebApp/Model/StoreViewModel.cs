using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class StoreViewModel
    {
        public Int64 StoreNo1 { get; set; }

        public Int64 StoreServerId { get; set; }
        public Int64 StoreNo { get; set; }
        public Int64 HRAMStoreId { get; set; }
        public string StoreName { get; set; }
        public string Domain { get; set; }
        public string Comments { get; set; }
        public bool IsStoreActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int64 ModifiedBy { get; set; }
    }
}
