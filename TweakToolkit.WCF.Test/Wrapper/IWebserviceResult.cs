namespace TweakToolkit.WCF.Test.Wrapper
{
    public interface IWebserviceResult
    {
        bool HasErrors { get; }

        RequestInfo RequestInfo { get; set; }

        string ServiceMessage { get; }
    }
}