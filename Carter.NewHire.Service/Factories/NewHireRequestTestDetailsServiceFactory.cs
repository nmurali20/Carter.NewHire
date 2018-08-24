using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data;
using Carter.NewHireUI.Service.Interfaces;

namespace Carter.NewHireUI.Service.Factories
{
    public class NewHireRequestTestDetailsServiceFactory
    {
        /// <summary>
        /// The _company repository
        /// </summary>
        private static INewHireRequestTestDetailsService _service;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            _service = SimpleInjectorFactory.GetCurrentContainer.GetInstance<INewHireRequestTestDetailsService>();
        }
        /// <summary>
        /// Gets the get current.
        /// </summary>
        /// <value>The get current.</value>
        public static INewHireRequestTestDetailsService GetCurrent
        {
            get
            {
                if (_service == null)
                {
                    Initialize();
                }
                return _service;
            }
        }
    }
}
