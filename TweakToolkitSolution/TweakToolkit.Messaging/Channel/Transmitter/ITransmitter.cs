namespace TweakToolkit.Messaging.Channel.Transmitter
{
    public interface ITransmitter<T>
    {
        IChannel<T> Channel { get; }

        void Send(T message);

        void SetChannel(string channelName);
    }
}