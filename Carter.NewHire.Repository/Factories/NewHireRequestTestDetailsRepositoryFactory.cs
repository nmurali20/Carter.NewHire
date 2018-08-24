using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data;
using Carter.NewHire.Repository.Interfaces;


namespace Carter.NewHire.Repository.Factories
{
    public class NewHireRequestTestDetailsRepositoryFactory
    {
        /// <summary>
        /// The _company repository
        /// </summary>
        private static INewHireRequestTestDetailsRepository _repository;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            _repository = SimpleInjectorFactory.GetCurrentContainer.GetInstance<INewHireRequestTestDetailsRepository>();
        }
        /// <summary>
        /// Gets the get current.
        /// </summary>
        /// <value>The get current.</value>
        public static INewHireRequestTestDetailsRepository GetCurrent
        {
            get
            {
                if (_repository == null)
                {
                    Initialize();
                }
                return _repository;
            }
        }
    }
}
