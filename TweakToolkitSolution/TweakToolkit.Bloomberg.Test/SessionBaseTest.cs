using TweakToolkit.Bloomberg.New;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bloomberglp.Blpapi;
using System.Threading;

namespace TweakToolkit.Bloomberg.Test
{
    
    
    /// <summary>
    ///This is a test class for SessionBaseTest and is intended
    ///to contain all SessionBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SessionBaseTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual SessionBase CreateSessionBase()
        {
            SessionBase target = new SubscriptionSession();
            return target;
        }

        /// <summary>
        ///A test for GenerateToken
        ///</summary>
        [TestMethod()]
        public void GenerateTokenTest()
        {
            SessionBase target = CreateSessionBase(); 
            CorrelationID actual;
            actual = target.GenerateToken();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Stop
        ///</summary>
        [TestMethod()]
        public void StopTest()
        {
            SessionBase target = CreateSessionBase(); // TODO: Initialize to an appropriate value
            target.Stop();
        }
        bool wait = true;

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            SessionBase target = CreateSessionBase(); // TODO: Initialize to an appropriate value
            target.Start();
            target.Behaviour.ServiceOpened += SessionServiceOpened;
            
            while (wait)
            {
                Thread.Sleep(1000);
            }
        }

        private void SessionServiceOpened(object sender, ServiceOpenedEventArgs args)
        {
            Assert.IsNotNull(args.Service);
            wait = false;
        }
    }
}
