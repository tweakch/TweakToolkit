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

                list.Add(new Subscription("XS0353476400@HSSE CORP", "BID,ASK,LAST_UPDATE", "interval=5", new CorrelationID(3871885)));
                list.Add(new Subscription("CH0038772544 CORP", "BID,ERROR", "interval=5", new CorrelationID(3877254)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3996868)));
                list.Add(new Subscription("XS0367246179 CORP", "BID", "interval=5", new CorrelationID(4260561)));
                list.Add(new Subscription("XS0367871471@BXIS CORP", "BID", "interval=5", new CorrelationID(3978333)));
                list.Add(new Subscription("XS0367871125 CORP", "BID", "interval=5", new CorrelationID(3978334)));
                list.Add(new Subscription("XS0363379073 CORP", "BID", "interval=5", new CorrelationID(4232639)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4308862)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4308861)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4308860)));
                list.Add(new Subscription("GB00B39GND35 n/a", "BID", "interval=5", new CorrelationID(3911268)));
                list.Add(new Subscription("DE000TB41BZ2@HSSE CORP", "BID", "interval=5", new CorrelationID(4380569)));
                list.Add(new Subscription("DE000TB41BY5@HSSE CORP", "BID", "interval=5", new CorrelationID(4380568)));
                list.Add(new Subscription("CH0043955266@EXCH CORP", "BID", "interval=5", new CorrelationID(4395526)));
                list.Add(new Subscription("DE000MS8FQR5@DWZS CORP", "BID", "interval=5", new CorrelationID(3997351)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3177527)));
                list.Add(new Subscription("XS0381367712@MSST CORP", "BID", "interval=5", new CorrelationID(4466626)));
                list.Add(new Subscription("XS0377554786@BNPA CORP", "BID", "interval=5", new CorrelationID(4378519)));
                list.Add(new Subscription("CH0049040253@EXCH CORP", "BID", "interval=5", new CorrelationID(4904025)));
                list.Add(new Subscription("CH0049040279@EXCH CORP", "BID", "interval=5", new CorrelationID(4904027)));
                list.Add(new Subscription("CH0049307520@EXCH CORP", "BID", "interval=5", new CorrelationID(4930752)));
                list.Add(new Subscription("CH0049040303@EXCH CORP", "BID", "interval=5", new CorrelationID(4904030)));
                list.Add(new Subscription("CH0046340532@EXCH CORP", "BID", "interval=5", new CorrelationID(4634053)));
                list.Add(new Subscription("DE000CS0PBL8@CSSS CORP", "BID", "interval=5", new CorrelationID(3524242)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3442181)));
                list.Add(new Subscription("XS0279749021@jpm CORP", "BID", "interval=5", new CorrelationID(2839452)));
                list.Add(new Subscription("XS0332133361@hsse CORP", "BID", "interval=5", new CorrelationID(3562497)));
                list.Add(new Subscription("XS0372603711@msfi CORP", "BID", "interval=5", new CorrelationID(4341305)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3253687)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1986183)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2004153)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4542726)));
                list.Add(new Subscription("CH0049040394 CORP", "BID", "interval=5", new CorrelationID(4904039)));
                list.Add(new Subscription("XS0806746789 CORP", "BID", "interval=5", new CorrelationID(4963235)));
                list.Add(new Subscription("XS0412115049 CORP", "BID", "interval=5", new CorrelationID(1626177)));
                list.Add(new Subscription("XS0412991423 CORP", "BID", "interval=5", new CorrelationID(2338551)));
                list.Add(new Subscription("XS0413769885 CORP", "BID", "interval=5", new CorrelationID(3372219)));
                list.Add(new Subscription("XS0413770115 CORP", "BID", "interval=5", new CorrelationID(3372215)));
                list.Add(new Subscription("XS0416171790 CORP", "BID", "interval=5", new CorrelationID(4671270)));
                list.Add(new Subscription("XS0422091396 CORP", "BID", "interval=5", new CorrelationID(10080661)));
                list.Add(new Subscription("XS0429165367 CORP", "BID", "interval=5", new CorrelationID(10189526)));
                list.Add(new Subscription("XS0429739989 CORP", "BID", "interval=5", new CorrelationID(10195177)));
                list.Add(new Subscription("XS0430213206 CORP", "BID", "interval=5", new CorrelationID(10202161)));
                list.Add(new Subscription("XS0431862050 CORP", "BID", "interval=5", new CorrelationID(10232532)));
                list.Add(new Subscription("XS0431862480 CORP", "BID", "interval=5", new CorrelationID(10232652)));
                list.Add(new Subscription("XS0431862720 CORP", "BID", "interval=5", new CorrelationID(10232745)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10281482)));
                list.Add(new Subscription("XS0436885965 CORP", "BID", "interval=5", new CorrelationID(10300189)));
                list.Add(new Subscription("XS0439234476 CORP", "BID", "interval=5", new CorrelationID(10349504)));
                list.Add(new Subscription("CH0103364532@efgz CORP", "BID", "interval=5", new CorrelationID(10336453)));
                list.Add(new Subscription("XS0442955638 CORP", "BID", "interval=5", new CorrelationID(10421128)));
                list.Add(new Subscription("CH0100579256@EXCH CORP", "BID", "interval=5", new CorrelationID(10057925)));
                list.Add(new Subscription("XS0448307289 CORP", "BID", "interval=5", new CorrelationID(10483097)));
                list.Add(new Subscription("XS0448307016@NOMX CORP", "BID", "interval=5", new CorrelationID(10483111)));
                list.Add(new Subscription("XS0448307792@NOMX CORP", "BID", "interval=5", new CorrelationID(10483123)));
                list.Add(new Subscription("CH0105011305 CORP", "BID", "interval=5", new CorrelationID(10501130)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10347511)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10594463)));
                list.Add(new Subscription(" CORP", "BID", "interval=5", new CorrelationID(10627717)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10469380)));
                list.Add(new Subscription("XS0464455384 CORP", "BID", "interval=5", new CorrelationID(10707623)));
                list.Add(new Subscription("FR0010821256@EXA CORP", "BID", "interval=5", new CorrelationID(10726104)));
                list.Add(new Subscription("FR0010821157 CORP", "BID", "interval=5", new CorrelationID(10719822)));
                list.Add(new Subscription("CH0104514861 CORP", "BID", "interval=5", new CorrelationID(10451486)));
                list.Add(new Subscription("GB00B4NVX972 n/a", "BID", "interval=5", new CorrelationID(10469379)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10591210)));
                list.Add(new Subscription("XS0461087792 CORP", "BID", "interval=5", new CorrelationID(10683394)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10664487)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2187102)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10366014)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4968648)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1629272)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3241163)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3477152)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1913453)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10125807)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3307425)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2823290)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10199224)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3029584)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2017294)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1784540)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1784537)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3222003)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3640874)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2094274)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1800885)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2712090)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2712074)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2438100)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2442587)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4289816)));
                list.Add(new Subscription(" CORP", "BID", "interval=5", new CorrelationID(45768210)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10608873)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10688317)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10692694)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(1869169)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3494721)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3022287)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2875064)));
                list.Add(new Subscription("XS0406892652@nomx CORP", "BID", "interval=5", new CorrelationID(4933678)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10802384)));
                list.Add(new Subscription("XS0490463832 CORP", "BID", "interval=5", new CorrelationID(11056786)));
                list.Add(new Subscription("CH0110623276 CORP", "BID", "interval=5", new CorrelationID(11062327)));
                list.Add(new Subscription("XS0477862584@NMDP CORP", "BID", "interval=5", new CorrelationID(10889375)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(3688842)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(2440446)));
                list.Add(new Subscription("FR0010855536@EXA CORP", "BID", "interval=5", new CorrelationID(11005140)));
                list.Add(new Subscription("CH0109250545@EXCH CORP", "BID", "interval=5", new CorrelationID(10925054)));
                list.Add(new Subscription("XS0482923561@NMDP CORP", "BID", "interval=5", new CorrelationID(10959329)));
                list.Add(new Subscription("CH0107096439 CORP", "BID", "interval=5", new CorrelationID(10709439)));
                list.Add(new Subscription("CH0107368208 CORP", "BID", "interval=5", new CorrelationID(10736820)));
                list.Add(new Subscription("XS0498716272 CORP", "BID", "interval=5", new CorrelationID(11164940)));
                list.Add(new Subscription("DE000DB7MTR7@DBXM CORP", "BID", "interval=5", new CorrelationID(11085343)));
                list.Add(new Subscription("XS0498716199 CORP", "BID", "interval=5", new CorrelationID(11164936)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10199265)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(11007534)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(11350144)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10677726)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(4276437)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(10665235)));
                list.Add(new Subscription("DE000DB7MTQ9@DBXM CORP", "BID", "interval=5", new CorrelationID(11085342)));
                list.Add(new Subscription("NL0009326214@JPM CORP", "BID", "interval=5", new CorrelationID(11165134)));
                list.Add(new Subscription("NL0009326222@JPM CORP", "BID", "interval=5", new CorrelationID(11165135)));
                list.Add(new Subscription("NL0009326230@JPM CORP", "BID", "interval=5", new CorrelationID(11165137)));
                list.Add(new Subscription("CH0113516774@SWEA CORP", "BID", "interval=5", new CorrelationID(11351677)));
                list.Add(new Subscription("CH0112278509@EFGZ CORP", "BID", "interval=5", new CorrelationID(11227850)));
                list.Add(new Subscription("CH0112278525 CORP", "BID", "interval=5", new CorrelationID(11227852)));
                list.Add(new Subscription("CH0112278517@EFGZ CORP", "BID", "interval=5", new CorrelationID(11227851)));
                list.Add(new Subscription("XS0518512263@CSSS CORP", "BID", "interval=5", new CorrelationID(11431026)));
                list.Add(new Subscription("XS0519654775@SGIN CORP", "BID", "interval=5", new CorrelationID(11447380)));
                list.Add(new Subscription("XS0519659063@SGIN CORP", "BID", "interval=5", new CorrelationID(11447381)));
                list.Add(new Subscription("CH0114666198@EXCH CORP", "BID", "interval=5", new CorrelationID(11466619)));
                list.Add(new Subscription("CH0113363805@SGDP CORP", "BID", "interval=5", new CorrelationID(11336380)));
                list.Add(new Subscription("CH0115386390@EFGZ CORP", "BID", "interval=5", new CorrelationID(11538639)));
                list.Add(new Subscription("CH0115890482@EFGZ CORP", "BID", "interval=5", new CorrelationID(11589048)));
                list.Add(new Subscription("CH0112592123 CORP", "BID", "interval=5", new CorrelationID(11259212)));
                list.Add(new Subscription("CH0112592131 CORP", "BID", "interval=5", new CorrelationID(11259213)));
                list.Add(new Subscription("XS0498715894 CORP", "BID", "interval=5", new CorrelationID(11164921)));
                list.Add(new Subscription("XS0499310265 CORP", "BID", "interval=5", new CorrelationID(10215159)));
                list.Add(new Subscription("DE000DB7MHA8 CORP", "BID", "interval=5", new CorrelationID(11085340)));
                list.Add(new Subscription("CH0111527773 CORP", "BID", "interval=5", new CorrelationID(11152777)));
                list.Add(new Subscription("XS0507904877@SGIN CORP", "BID", "interval=5", new CorrelationID(11271762)));
                list.Add(new Subscription("XS0545024431 CORP", "BID", "interval=5", new CorrelationID(11809392)));
                list.Add(new Subscription("CH0117509023 CORP", "BID", "interval=5", new CorrelationID(11750902)));
                list.Add(new Subscription("XS0552575317 CORP", "BID", "interval=5", new CorrelationID(11911390)));
                list.Add(new Subscription("XS0550603632 CORP", "BID", "interval=5", new CorrelationID(11889293)));
                list.Add(new Subscription("XS0550618077 CORP", "BID", "interval=5", new CorrelationID(11877219)));
                list.Add(new Subscription("XS0558035282 CORP", "BID", "interval=5", new CorrelationID(11985801)));
                list.Add(new Subscription("XS4 CORP", "BID", "interval=5", new CorrelationID(11165168)));
                list.Add(new Subscription("NL CORP", "BID", "interval=5", new CorrelationID(11165169)));
                list.Add(new Subscription("NL0 CORP", "BID", "interval=5", new CorrelationID(11165178)));
                list.Add(new Subscription(" CORP", "BID", "interval=5", new CorrelationID(12040525)));
                list.Add(new Subscription(" CORP", "BID", "interval=5", new CorrelationID(12040509)));
                list.Add(new Subscription("XS0562518398 CORP", "BID", "interval=5", new CorrelationID(12042233)));
                list.Add(new Subscription("XS0562245489 CORP", "BID", "interval=5", new CorrelationID(12058133)));
                list.Add(new Subscription("XS0563449692 CORP", "BID", "interval=5", new CorrelationID(12055237)));
                list.Add(new Subscription("XS0565868147 CORP", "BID", "interval=5", new CorrelationID(12093575)));
                list.Add(new Subscription("XS0565868733 CORP", "BID", "interval=5", new CorrelationID(12093591)));
                list.Add(new Subscription("NL0009510254@JPM CORP", "BID", "interval=5", new CorrelationID(11165184)));
                list.Add(new Subscription(" n/a", "BID", "interval=5", new CorrelationID(11856398)));
                list.Add(new Subscription("CH0120643298 CORP", "BID", "interval=5", new CorrelationID(12064329)));
                list.Add(new Subscription("XS0578142928 CORP", "BID", "interval=5", new CorrelationID(12288571)));
                list.Add(new Subscription("XS0583507537@SGIN CORP", "BID", "interval=5", new CorrelationID(12366734)));
                list.Add(new Subscription("CH0123071547 CORP", "BID", "interval=5", new CorrelationID(12307154)));
                list.Add(new Subscription("XS0587751008 CORP", "BID", "interval=5", new CorrelationID(12415328)));
                list.Add(new Subscription("XS0588319052 CORP", "BID", "interval=5", new CorrelationID(12423139)));
                list.Add(new Subscription("CH0120637308 CORP", "BID", "interval=5", new CorrelationID(12063730)));
                list.Add(new Subscription("CH0123796242 CORP", "BID", "interval=5", new CorrelationID(12379624)));
                list.Add(new Subscription("XS0589646206@RABS CORP", "BID", "interval=5", new CorrelationID(11913005)));
                list.Add(new Subscription("XS0589648244@RABS CORP", "BID", "interval=5", new CorrelationID(11913006)));
                list.Add(new Subscription("XS0589651032@RBCD CORP", "BID", "interval=5", new CorrelationID(12433620)));
                list.Add(new Subscription("CH0119382254 CORP", "BID", "interval=5", new CorrelationID(11938225)));
                list.Add(new Subscription("XS0590758024 CORP", "BID", "interval=5", new CorrelationID(12116741)));
                list.Add(new Subscription("XS0479182270 CORP", "BID", "interval=5", new CorrelationID(4294746)));
                list.Add(new Subscription("XS0593834939 CORP", "BID", "interval=5", new CorrelationID(12506825)));
                list.Add(new Subscription("XS0594511205 CORP", "BID", "interval=5", new CorrelationID(12523918)));
                list.Add(new Subscription("XS0593598609 CORP", "BID", "interval=5", new CorrelationID(12506803)));
                list.Add(new Subscription("XS0598447927 CORP", "BID", "interval=5", new CorrelationID(12592861)));
                list.Add(new Subscription("CH0118622775 CORP", "BID", "interval=5", new CorrelationID(11862277)));
                list.Add(new Subscription("XS0602962358 CORP", "BID", "interval=5", new CorrelationID(11165210)));
                list.Add(new Subscription("XS0603569988 CORP", "BID", "interval=5", new CorrelationID(12634631)));
                list.Add(new Subscription("CH0125690484 CORP", "BID", "interval=5", new CorrelationID(12569048)));
                list.Add(new Subscription("XS0605683241 CORP", "BID", "interval=5", new CorrelationID(12672279)));
                list.Add(new Subscription("XS0608523089 CORP", "BID", "interval=5", new CorrelationID(12721440)));
                list.Add(new Subscription("XS0608368097 CORP", "BID", "interval=5", new CorrelationID(12721418)));
                list.Add(new Subscription("XS0613440717 CORP", "BID", "interval=5", new CorrelationID(12695116)));
                list.Add(new Subscription("CH0118623146 CORP", "BID", "interval=5", new CorrelationID(11862314)));
                list.Add(new Subscription("XS0479254103@GSSD CORP", "BID", "interval=5", new CorrelationID(10215238)));
                list.Add(new Subscription("CH0126969945 CORP", "BID", "interval=5", new CorrelationID(12696994)));
                list.Add(new Subscription("CH0118623328 CORP", "BID", "interval=5", new CorrelationID(11862332)));
                list.Add(new Subscription("XS0479261579 CORP", "BID", "interval=5", new CorrelationID(10215326)));
                list.Add(new Subscription("XS0479265059 CORP", "BID", "interval=5", new CorrelationID(10215348)));
                list.Add(new Subscription("NL0009706142 CORP", "BID", "interval=5", new CorrelationID(11165228)));
                list.Add(new Subscription("NL0009706159 CORP", "BID", "interval=5", new CorrelationID(11165229)));
                list.Add(new Subscription("NL0009706209 CORP", "BID", "interval=5", new CorrelationID(11165230)));
                list.Add(new Subscription("CH0130102996 CORP", "BID", "interval=5", new CorrelationID(13010299)));
                list.Add(new Subscription("XS0631001020 CORP", "BID", "interval=5", new CorrelationID(12914722)));
                list.Add(new Subscription("CH0107164326 CORP", "BID", "interval=5", new CorrelationID(10716432)));
                list.Add(new Subscription("CH0130538348 CORP", "BID", "interval=5", new CorrelationID(13053834)));
                list.Add(new Subscription("XS0479292616 CORP", "BID", "interval=5", new CorrelationID(13119058)));
                list.Add(new Subscription("CH0132520229 CORP", "BID", "interval=5", new CorrelationID(13252022)));
                list.Add(new Subscription("CH0118623971 CORP", "BID", "interval=5", new CorrelationID(11862397)));
                list.Add(new Subscription("CH0118623989 CORP", "BID", "interval=5", new CorrelationID(11862398)));
                list.Add(new Subscription("XS0646156025@RABS CORP", "BID", "interval=5", new CorrelationID(12914795)));
                list.Add(new Subscription("XS0646156371 CORP", "BID", "interval=5", new CorrelationID(12914796)));
                list.Add(new Subscription("CH0130103440 CORP", "BID", "interval=5", new CorrelationID(13010344)));
                list.Add(new Subscription("CH0130103457@SGDP CORP", "BID", "interval=5", new CorrelationID(13010345)));
                list.Add(new Subscription("CH0104362238 CORP", "BID", "interval=5", new CorrelationID(10436223)));
                list.Add(new Subscription("CH0102161251 CORP", "BID", "interval=5", new CorrelationID(10216125)));
                list.Add(new Subscription("CH0133919248 CORP", "BID", "interval=5", new CorrelationID(13391924)));
                list.Add(new Subscription("XS0657710041 CORP", "BID", "interval=5", new CorrelationID(13267901)));
                list.Add(new Subscription("XS0657710124 CORP", "BID", "interval=5", new CorrelationID(13267902)));
                list.Add(new Subscription("CH0130539841 CORP", "BID", "interval=5", new CorrelationID(13053984)));
                list.Add(new Subscription("XS0670859494 CORP", "BID", "interval=5", new CorrelationID(13701545)));
                list.Add(new Subscription("XS0670858413 CORP", "BID", "interval=5", new CorrelationID(13701269)));
                list.Add(new Subscription("XS0651732801 CORP", "BID", "interval=5", new CorrelationID(13506682)));
                list.Add(new Subscription("CH0137076920 CORP", "BID", "interval=5", new CorrelationID(13707692)));
                list.Add(new Subscription("XS0676572927 CORP", "BID", "interval=5", new CorrelationID(13809652)));
                list.Add(new Subscription("CH0137077050 CORP", "BID", "interval=5", new CorrelationID(13707705)));
                list.Add(new Subscription("CH0137077084 CORP", "BID", "interval=5", new CorrelationID(13707708)));
                list.Add(new Subscription("CH0137077209 CORP", "BID", "interval=5", new CorrelationID(13707720)));
                list.Add(new Subscription("CH0137077266 CORP", "BID", "interval=5", new CorrelationID(13707726)));
                list.Add(new Subscription("CH0137077316 CORP", "BID", "interval=5", new CorrelationID(13707731)));
                list.Add(new Subscription("XS0685400466 CORP", "BID", "interval=5", new CorrelationID(764)));
                list.Add(new Subscription("CH0137077332 CORP", "BID", "interval=5", new CorrelationID(13707733)));
                list.Add(new Subscription("XS0689093846 CORP", "BID", "interval=5", new CorrelationID(13752849)));
                list.Add(new Subscription("CH0137077423 CORP", "BID", "interval=5", new CorrelationID(13707742)));
                list.Add(new Subscription("CH0137077431 CORP", "BID", "interval=5", new CorrelationID(13707743)));
                list.Add(new Subscription("CH0137077555 CORP", "BID", "interval=5", new CorrelationID(13707755)));
                list.Add(new Subscription("XS0694436055 CORP", "BID", "interval=5", new CorrelationID(14115077)));
                list.Add(new Subscription("CH0125723723 CORP", "BID", "interval=5", new CorrelationID(12572372)));
                list.Add(new Subscription("CH0136518252 CORP", "BID", "interval=5", new CorrelationID(13651825)));
                list.Add(new Subscription("FR0011132372 CORP", "BID", "interval=5", new CorrelationID(14065517)));
                list.Add(new Subscription("XS0699629399 CORP", "BID", "interval=5", new CorrelationID(14183475)));
                list.Add(new Subscription("CH0139214859 CORP", "BID", "interval=5", new CorrelationID(13921485)));
                list.Add(new Subscription("XS0702080168 CORP", "BID", "interval=5", new CorrelationID(14233886)));
                list.Add(new Subscription("XS0702022988 CORP", "BID", "interval=5", new CorrelationID(13752871)));
                list.Add(new Subscription("XS0703714724 CORP", "BID", "interval=5", new CorrelationID(14247639)));
                list.Add(new Subscription("CH0137077894 CORP", "BID", "interval=5", new CorrelationID(13707789)));
                list.Add(new Subscription("CH0137077910 CORP", "BID", "interval=5", new CorrelationID(13707791)));
                list.Add(new Subscription("CH0135872205 CORP", "BID", "interval=5", new CorrelationID(13587220)));
                list.Add(new Subscription("CH0143063714 CORP", "BID", "interval=5", new CorrelationID(14306371)));
                list.Add(new Subscription("CH0137077936 CORP", "BID", "interval=5", new CorrelationID(13707793)));
                list.Add(new Subscription("CH0137077985 CORP", "BID", "interval=5", new CorrelationID(13707798)));
                list.Add(new Subscription("XS0709599509@HSED CORP", "BID", "interval=5", new CorrelationID(14359725)));
                list.Add(new Subscription("CH0137078074 CORP", "BID", "interval=5", new CorrelationID(13707807)));
                list.Add(new Subscription("XS0711116870 CORP", "BID", "interval=5", new CorrelationID(14369519)));
                list.Add(new Subscription("CH0137078264 CORP", "BID", "interval=5", new CorrelationID(13707826)));
                list.Add(new Subscription("CH0137078413 CORP", "BID", "interval=5", new CorrelationID(13707841)));
                list.Add(new Subscription("CH0137078108 CORP", "BID", "interval=5", new CorrelationID(13707810)));
                list.Add(new Subscription("XS0721649548 CORP", "BID", "interval=5", new CorrelationID(14536427)));
                list.Add(new Subscription("CH0133270394 CORP", "BID", "interval=5", new CorrelationID(13327039)));
                list.Add(new Subscription("CH0137078587 CORP", "BID", "interval=5", new CorrelationID(13707858)));
                list.Add(new Subscription("CH0145801798 CORP", "BID", "interval=5", new CorrelationID(14580179)));
                list.Add(new Subscription("CH0140911519 CORP", "BID", "interval=5", new CorrelationID(14091151)));
                list.Add(new Subscription("CH0132188514 CORP", "BID", "interval=5", new CorrelationID(13218851)));
                list.Add(new Subscription("CH0144228233@EFGZ CORP", "BID", "interval=5", new CorrelationID(14422823)));
                list.Add(new Subscription("XS0722994000 CORP", "BID", "interval=5", new CorrelationID(14558142)));
                list.Add(new Subscription("XS0727627209 CORP", "BID", "interval=5", new CorrelationID(14641381)));
                list.Add(new Subscription("CH0102169742 CORP", "BID", "interval=5", new CorrelationID(10216974)));
                list.Add(new Subscription("CH137078637 CORP", "BID", "interval=5", new CorrelationID(13707863)));
                list.Add(new Subscription("XS0730825873 CORP", "BID", "interval=5", new CorrelationID(14701271)));
                list.Add(new Subscription("CH0137078728 CORP", "BID", "interval=5", new CorrelationID(13707872)));
                list.Add(new Subscription("CH0102169874 CORP", "BID", "interval=5", new CorrelationID(10216987)));
                list.Add(new Subscription("XS0740216386 CORP", "BID", "interval=5", new CorrelationID(14860582)));
                list.Add(new Subscription("CH0146740565 CORP", "BID", "interval=5", new CorrelationID(14674056)));
                list.Add(new Subscription("CH0146739427 CORP", "BID", "interval=5", new CorrelationID(14673942)));
                list.Add(new Subscription("CH0145836877 CORP", "BID", "interval=5", new CorrelationID(14583687)));
                list.Add(new Subscription("XS0744130641 CORP", "BID", "interval=5", new CorrelationID(14928504)));
                list.Add(new Subscription("CH0144229942 CORP", "BID", "interval=5", new CorrelationID(14422994)));
                list.Add(new Subscription("CH0149883552 CORP", "BID", "interval=5", new CorrelationID(14988355)));
                list.Add(new Subscription("XS074792898 CORP", "BID", "interval=5", new CorrelationID(14998634)));
                list.Add(new Subscription("XS0752258573 CORP", "BID", "interval=5", new CorrelationID(18057947)));
                list.Add(new Subscription("CH0180615442 CORP", "BID", "interval=5", new CorrelationID(18061544)));
                list.Add(new Subscription("CH0149120252 CORP", "BID", "interval=5", new CorrelationID(14912025)));
                list.Add(new Subscription("XS0755799698 CORP", "BID", "interval=5", new CorrelationID(18119284)));
                list.Add(new Subscription("CH0180619899 CORP", "BID", "interval=5", new CorrelationID(18061989)));
                list.Add(new Subscription("CH0144230536 CORP", "BID", "interval=5", new CorrelationID(14423053)));
                list.Add(new Subscription("CH0148735266@SARA CORP", "BID", "interval=5", new CorrelationID(14873526)));
                list.Add(new Subscription("CH0104737785 CORP", "BID", "interval=5", new CorrelationID(10473778)));
                list.Add(new Subscription("CH0108883254 CORP", "BID", "interval=5", new CorrelationID(10888325)));
                list.Add(new Subscription("XS0769920454 CORP", "BID", "interval=5", new CorrelationID(18044366)));
                list.Add(new Subscription(" CORP", "BID", "interval=5", new CorrelationID(14423088)));
                list.Add(new Subscription("CH0141499746 CORP", "BID", "interval=5", new CorrelationID(14149974)));
                list.Add(new Subscription("CH0141499779 CORP", "BID", "interval=5", new CorrelationID(14149977)));
                list.Add(new Subscription("XS0770683687@HSED CORP", "BID", "interval=5", new CorrelationID(18336675)));
                list.Add(new Subscription("CH0144230957 CORP", "BID", "interval=5", new CorrelationID(14423095)));
                list.Add(new Subscription("NL0010066700@JPM CORP", "BID", "interval=5", new CorrelationID(18005707)));
                list.Add(new Subscription("CH0144231047 CORP", "BID", "interval=5", new CorrelationID(14423104)));
                list.Add(new Subscription("XS0774943327 CORP", "BID", "interval=5", new CorrelationID(18416908)));
                list.Add(new Subscription("XS0774943756 CORP", "BID", "interval=5", new CorrelationID(18417084)));
                list.Add(new Subscription("XS0756503024@RBCD CORP", "BID", "interval=5", new CorrelationID(18500241)));
                list.Add(new Subscription("CH0144231229 CORP", "BID", "interval=5", new CorrelationID(14423122)));
                list.Add(new Subscription("CH0182938776@EXA CORP", "BID", "interval=5", new CorrelationID(18293877)));
                list.Add(new Subscription("XS0785613604 CORP", "BID", "interval=5", new CorrelationID(18044419)));
                list.Add(new Subscription("CH0180528066 CORP", "BID", "interval=5", new CorrelationID(18052806)));
                list.Add(new Subscription("CH0184262076 CORP", "BID", "interval=5", new CorrelationID(18426207)));
                list.Add(new Subscription("XS0585380602@GSSD CORP", "BID", "interval=5", new CorrelationID(18595973)));
                list.Add(new Subscription("XS0788176070@RBCD CORP", "BID", "interval=5", new CorrelationID(18803310)));
                list.Add(new Subscription("XS0799547137@RABS CORP", "BID", "interval=5", new CorrelationID(18044452)));
                list.Add(new Subscription("CH0189535229@UBSF CORP", "BID", "interval=5", new CorrelationID(19953522)));
                list.Add(new Subscription("XS0806746789@HSED CORP", "BID", "interval=5", new CorrelationID(19043879)));
                list.Add(new Subscription("XS0807559454@HSED CORP", "BID", "interval=5", new CorrelationID(19055243)));
                list.Add(new Subscription("XS0807582605@RABS CORP", "BID", "interval=5", new CorrelationID(18044484)));
                list.Add(new Subscription("XS0816364433@HSED CORP", "BID", "interval=5", new CorrelationID(19238472)));
                list.Add(new Subscription("CH0187367930@EFGZ CORP", "BID", "interval=5", new CorrelationID(18736793)));
                list.Add(new Subscription("XS0815510812@HSED CORP", "BID", "interval=5", new CorrelationID(19210627)));
                list.Add(new Subscription("CH0188287632@CSZE CORP", "BID", "interval=5", new CorrelationID(18828763)));
                list.Add(new Subscription("CH0148735324@SARA CORP", "BID", "interval=5", new CorrelationID(14873532)));
                list.Add(new Subscription("CH0148735332@SARA CORP", "BID", "interval=5", new CorrelationID(14873533)));
                list.Add(new Subscription("CH0187368110 CORP", "BID", "interval=5", new CorrelationID(18736811)));
                list.Add(new Subscription("CH0141501947@VONT CORP", "BID", "interval=5", new CorrelationID(14150194)));
                list.Add(new Subscription("CH0141501954@exch CORP", "BID", "interval=5", new CorrelationID(14150195)));
                list.Add(new Subscription("GB00B8MKWW97 CORP", "BID", "interval=5", new CorrelationID(10474448)));
                list.Add(new Subscription("XS0826054289 CORP", "BID", "interval=5", new CorrelationID(18293952)));
                list.Add(new Subscription("XS0826056144 CORP", "BID", "interval=5", new CorrelationID(19399264)));
                list.Add(new Subscription("CH0193303010 CORP", "BID", "interval=5", new CorrelationID(19330301)));
                list.Add(new Subscription("CH0194083454 CORP", "BID", "interval=5", new CorrelationID(19408345)));
                list.Add(new Subscription("XS0826535030@RABS CORP", "BID", "interval=5", new CorrelationID(18044543)));
                list.Add(new Subscription("FR0011315654@EXA CORP", "BID", "interval=5", new CorrelationID(19376476)));
                list.Add(new Subscription("CH0182602141@EFGZ CORP", "BID", "interval=5", new CorrelationID(18260214)));
                list.Add(new Subscription("XS0827216739 CORP", "BID", "interval=5", new CorrelationID(19424709)));
                list.Add(new Subscription("CH0190890969@EFGZ CORP", "BID", "interval=5", new CorrelationID(19089096)));
                list.Add(new Subscription("FR0011315670@EXA CORP", "BID", "interval=5", new CorrelationID(19376475)));
                list.Add(new Subscription("XS0831818264@RABS CORP", "BID", "interval=5", new CorrelationID(18044557)));
                list.Add(new Subscription("XS0831345425 CORP", "BID", "interval=5", new CorrelationID(19568729)));
                list.Add(new Subscription("CH0192713839@EFGZ CORP", "BID", "interval=5", new CorrelationID(19271383)));
                list.Add(new Subscription("CH0193320634 CORP", "BID", "interval=5", new CorrelationID(19332063)));
                list.Add(new Subscription("CH0193320659 CORP", "BID", "interval=5", new CorrelationID(19332065)));
                list.Add(new Subscription("CH0197277368@UBSF CORP", "BID", "interval=5", new CorrelationID(19727736)));
                list.Add(new Subscription("CH0196851569 CORP", "BID", "interval=5", new CorrelationID(19256161)));
                list.Add(new Subscription(" CORP", "BID", "interval=5", new CorrelationID(123456789)));
                list.Add(new Subscription("XS0848449772 CORP", "BID", "interval=5", new CorrelationID(19862827)));
                list.Add(new Subscription("CH0199037646 CORP", "BID", "interval=5", new CorrelationID(19903764)));
                list.Add(new Subscription("CH0195362873 CORP", "BID", "interval=5", new CorrelationID(19536287)));
                list.Add(new Subscription("DE000CZ36U01@CBED CORP", "BID", "interval=5", new CorrelationID(19994508)));
                list.Add(new Subscription("CH0199655421@WDRL CORP", "BID", "interval=5", new CorrelationID(19965542)));
                list.Add(new Subscription("XS0857368418 CORP", "BID", "interval=5", new CorrelationID(18044674)));
                list.Add(new Subscription("CH0199960300@UBSF CORP", "BID", "interval=5", new CorrelationID(19996030)));
                list.Add(new Subscription("XS0687757442 CORP", "BID", "interval=5", new CorrelationID(19536333)));
                list.Add(new Subscription("CH0200342639 CORP", "BID", "interval=5", new CorrelationID(20034263)));
                list.Add(new Subscription("CH0187197782 CORP", "BID", "interval=5", new CorrelationID(18719778)));
                list.Add(new Subscription("CH0194435795 CORP", "BID", "interval=5", new CorrelationID(19443579)));
                list.Add(new Subscription("DE000CZ36U01 CORP", "BID", "interval=5", new CorrelationID(19859810)));
                list.Add(new Subscription("DE000CZ36X24 CORP", "BID", "interval=5", new CorrelationID(20076171)));
                list.Add(new Subscription("XS0859349291 CORP", "BID", "interval=5", new CorrelationID(18044683)));
                list.Add(new Subscription("XS0859346511 CORP", "BID", "interval=5", new CorrelationID(20095111)));
                list.Add(new Subscription("XS0859940859 CORP", "BID", "interval=5", new CorrelationID(18176081)));
                list.Add(new Subscription("CH0195364309 CORP", "BID", "interval=5", new CorrelationID(19536430)));
                
                target.Subscribe(list);
            };
            
            target.Start();

            while (true) Thread.Sleep(1000);
        }
    }
}
