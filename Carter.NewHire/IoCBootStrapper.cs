using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Carter.Framework.ADProvider;
using Carter.Framework.ADProvider.Configuration;
using Carter.Framework.Data;
using Carter.Framework.Data.DataTransformation;
using Carter.Framework.Email;
using Carter.Framework.Email.Configuration;
using Carter.NewHire.Infrastructure.Configuration;
using Carter.NewHire.Model;
using Carter.NewHire.Model.Interface;
using Carter.NewHire.Model.Model;
using Carter.NewHire.Repository.Enterprise;
using Carter.NewHire.Repository.Interfaces;
using Carter.NewHireUI.Service.Interfaces;
using Carter.NewHireUI.Service.Implementations;
using Carter.NewHireUI.Service;
using SimpleInjector;
using Container = SimpleInjector.Container;


namespace NewHireUI
{
    public class IoCBootStrapper
    {
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: http://bit.ly/YE8OJj.
            var container = new Container();

            InitializeContainer(container);

            container.Verify();

            SimpleInjectorFactory.Initialize(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<INewHireSettings, NewHireAdapter>();

            container.Register<INewHireRequestTestDetails, NewHireRequestTestDetails>();
            container.Register<IMapper<INewHireRequestTestDetails>, SimpleInjectorMapper<INewHireRequestTestDetails>>();
            container.Register<INewHireRequestTestDetailsRepository, NewHireRequestTestDetailsRepository>();
            container.Register<INewHireRequestTestDetailsService, NewHireRequestTestDetailsService>();

            container.Register<IStatus, Status>();
            container.Register<IMapper<IStatus>, SimpleInjectorMapper<IStatus>>();
            container.Register<IStatusRepository, StatusRepository>();
            container.Register<IStatusService, StatusService>();

            container.Register<IEmailApplicationSettings, EmailApplicationSettings>();
            container.Register<IEmailService, ExchangeEmailService>();

            container.Register<IADProviderApplicationSettings, ADProviderApplicationSettings>();
            container.Register<IActiveDirectoryService, ActiveDirectoryService>();
            container.Register<IActiveDirectoryUser, ActiveDirectoryUser>();
        }
    }
}