using TheCodeKing.Net.Messaging;

namespace TweakToolkit.IPC
{
    public class XDChannelFactory
    {
        public static IXDChannel GetLocalChannel(string name, XDTransportMode mode)
        {
            return new XDChannelImpl(name, mode, false);
        }

        public static IXDChannel GetNetworkChannel(string name, XDTransportMode mode)
        {
            return new XDChannelImpl(name, mode, true);
        }
    }
}