using TheCodeKing.Net.Messaging;

namespace TweakToolkit.IPC
{
    public class XDChannelImpl : IXDChannel
    {
        public XDChannelImpl(string name, XDTransportMode mode, bool propagatesNetwork)
        {
            Name = name;
            Mode = mode;
            Propagate = propagatesNetwork;
        }

        #region IXDChannel Members

        public XDTransportMode Mode { get; private set; }

        public string Name { get; private set; }

        public bool Propagate { get; private set; }

        public IXDBroadcast CreateBroadcast()
        {
            return XDBroadcast.CreateBroadcast(Mode, Propagate);
        }

        public IXDListener CreateListener(XDListener.XDMessageHandler handler)
        {
            IXDListener listener = XDListener.CreateListener(Mode, !Propagate);
            listener.RegisterChannel(Name);
            listener.MessageReceived += handler;
            return listener;
        }

        #endregion IXDChannel Members
    }
}