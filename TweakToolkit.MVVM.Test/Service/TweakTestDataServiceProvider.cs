using System;
using Microsoft.Practices.Unity;
using TweakToolkit.EntityFramework;
using TweakToolkit.MVVM.Gateway;
using TweakToolkit.MVVM.Model;
using TweakToolkit.MVVM.Service;

namespace TweakToolkit.MVVM.Test.Service
{
    public class TweakTestDataServiceProvider : IServiceProvider
    {
        private readonly IUnityContainer unityContainer = new UnityContainer();

        public TweakTestDataServiceProvider()
        {
            unityContainer.RegisterType<IGateway, ObservableGateway<TweakTestDataEntities>>();
            RegisterService<CycleModel, CycleModelService>();
        }

        private void RegisterService<TModel, TModelService>() where TModelService : IGatewayService
        {
            RegisterService<TModelService>(GetName<TModel>());
        }

        public object GetService(Type serviceType)
        {
            return unityContainer.Resolve<IGatewayService>(GetName(serviceType));
        }

        private static string GetName<T>()
        {
            return GetName(typeof(T));
        }

        private static string GetName(Type type)
        {
            return type.Name;
        }

        private void RegisterService<TModelService>(string name) where TModelService : IGatewayService
        {
            unityContainer.RegisterType<IGatewayService, TModelService>(name);
        }
    }
}