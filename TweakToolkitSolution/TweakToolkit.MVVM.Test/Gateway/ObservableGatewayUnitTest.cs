using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.EntityFramework;
using TweakToolkit.MVVM.Gateway;

namespace TweakToolkit.MVVM.Test.Gateway
{
    [TestClass]
    public class ObservableGatewayUnitTest
    {
        private static ObservableGateway<TweakTestDataEntities> ActivateGateway()
        {
            return TestHelper.ActivateObservableCrudGateway();
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (var gw = ActivateGateway())
            {
                gw.Create<Cycle>();
            }
        }
    }
}