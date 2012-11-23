using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Domain
{
    public class ErrorInfo
    {
        private readonly Element _errorInfo;

        private string _category;
        private string _code;
        private string _message;
        private string _source;
        private string _subcategory;

        public ErrorInfo(Element errorInfo)
        {
            _errorInfo = errorInfo;
            _source = _errorInfo.GetElementAsString("source");
            _code = _errorInfo.GetElementAsString("code");
            _category = _errorInfo.GetElementAsString("category");
            _message = _errorInfo.GetElementAsString("message");
            _subcategory = _errorInfo.GetElementAsString("subcategory");
        }
    }
}