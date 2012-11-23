using Microsoft.Practices.Unity;

namespace TweakToolkit.MVVM
{
    public class GatewayFactory
    {
        private static IUnityContainer _unityContainer;

        public static IUnityContainer UnityContainer
        {
            get { return _unityContainer ?? (_unityContainer = new UnityContainer()); }
            set { _unityContainer = value; }
        }
    }
}