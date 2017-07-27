using TweakToolkit.MVVM.Model;

namespace TweakToolkit.MVVM.Test.Model
{
    public class CycleModelValidator : IModelValidator
    {
        public ModelValidationResult Validate(object model)
        {
            var item = model as CycleModel;

            if (item != null && item.Owner == null)
            {
                return new ModelValidationResult(false, "The owner must not be null.");
            }

            return new ModelValidationResult(true, "");
        }
    }
}