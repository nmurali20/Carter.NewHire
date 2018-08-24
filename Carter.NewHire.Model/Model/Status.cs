using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data.DataTransformation;
using Carter.NewHire.Model.Interface;

namespace Carter.NewHire.Model.Model
{
    public class Status : IStatus
    {

        [DataTableMap("Id")]
        public int id { get; set; }

        [DataTableMap("Status")]
        public string statusname { get; set; }
      
    }
}
