using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheCodeKing.Net.Messaging;

namespace TweakToolkit.IPC.Test
{
    [TestClass]
    public class UnitTest1
    {
        private bool waitForMessage = true;

        [TestMethod]
        public void TestMethod1()
        {
            string channelName = "testChannel";
            IXDChannel channel = XDChannelFactory.GetLocalChannel(channelName, XDTransportMode.IOStream);
            IXDBroadcast broadcast = channel.CreateBroadcast();
            IXDListener listener = channel.CreateListener(MessageReceived);

            broadcast.SendToChannel(channelName, "test");

            while (waitForMessage)
            {
                Thread.Sleep(200);
            }
            Assert.IsFalse(waitForMessage);
        }

        private void MessageReceived(object sender, XDMessageEventArgs args)
        {
            waitForMessage = false;
        }
    }
}