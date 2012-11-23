using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.EntityFramework;
using TweakToolkit.MVVM.Gateway;
using TweakToolkit.MVVM.Gateway.Exceptions;

namespace TweakToolkit.MVVM.Test.Gateway
{
    [TestClass]
    // ReSharper disable InconsistentNaming
    public class BasicGatewayUnitTest
    // ReSharper restore InconsistentNaming
    {
        [TestMethod]
        public void FullUseCaseTest()
        {
            int id;
            Cycle createdCycle;
            Cycle receivedCycle = null;

            using (var gw = ActivateGateway())
            {
                createdCycle = gw.Create<Cycle>();
                Assert.AreEqual(0, createdCycle.Gears);
                id = createdCycle.Id;
            }

            createdCycle.Gears = 3;
            Assert.AreEqual(3, createdCycle.Gears);

            using (var gw = ActivateGateway())
            {
                gw.Update<Cycle>(
                    cycle => cycle.Id == id,
                    currentCycle =>
                    {
                        receivedCycle = currentCycle;
                        currentCycle.Gears = createdCycle.Gears;
                    });

                var updatedCycle = gw.Read<Cycle>(cycle => cycle.Id == id).Single();

                Assert.AreSame(receivedCycle, updatedCycle);
                Assert.AreEqual(3, updatedCycle.Gears);
                Assert.AreEqual(createdCycle.Gears, updatedCycle.Gears);
            }
        }

        private static BasicGateway<TweakTestDataEntities> ActivateGateway()
        {
            return TestHelper.ActivateBasicCrudGateway();
        }

        #region Gateway Initialisation

        [ClassInitialize]
        public static void ResetDatabase(TestContext context)
        {
            using (var gw = ActivateGateway())
            {
                gw.ResetDatabase(true);
            }
        }

        [TestMethod]
        public void ActivateDbContextTest()
        {
            using (var gw = ActivateGateway())
            {
                Assert.IsNotNull(gw);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UnconfirmedDatabaseResetException))]
        public void UnconfirmedDatabaseResetTest()
        {
            using (var gw = ActivateGateway())
            {
                gw.ResetDatabase();
            }
        }

        #endregion Gateway Initialisation

        #region Create Tests

        [TestMethod]
        public void CreateKnownEntityTest()
        {
            using (var gw = ActivateGateway())
            {
                var createdCycle = gw.Create<Cycle>();
                Assert.IsNotNull(createdCycle);
                Assert.IsNotNull(createdCycle.Id);
                Assert.IsFalse(createdCycle.Id == 0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownEntityException))]
        public void CreateUnknownEntityTest()
        {
            using (var gw = ActivateGateway())
            {
                var createdCycle = gw.Create<UnknownClass>();
                Assert.IsNull(createdCycle);
            }
        }

        #endregion Create Tests

        #region Read Tests

        [TestMethod]
        public void ReadFromEmptyDatabaseTest()
        {
            using (var gw = ActivateGateway())
            {
                var cycle = gw.Read<Cycle>(c => c.Id == 0);
                Assert.AreEqual(0, cycle.Count());
            }
        }

        [TestMethod]
        public void ReadMultitpleEntitiesFromDatabaseTest()
        {
            using (var gw = ActivateGateway())
            {
                gw.ResetDatabase(true);
                gw.Create<Cycle>();
                gw.Create<Cycle>();
                var cycle = gw.Read<Cycle>(c => c.Id > 0);
                Assert.IsNotNull(cycle);
                Assert.AreEqual(2, cycle.Count());
            }
        }

        [TestMethod]
        public void ReadSingleEntityFromDatabaseTest()
        {
            using (var gw = ActivateGateway())
            {
                var createdCycle = gw.Create<Cycle>();
                var readCycle = gw.Read<Cycle>(c => c.Id == createdCycle.Id).SingleOrDefault();
                Assert.IsNotNull(readCycle);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadWithNullPredicateTest()
        {
            using (var gw = ActivateGateway())
            {
                gw.Read<Cycle>(null);
            }
        }

        [TestMethod]
        public void ReadWithoutPredicateTest()
        {
            using (var gw = ActivateGateway())
            {
                gw.ResetDatabase(true);
                gw.Create<Cycle>();
                gw.Create<Cycle>();
                var entities = gw.Read<Cycle>();
                Assert.AreEqual(2, entities.Count());
            }
        }

        #endregion Read Tests

        #region Update Tests

        [TestMethod]
        public void UpdateExistingEntityTest()
        {
            const int numGears = 3;
            using (var gw = ActivateGateway())
            {
                int id = gw.Create<Cycle>().Id;

                gw.Update<Cycle>(
                    cycle => cycle.Id == id,
                    currentCycle =>
                    {
                        currentCycle.Gears = numGears;
                    });

                var updatedCycle = gw.Read<Cycle>(cycle => cycle.Id == id).Single();
                Assert.AreEqual(numGears, updatedCycle.Gears);
            }
        }

        #endregion Update Tests
    }
}