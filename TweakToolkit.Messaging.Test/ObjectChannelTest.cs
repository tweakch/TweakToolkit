using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.Messaging.Channel;

namespace TweakToolkit.Messaging.Test
{
    [TestClass]
    public class ObjectChannelTest
    {
        [TestMethod]
        public void TransmitTestObject()
        {
            bool waiting = true;
            const string channelName = "channel";
            const string message = "message";

            var transmitter = ObjectChannel.CreateTransmitter(channelName);
            var receiver = ObjectChannel.CreateReceiver(channelName);
            receiver.Received += (sender, args) => waiting = false;

            var testObject = new TestObject(message);
            transmitter.Send(testObject);

            while (waiting)
            {
                Thread.Sleep(200);
            }

            Assert.AreEqual(testObject, receiver.LastMessage);
        }
    }
}