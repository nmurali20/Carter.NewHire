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
    public class NewHireRequestTestDetailsService : INewHireRequestTestDetailsService
    {
        public INewHireRequestTestDetails Insert(INewHireRequestTestDetails oModelIn)
        {
            return NewHireRequestTestDetailsRepositoryFactory.GetCurrent.Insert(oModelIn);
        }

        public void Update(Guid id, string status)
        {
            NewHireRequestTestDetailsRepositoryFactory.GetCurrent.Update(id,status);
        }

        public IEnumerable<INewHireRequestTestDetails> GetAllRequests()
        {
            return NewHireRequestTestDetailsRepositoryFactory.GetCurrent.GetAllRequests();
        }
    }
}
