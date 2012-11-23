using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TweakToolkit.MVVM.Service
{
    public class ReadModelsCompletedArgs
    {
        private IEnumerable Items { get; set; }

        public ReadModelsCompletedArgs(IEnumerable items)
        {
            Items = items;
        }

        public IEnumerable<TItem> GetItems<TItem>()
        {
            return Items.OfType<TItem>();
        }
    }
}
