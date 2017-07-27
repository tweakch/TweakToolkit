using TheCodeKing.Net.Messaging;

namespace TweakToolkit.IPC
{
    public interface IXDChannel
    {
        XDTransportMode Mode { get; }

        string Name { get; }

        bool Propagate { get; }

        IXDBroadcast CreateBroadcast();

        IXDListener CreateListener(XDListener.XDMessageHandler handler);
    }
}