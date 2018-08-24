using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework;
using Carter.Framework.Data;
using Carter.NewHire.Model.Interface;

namespace NewHireUI.Models
{
    public class NewHireRequestTestViewModel : INewHireRequestTestDetails
    {
        public NewHireRequestTestViewModel()
        {
        }

        public NewHireRequestTestViewModel(INewHireRequestTestDetails oModelIn)
        {
            Id = oModelIn.Id;
            EmpName = oModelIn.EmpName;
            Date = oModelIn.Date;
            Time = oModelIn.Time;
            CreatedBy = oModelIn.CreatedBy;
            Emailto = oModelIn.Emailto;
            Department = oModelIn.Department;
            Status = oModelIn.Status;
        }

        public INewHireRequestTestDetails toModel()
        {
            var result = SimpleInjectorFactory.GetCurrentContainer.GetInstance<INewHireRequestTestDetails>();
            result.Id = this.Id;
            result.EmpName = this.EmpName;
            result.Date = this.Date;
            result.Time = this.Time;
            result.Emailto = this.Emailto;
            result.Department = this.Department;
            result.CreatedBy = this.CreatedBy;
            result.Status = this.Status;
            return result;
        }

        public System.Guid Id { get; set; }

        public string EmpName { get; set; }

        //public System.DateTime Date { get; set; }

        //public System.DateTime Time { get; set; }
        public string Date { get; set; }

        public string Time { get; set; }

        public System.String CreatedBy { get; set; }

        public System.String Emailto { get; set; }

        public System.String Department { get; set; }

        //[UIHint("_Status")]
        public System.String Status { get; set; }
    }
}
