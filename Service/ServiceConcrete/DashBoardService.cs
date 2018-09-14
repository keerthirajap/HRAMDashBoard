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
    public class DashBoardService : IDashBoardService
    {
        IDashBoardRepository _IDashBoardRepository;

        public DashBoardService()
        {

            SqlInsightDbProvider.RegisterProvider();
            //string sqlConnection = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
            string sqlConnection = "Data Source=.;Initial Catalog=HRAMDashBoard;Integrated Security=True";
            DbConnection c = new SqlConnection(sqlConnection);
            _IDashBoardRepository = c.As<IDashBoardRepository>();
        }

        public DashBoardModel GetDashBoardWidgetDetails()
        {
            return this._IDashBoardRepository.GetDashBoardWidgetDetails();
        }

    }
}
