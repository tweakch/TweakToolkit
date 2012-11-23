using System;
using System.Globalization;
using System.Windows.Controls;

namespace TweakToolkit.MVVM.UI
{
    public class AgeRangeRule : ValidationRule
    {
        private int _min;
        private int _max;

        public AgeRangeRule()
        {
        }

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age = 0;

            try
            {
                var s = (string) value;
                if (!string.IsNullOrEmpty(s))
                    age = Int32.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if ((age < Min) || (age > Max))
            {
                return new ValidationResult(false,
                  "Please enter an age in the range: " + Min + " - " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
