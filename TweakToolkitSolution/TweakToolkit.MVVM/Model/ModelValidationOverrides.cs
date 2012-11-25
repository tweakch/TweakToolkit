using System;
using System.ComponentModel;

namespace TweakToolkit.MVVM.Model
{
    public partial class CarModel : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public string Error { get; private set; }
    }
}