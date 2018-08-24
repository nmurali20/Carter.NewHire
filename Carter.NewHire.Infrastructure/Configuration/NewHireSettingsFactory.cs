using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data;

namespace Carter.NewHire.Infrastructure.Configuration
{
    public class NewHireSettingsFactory
    {
        private static INewHireSettings _newHireSettings;

        public static void Initialize()
        {
            _newHireSettings = SimpleInjectorFactory.GetCurrentContainer.GetInstance<INewHireSettings>();
        }

        public static INewHireSettings GetCurrent
        {
            get
            {
                if (_newHireSettings == null)
                {
                    Initialize();
                }

                return _newHireSettings;
            }
        }
    }
}
