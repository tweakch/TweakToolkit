namespace TweakToolkit.MVVM.Model
{
    public class ModelValidationResult
    {
        public ModelValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; }
    }
}