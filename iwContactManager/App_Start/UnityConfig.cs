using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using iwContactManager.Services;
using iwContactManager.Controllers;
using iwContactManager.Services.EntityFramework;

namespace iwContactManager
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<IController, CmController>("Cm");

            container.RegisterType<IListService, ListService>();

            container.RegisterType<IValidatorService, ValidatorService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}