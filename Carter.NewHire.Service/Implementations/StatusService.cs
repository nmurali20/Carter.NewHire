using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.NewHire.Model.Interface;
using Carter.NewHire.Repository.Factories;
using Carter.NewHireUI.Service.Interfaces;

namespace Carter.NewHireUI.Service.Implementations
{
    public class StatusService: IStatusService
    {
        public IEnumerable<IStatus> GetStatuses()
        {
            return StatusRepositoryFactory.GetCurrent.GetStatuses();
        }
    }
}
