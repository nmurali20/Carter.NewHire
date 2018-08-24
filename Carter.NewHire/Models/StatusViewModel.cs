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
    public class StatusViewModel
    {
        public StatusViewModel()
        { }
        public StatusViewModel(IStatus oModelIn)
        {
            id = oModelIn.id;
            statusname = oModelIn.statusname;
           
        }
        public IStatus toModel()
        {
            var result = SimpleInjectorFactory.GetCurrentContainer.GetInstance<IStatus>();
            result.id = this.id;
            result.statusname = this.statusname;
            return result;
        }

        public System.Int32 id { get; set; }
        public System.String statusname { get; set; }

     

    }
}