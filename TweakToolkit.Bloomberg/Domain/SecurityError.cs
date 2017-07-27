using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Domain
{
    public class SecurityError
    {
        private readonly Element _securityError;

        private string _category;
        private string _code;
        private string _message;
        private string _source;
        private string _subcategory;

        public SecurityError(Element securityError)
        {
            _securityError = securityError;
            _source = _securityError.GetElementAsString("source");
            _code = _securityError.GetElementAsString("code");
            _category = _securityError.GetElementAsString("category");
            _message = _securityError.GetElementAsString("message");
            _subcategory = _securityError.GetElementAsString("subcategory");
        }
    }
}