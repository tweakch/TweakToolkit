using TweakToolkit.Bloomberg.New;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bloomberglp.Blpapi;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace TweakToolkit.Bloomberg.Test
{
    
    
    /// <summary>
    ///This is a test class for SubscriptionSessionTest and is intended
    ///to contain all SubscriptionSessionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SubscriptionSessionTest
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


        /// <summary>
        ///A test for SubscriptionSession Constructor
        ///</summary>
        [TestMethod()]
        public void SubscriptionSessionConstructorTest()
        {
            SubscriptionBehaviour behaviour = new SubscriptionBehaviour();
            SubscriptionSession target = new SubscriptionSession(behaviour);
            
            target.SubscriptionChanged += (sessn, subArgs) =>
            {
                var builder = new StringBuilder();

                foreach (var item in subArgs.FieldData)
                {
                    builder.AppendFormat("{0} to {1}{2}", item.Key, item.Value, Environment.NewLine);
                }
                var msg = string.Format("{0}: {1} changed:{3}{2}", subArgs.Id, subArgs.Topic, builder.ToString(), Environment.NewLine);
                Console.WriteLine(msg);
            };

            behaviour.ServiceOpened += (sender, args) =>
            {
                List<Subscription> list = new List<Subscription>();

                list.Add(new Subscription("XS0585380602@GSSD CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18595973)));
                list.Add(new Subscription("XS0788176070@RBCD CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18803310)));
                list.Add(new Subscription("XS0799547137@RABS CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18044452)));
                list.Add(new Subscription("CH0189535229@UBSF CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19953522)));
                list.Add(new Subscription("XS0806746789@HSED CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19043879)));
                list.Add(new Subscription("XS0807559454@HSED CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19055243)));
                list.Add(new Subscription("XS0807582605@RABS CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18044484)));
                list.Add(new Subscription("XS0816364433@HSED CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19238472)));
                list.Add(new Subscription("CH0187367930@EFGZ CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18736793)));
                list.Add(new Subscription("XS0815510812@HSED CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19210627)));
                list.Add(new Subscription("CH0188287632@CSZE CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18828763)));
                list.Add(new Subscription("CH0148735324@SARA CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(14873532)));
                list.Add(new Subscription("CH0148735332@SARA CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(14873533)));
                list.Add(new Subscription("CH0187368110 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18736811)));
                list.Add(new Subscription("CH0141501947@VONT CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(14150194)));
                list.Add(new Subscription("CH0141501954@exch CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(14150195)));
                list.Add(new Subscription("GB00B8MKWW97 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(10474448)));
                list.Add(new Subscription("XS0826054289 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18293952)));
                list.Add(new Subscription("XS0826056144 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19399264)));
                list.Add(new Subscription("CH0193303010 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19330301)));
                list.Add(new Subscription("CH0194083454 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19408345)));
                list.Add(new Subscription("XS0826535030@RABS CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18044543)));
                list.Add(new Subscription("FR0011315654@EXA CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19376476)));
                list.Add(new Subscription("CH0182602141@EFGZ CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18260214)));
                list.Add(new Subscription("XS0827216739 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19424709)));
                list.Add(new Subscription("CH0190890969@EFGZ CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19089096)));
                list.Add(new Subscription("FR0011315670@EXA CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19376475)));
                list.Add(new Subscription("XS0831818264@RABS CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18044557)));
                list.Add(new Subscription("XS0831345425 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19568729)));
                list.Add(new Subscription("CH0192713839@EFGZ CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19271383)));
                list.Add(new Subscription("CH0193320634 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19332063)));
                list.Add(new Subscription("CH0193320659 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19332065)));
                list.Add(new Subscription("CH0197277368@UBSF CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19727736)));
                list.Add(new Subscription("CH0196851569 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19256161)));
                list.Add(new Subscription("XS0848449772 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19862827)));
                list.Add(new Subscription("CH0199037646 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19903764)));
                list.Add(new Subscription("CH0195362873 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19536287)));
                list.Add(new Subscription("DE000CZ36U01@CBED CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19994508)));
                list.Add(new Subscription("CH0199655421@WDRL CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19965542)));
                list.Add(new Subscription("XS0857368418 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18044674)));
                list.Add(new Subscription("CH0199960300@UBSF CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19996030)));
                list.Add(new Subscription("XS0687757442 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19536333)));
                list.Add(new Subscription("CH0200342639 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(20034263)));
                list.Add(new Subscription("CH0187197782 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18719778)));
                list.Add(new Subscription("CH0194435795 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19443579)));
                list.Add(new Subscription("DE000CZ36U01 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19859810)));
                list.Add(new Subscription("DE000CZ36X24 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(20076171)));
                list.Add(new Subscription("XS0859349291 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18044683)));
                list.Add(new Subscription("XS0859346511 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(20095111)));
                list.Add(new Subscription("XS0859940859 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(18176081)));
                list.Add(new Subscription("CH0195364309 CORP", "BID,ASK,TIME", "interval=15", new CorrelationID(19536430)));
                
                target.Subscribe(list);
            };
            
            target.Start();

            while (true) Thread.Sleep(1000);
        }
    }
}
