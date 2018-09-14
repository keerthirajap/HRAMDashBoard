using DomainModel;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStoreServerRepository
    {

        [Sql("SELECT * FROM [dbo].[StoreDetails]")]
        List<StoreModel> GetStoresDetails();


        [Sql("SELECT * FROM [dbo].[StoreServerDetails]")]
        List<StoreServerModel> GetStoresServerDetails();

        [Sql("P_GenerateServerServiceStatusBatch")]
        Int64 GenerateServerServiceStatusBatch(StoreServerModel storeServerDetails);

        [Sql("P_UpdateServerServiceStatusBatch")]
        bool UpdateServerServiceStatusBatch(List<StoreServerModel> T_ServerStatusDetails);


        [Sql("SELECT *  FROM [dbo].[HRAMServiceConfig]")]
        List<ServerServiceStatus> GetWindowsServiceDetails();

        [Sql("P_GenerateWindowsServiceStatusBatch")]
        Int64 GenerateWindowsServiceStatusBatch(StoreServerModel storeServerDetails);

    }
}
