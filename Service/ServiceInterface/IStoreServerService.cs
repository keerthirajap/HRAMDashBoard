using DomainModel;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    public interface IStoreServerService
    {
        List<StoreModel> GetStoresDetails();

        List<StoreServerModel> GetStoresServerDetails();

        Int64 GenerateServerServiceStatusBatch(StoreServerModel storeServerDetails);
    }
}
