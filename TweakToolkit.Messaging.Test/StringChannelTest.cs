using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.Messaging.Channel;
using TweakToolkit.Messaging.Channel.Receiver;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Test
{
    [TestClass]
    public class StringChannelTest
    {
        [TestMethod]
        public void MultipleChannelCreationTest()
        {
            const string channelName = "channel";
            const string channel2Name = "channels";

            IChannel<string> channel1 = StringChannel.GetChannel(channelName);
            IChannel<string> channel2 = StringChannel.GetChannel(channel2Name);

            Assert.AreEqual(channelName, channel1.ChannelName);
            Assert.AreEqual(channel2Name, channel2.ChannelName);
        }

        [TestMethod]
        public void MultiTransmitMessageToSingleReceiverTest()
        {
            bool rcv1Waiting = true;
            bool rcv2Waiting = true;

            const string channel = "channel";
            const string message1 = "message1";
            const string message2 = "message2";

            ITransmitter<string> transmitter1 = StringChannel.CreateTransmitter(channel);
            ITransmitter<string> transmitter2 = StringChannel.CreateTransmitter(channel);
            IReceiver<string> receiver1 = StringChannel.CreateReceiver(channel);

            receiver1.Received += (sender, args) =>
                                      {
                                          if (args.Message.Equals(message1))
                                          {
                                              rcv1Waiting = false;
                                          }

                                          if (args.Message.Equals(message2))
                                          {
                                              rcv2Waiting = false;
                                          }
                                      };

            transmitter1.Send(message1);
            transmitter2.Send(message2);

            while (rcv1Waiting && rcv2Waiting)
            {
                Thread.Sleep(200);
            }

            Assert.IsNotNull(receiver1.LastMessage);
        }

        [TestMethod]
        public void ReceiverCreationTest()
        {
            const string channelName = "channel";
            IReceiver<string> stringReceiver = StringChannel.CreateReceiver(channelName);
            Assert.IsNull(stringReceiver.LastMessage);
            Assert.AreEqual(channelName, stringReceiver.Channel.ChannelName);
        }

        [TestMethod]
        public void ReusableChannelCreationTest()
        {
            const string channelName = "channel";
            IChannel<string> channelA = StringChannel.GetChannel(channelName);
            IChannel<string> channelB = StringChannel.GetChannel(channelName);
            Assert.AreEqual(channelA, channelB);
        }

        [TestMethod]
        public void TestSingleChannelCreation()
        {
            const string channelName = "channel";
            IChannel<string> channel = StringChannel.GetChannel(channelName);
            Assert.AreEqual(channelName, channel.ChannelName);
        }

        [TestMethod]
        public void TransmitMessageToMultipleReceiverTest()
        {
            bool rcv1Waiting = true;
            bool rcv2Waiting = true;
            const string channel = "channel";
            const string message = "message";

            ITransmitter<string> stringTransmitter = StringChannel.CreateTransmitter(channel);
            IReceiver<string> receiver1 = StringChannel.CreateReceiver(channel);
            IReceiver<string> receiver2 = StringChannel.CreateReceiver(channel);

            receiver1.Received += (sender, args) =>
                                      {
                                          Assert.AreEqual(channel, args.Channel.ChannelName);
                                          rcv1Waiting = false;
                                      };

            receiver2.Received += (sender, args) =>
                                      {
                                          Assert.AreEqual(channel, args.Channel.ChannelName);
                                          rcv2Waiting = false;
                                      };

            stringTransmitter.Send(message);

            while (rcv1Waiting && rcv2Waiting)
            {
                Thread.Sleep(200);
            }

            Assert.AreEqual(message, receiver1.LastMessage);
            Assert.AreEqual(message, receiver2.LastMessage);
        }

        [TestMethod]
        public void TransmitMessageToSingleReceiverTest()
        {
            bool waiting = true;
            const string channel = "channel";
            const string message = "message";

            ITransmitter<string> stringTransmitter = StringChannel.CreateTransmitter(channel);
            IReceiver<string> stringReceiver = StringChannel.CreateReceiver(channel);

            stringReceiver.Received += (sender, args) =>
                                           {
                                               Assert.AreEqual(channel, args.Channel.ChannelName);
                                               waiting = false;
                                           };

            stringTransmitter.Send(message);

            while (waiting)
            {
                Thread.Sleep(200);
            }

            Assert.AreEqual(message, stringReceiver.LastMessage);
        }

        [TestMethod]
        public void TransmitterCreationTest()
        {
            const string channelName = "channel";
            ITransmitter<string> stringTransmitter = StringChannel.CreateTransmitter(channelName);
            Assert.AreEqual(channelName, stringTransmitter.Channel.ChannelName);
        }

        [TestMethod]
        public void ChangeChannelTest()
        {
            bool waiting = true;
            const string channel1 = "channel1";
            const string channel2 = "channel2";
            const string channel3 = "channel3";

            const string message = "message";
            ITransmitter<string> stringTransmitter = StringChannel.CreateTransmitter(channel1);
            IReceiver<string> stringReceiver = StringChannel.CreateReceiver(channel2);

            stringReceiver.Received += (sender, args) => { waiting = false; };
            stringTransmitter.Send(message);

            Thread.Sleep(200);
            Assert.IsNull(stringReceiver.LastMessage);

            stringTransmitter.SetChannel(channel3);
            stringReceiver.SetChannel(channel3);

            stringTransmitter.Send(message);

            while (waiting)
            {
                Thread.Sleep(200);
            }

            Assert.IsNotNull(stringReceiver.LastMessage);
        }

        [TestMethod]
        public void UnregisteredChannelTest()
        {
            const int waitTimeout = 300;
            const string channel1 = "channel1";
            const string channel2 = "channel2";
            const string message = "message";
            ITransmitter<string> stringTransmitter = StringChannel.CreateTransmitter(channel1);
            IReceiver<string> stringReceiver = StringChannel.CreateReceiver(channel2);

            Assert.IsNull(stringReceiver.LastMessage);
            stringTransmitter.Send(message);

            Thread.Sleep(waitTimeout);
            Assert.IsNull(stringReceiver.LastMessage);
        }
    }
}