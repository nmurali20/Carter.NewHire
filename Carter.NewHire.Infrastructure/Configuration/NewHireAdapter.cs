using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Carter.NewHire.Infrastructure.Configuration
{
    public class NewHireAdapter : INewHireSettings
    {
        public string NewHireConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["NewHireConnection"] == null)
                {
                    throw new Exception("NewHire Connection string is null or missing");
                }
                return ConfigurationManager.ConnectionStrings["NewHireConnection"].ConnectionString;
            }
        }

    }
}
