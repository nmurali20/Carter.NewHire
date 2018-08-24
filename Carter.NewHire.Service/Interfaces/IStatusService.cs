using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.NewHire.Model.Interface;

namespace Carter.NewHireUI.Service.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<IStatus> GetStatuses();
    }
}
