namespace TweakToolkit.MVVM.Model
{
    public interface IModelValidator
    {
        ModelValidationResult Validate(object model);
    }
}