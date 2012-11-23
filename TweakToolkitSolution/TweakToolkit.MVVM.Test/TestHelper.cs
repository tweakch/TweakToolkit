using System;
using TweakToolkit.EntityFramework;
using TweakToolkit.MVVM.Gateway;

namespace TweakToolkit.MVVM.Test
{
    public class TestHelper
    {
        public static AdvancedGateway<TweakTestDataEntities> ActivateAdvancedCrudGateway()
        {
            return Activator.CreateInstance<AdvancedGateway<TweakTestDataEntities>>();
        }

        public static BasicGateway<TweakTestDataEntities> ActivateBasicCrudGateway()
        {
            return Activator.CreateInstance<BasicGateway<TweakTestDataEntities>>();
        }

        public static ObservableGateway<TweakTestDataEntities> ActivateObservableCrudGateway()
        {
            return Activator.CreateInstance<ObservableGateway<TweakTestDataEntities>>();
        }
    }
}