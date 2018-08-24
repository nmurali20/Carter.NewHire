using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data;
using Carter.Framework.Data.DataTransformation;
using Carter.NewHire.Model.Interface;

namespace Carter.NewHire.Repository.Enterprise.DataMapperFactories
{
    public class NewHireRequestTestDetailsDataMapperFactory
    {
        private static IMapper<INewHireRequestTestDetails> _mapper;
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            _mapper = SimpleInjectorFactory.GetCurrentContainer.GetInstance<IMapper<INewHireRequestTestDetails>>();
        }
        /// <summary>
        /// Gets the get current.
        /// </summary>
        /// <value>The get current instance.</value>
        public static IMapper<INewHireRequestTestDetails> GetCurrent
        {
            get
            {
                if (_mapper == null)
                {
                    Initialize();
                }
                return _mapper;
            }
        }
    }
}
