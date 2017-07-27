using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.Bloomberg.Domain;

namespace TweakToolkit.Bloomberg.Test
{
    [TestClass]
    public class ReferenceDataParserTest
    {
        private const string ReferenceDataFilePath = @"asd";

        [TestMethod]
        public void TestMethod1()
        {
            var parser = new ReferenceDataParser();
            ReferenceDataResponse response;

            using (var stream = new FileStream(ReferenceDataFilePath, FileMode.Open))
            {
                response = parser.Parse(stream);
            }
        }
    }
}