using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data.DataTransformation;
using Carter.NewHire.Model.Interface;

namespace Carter.NewHire.Model.Model
{
    public class NewHireRequestTestDetails : INewHireRequestTestDetails
    {
        [DataTableMap("Id")]
        public System.Guid Id { get; set; }

        [DataTableMap("EmployeeName")]
        public System.String EmpName { get; set; }

        [DataTableMap("RequestDate")]
        public System.String Date { get; set; }

        [DataTableMap("RequestTime")]
        public System.String Time { get; set; }

        [DataTableMap("CreatedBy")]
        public System.String CreatedBy { get; set; }

        [DataTableMap("Emailto")]
        public System.String Emailto { get; set; }

        [DataTableMap("Department")]
        public System.String Department { get; set; }

        [DataTableMap("Status")]
        public System.String Status { get; set; }
    }
}
