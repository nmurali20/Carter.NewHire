using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carter.NewHire.Infrastructure.Configuration
{
    public interface INewHireSettings
    {
        string NewHireConnectionString { get; }
    }
}
