using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.NewHire.Infrastructure.Configuration;
using Carter.NewHire.Repository.Enterprise.DataMapperFactories;
using Carter.NewHire.Repository.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Carter.NewHire.Model.Interface;

namespace Carter.NewHire.Repository.Enterprise
{
    public class StatusRepository : IStatusRepository
    {
        public IEnumerable<IStatus> GetStatuses()
        {
           DataSet results;
            SqlDatabase oSqlDatabase = new SqlDatabase(NewHireSettingsFactory.GetCurrent.NewHireConnectionString);
            using (
                DbCommand command = oSqlDatabase.GetStoredProcCommand("up_Get_AllStatus"))
            {
                results = oSqlDatabase.ExecuteDataSet(command);
            }

            if (results == null || results.Tables.Count <= 0)
            {
                return null;
            }
            return StatusDataMapperFactory.GetCurrent.MapDataSet(results, "table");
        }
    }
}
