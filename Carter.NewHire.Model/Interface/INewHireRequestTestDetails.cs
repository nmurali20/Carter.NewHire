using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carter.NewHire.Model.Interface
{
    public interface INewHireRequestTestDetails
    {
        System.Guid Id { get; set; }

        System.String EmpName { get; set; }

        System.String Date { get; set; }
        //System.DateTime Date { get; set; }

        System.String Time { get; set; }
        //System.DateTime Time { get; set; }

        System.String CreatedBy { get; set; }

        System.String Emailto { get; set; }

        System.String Department { get; set; }

        System.String Status { get; set; }
    }
}
