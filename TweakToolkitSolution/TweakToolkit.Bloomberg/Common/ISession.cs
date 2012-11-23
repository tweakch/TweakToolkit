namespace TweakToolkit.Bloomberg.Common
{
    public interface ISession
    {
        int Port { get; set; }

        string Host { get; set; }

        bool Start();

        void Stop();
    }
}