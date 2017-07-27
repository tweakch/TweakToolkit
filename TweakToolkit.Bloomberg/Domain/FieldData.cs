using System;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Domain
{
    public class FieldData
    {
        // make generic!!!
        private readonly Element _fieldData;

        private readonly Name _name;
        private readonly object _value;

        private FieldData(Name name)
        {
            _name = name;
            _fieldData = null;
            _value = null;
        }

        public FieldData(string name)
            : this(new Name(name))
        {
        }

        public FieldData(Element fieldData)
            : this(fieldData.Name)
        {
            _fieldData = fieldData;
            _value = _fieldData.GetValue();
        }

        public object Value
        {
            get { return _value; }
        }

        public string Name
        {
            get { return _name.ToString(); }
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public string GetValueAsString()
        {
            try
            {
                return (string)_value;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public double GetValueAsDouble()
        {
            try
            {
                return (double)_value;
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        public int GetValueAsInteger()
        {
            try
            {
                return (int)_value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return GetValueAsString();
        }

        public DateTime? GetValueAsDateTime()
        {
            try
            {
                Datetime dt = _fieldData.GetValueAsDatetime();
                return new DateTime(dt.Year, dt.Month, dt.DayOfMonth, dt.Hour, dt.Minute, dt.Second);
            }
            catch (InvalidConversionException ex)
            {
                if (_name.Equals("TIME"))
                {
                    if (ex.Message.Contains("STRING"))
                    {
                        string stringDate = _fieldData.GetValueAsString();
                        DateTime date;

                        if (stringDate.Contains("/"))
                        {
                            string[] arrayDate = stringDate.Split('/');
                            return new DateTime(Int32.Parse(arrayDate[2]), Int32.Parse(arrayDate[0]),
                                                Int32.Parse(arrayDate[1]));
                        }
                        else if (stringDate.Contains(":"))
                        {
                            string[] arrayTime = stringDate.Split(':');
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                Int32.Parse(arrayTime[0]), Int32.Parse(arrayTime[1]),
                                                Int32.Parse(arrayTime[2]));
                        }
                    }
                }
                return new DateTime(1900, 1, 1);
            }
            catch (Exception ex)
            {
                return new DateTime(1900, 1, 1);
            }
        }
    }
}