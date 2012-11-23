using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.EntityFramework;
using TweakToolkit.MVVM.Gateway;

namespace TweakToolkit.MVVM.Test.Gateway
{
    [TestClass]
    public class AdvancedGatewayUnitTest
    {
        private static AdvancedGateway<TweakTestDataEntities> ActivateGateway()
        {
            return TestHelper.ActivateAdvancedCrudGateway();
        }

        [ClassInitialize]
        public static void ResetDatabase(TestContext context)
        {
            using (var gw = ActivateGateway())
            {
                gw.ResetDatabase(true);
            }
        }

        [TestMethod]
        public void ReadByIdTest()
        {
            using (var gw = ActivateGateway())
            {
                var id = gw.Create<Cycle>().Id;
                var cycle = gw.ReadById<Cycle>(id);
                Assert.IsNotNull(cycle);
            }
        }

        [TestMethod]
        public void UpdateByIdTest()
        {
            const short numGears = 9;
            Cycle updated;
            using (var gw = ActivateGateway())
            {
                gw.ResetDatabase(true);
                var id = gw.Create<Cycle>().Id;
                gw.UpdateById<Cycle>(id, cycle => { cycle.Gears = numGears; });
                updated = gw.ReadById<Cycle>(id);
            }
            Assert.AreEqual(numGears, updated.Gears);
        }
    }
}