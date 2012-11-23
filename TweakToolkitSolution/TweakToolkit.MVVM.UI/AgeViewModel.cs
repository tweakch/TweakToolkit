using Microsoft.Practices.Prism.ViewModel;

namespace TweakToolkit.MVVM.UI
{
    public class AgeViewModel : NotificationObject
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; RaisePropertyChanged(() => Age); }
        }
    }
}
