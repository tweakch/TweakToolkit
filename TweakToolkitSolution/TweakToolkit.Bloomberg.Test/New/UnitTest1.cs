using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.Bloomberg.New;

namespace TweakToolkit.Bloomberg.Test.New
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTokenCreation()
        {
            SubscriptionSession session = new Bloomberg.New.SubscriptionSession();
            var token = session.GenerateToken();
            Assert.IsNotNull(token);
        }
    }
}
