using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweakToolkit.EntityFramework.Test
{
    [TestClass]
    public class GatewayHouseTest
    {
        [TestMethod]
        public void AddInvalidHouseTest()
        {
            var newHouse = TestHelper.GetHouse();

            //Delete all rooms from the house to make it invalid
            newHouse.Room.Clear();

            var gatewayHouse = default(House);

            using (var gateway = new SimpleGatewayImpl())
            {
                try
                {
                    gatewayHouse = (House)gateway.Create(new CreateMessage(newHouse));
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }

            Assert.AreSame(newHouse, gatewayHouse);

            using (var db = new TweakTestDataEntities())
            {
                Assert.IsNotNull(db.HouseSet.ToList().FirstOrDefault(house => house.Address.Equals(newHouse.Address)));
            }
        }

        [TestMethod]
        public void AddValidHouseTest()
        {
            var newHouse = TestHelper.GetHouse();
            var gatewayHouse = default(House);

            using (var gateway = new SimpleGatewayImpl())
            {
                try
                {
                    gatewayHouse = (House)gateway.Create(new CreateMessage(newHouse));
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }

            Assert.AreSame(newHouse, gatewayHouse);

            using (var db = new TweakTestDataEntities())
            {
                Assert.IsNotNull(db.HouseSet.ToList().FirstOrDefault(house => house.Address.Equals(newHouse.Address)));
            }
        }

        [TestMethod]
        public void RemoveEntityTest()
        {
            using (var gateway = new SimpleGatewayImpl())
            {
                gateway.Create(new CreateMessage(TestHelper.GetHouse()));
            }
        }

        [TestInitialize]
        public void ResetDatabase()
        {
            using (var db = new TweakTestDataEntities())
            {
                db.Database.Delete();
                db.SaveChanges();
                db.Database.Create();
                db.SaveChanges();
            }
        }
    }
}