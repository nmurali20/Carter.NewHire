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
    public class NewHireRequestTestDetailsRepository : INewHireRequestTestDetailsRepository
    {
        public INewHireRequestTestDetails Insert(INewHireRequestTestDetails oModelIn)
        {
            DataSet results;
            SqlDatabase oSqlDatabase = new SqlDatabase(NewHireSettingsFactory.GetCurrent.NewHireConnectionString);
            using (
                DbCommand command = oSqlDatabase.GetStoredProcCommand("up_Insert_RequestTestDetails"))
            {
                var newGuid = Guid.NewGuid();
                Console.WriteLine(newGuid);
                oSqlDatabase.AddInParameter(command, "@id", SqlDbType.UniqueIdentifier, newGuid);
                oSqlDatabase.AddInParameter(command, "@EmployeeName", SqlDbType.VarChar, oModelIn.EmpName);
                oSqlDatabase.AddInParameter(command, "@RequestDate", SqlDbType.VarChar, oModelIn.Date);
                oSqlDatabase.AddInParameter(command, "@RequestTime", SqlDbType.VarChar, oModelIn.Time);
                oSqlDatabase.AddInParameter(command, "@Emailto", SqlDbType.VarChar, oModelIn.Emailto);
                oSqlDatabase.AddInParameter(command, "@Department", SqlDbType.VarChar, oModelIn.Department);
                oSqlDatabase.AddInParameter(command, "@CreatedBy", SqlDbType.VarChar, oModelIn.CreatedBy);
                oSqlDatabase.AddInParameter(command, "@Status", SqlDbType.VarChar, oModelIn.Status);

                results = oSqlDatabase.ExecuteDataSet(command);
            }
            if (results == null || results.Tables.Count <= 0)
            {
                return null;
            }
            if (results.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            return NewHireRequestTestDetailsDataMapperFactory.GetCurrent.MapSingle(results.Tables[0].Rows[0]);
        }

        public void Update(Guid id, string status)
        {
            DataSet results;
            SqlDatabase oSqlDatabase = new SqlDatabase(NewHireSettingsFactory.GetCurrent.NewHireConnectionString);
            using (
                DbCommand command = oSqlDatabase.GetStoredProcCommand("up_Update_Status"))
            {
                oSqlDatabase.AddInParameter(command, "@ID", SqlDbType.UniqueIdentifier, id);
                oSqlDatabase.AddInParameter(command, "@Status", SqlDbType.VarChar, status);
                results = oSqlDatabase.ExecuteDataSet(command);
            }
        }

        public IEnumerable<INewHireRequestTestDetails> GetAllRequests()
        {
            DataSet results;
            SqlDatabase oSqlDatabase = new SqlDatabase(NewHireSettingsFactory.GetCurrent.NewHireConnectionString);
            using (
                DbCommand command = oSqlDatabase.GetStoredProcCommand("up_GetAllRequests"))
            {
                results = oSqlDatabase.ExecuteDataSet(command);
            }
            if (results == null || results.Tables.Count <= 0)
            {
                return null;
            }
            return NewHireRequestTestDetailsDataMapperFactory.GetCurrent.MapDataSet(results, "table");
        }
    }
}
