using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.ViewModel;

namespace TweakToolkit.MVVM.Model
{
    public class ItemRepository<TItem> where TItem : NotificationObject
    {
        private readonly Dictionary<TItem, ValidationState> stage;

        public ItemRepository()
        {
            stage = new Dictionary<TItem, ValidationState>();
        }

        public IEnumerable<TItem> InvalidItems { get { return GetItemsByState(ValidationState.Invalid); } }

        public IEnumerable<TItem> UncheckedItems
        {
            get { return GetItemsByState(ValidationState.Unchecked); }
        }

        public IEnumerable<TItem> ValidItems
        {
            get { return GetItemsByState(ValidationState.Valid); }
        }

        public void ClearValidItems()
        {
            foreach (var validItem in ValidItems)
            {
                stage.Remove(validItem);
            }
        }

        public void StageItem(TItem item)
        {
            if (stage.ContainsKey(item)) return;
            item.PropertyChanged += (sender, args) => stage[(TItem)sender] = ValidationState.Unchecked;
            stage.Add(item, ValidationState.Unchecked);
        }

        public void ValidateItems(IModelValidator cycleModelValidator)
        {
            foreach (var item in UncheckedItems)
            {
                var validationResult = cycleModelValidator.Validate(item);
                stage[item] = validationResult.IsValid ? ValidationState.Valid : ValidationState.Invalid;
            }
        }

        private IEnumerable<TItem> GetItemsByState(ValidationState state)
        {
            return stage.Where(kvp => kvp.Value == state).Select(kvp => kvp.Key).ToList();
        }
    }
}