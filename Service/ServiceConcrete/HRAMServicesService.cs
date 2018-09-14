using DomainModel;
using Insight.Database;
using Repository;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConcrete
{
    public class HRAMServicesService : IHRAMServicesService
    {
        IHRAMServicesRepository _IHRAMServicesRepository;

        public HRAMServicesService()
        {

            SqlInsightDbProvider.RegisterProvider();
            //string sqlConnection = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
            string sqlConnection = "Data Source=.;Initial Catalog=HRAMDashBoard;Integrated Security=True";
            DbConnection c = new SqlConnection(sqlConnection);
            _IHRAMServicesRepository = c.As<IHRAMServicesRepository>();
        }

        public bool UpdateServerServiceStatusBatch(WindowsServiceStatus windowsServiceStatus)
        {
            try
            {

                return this._IHRAMServicesRepository.UpdateServerServiceStatusBatch(windowsServiceStatus);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}
