using System.Collections.Generic;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Wrapper;

namespace TweakToolkit.Bloomberg.Domain
{
    public class SecurityData
    {
        private readonly Element _securityData;
        private readonly SecurityError _securityError;

        private SecurityData(ReferenceDataRequestInfo referenceDataRequest)
        {
            Fields = new Dictionary<string, FieldData>();
            FieldExceptions = new HashSet<FieldException>();
            foreach (string field in referenceDataRequest.Fields)
            {
                Fields.Add(field, null);
            }
        }

        public SecurityData(ReferenceDataResponse context, Element securityData) :
            this(context.GetDescription())
        {
            _securityData = securityData;
            Security = _securityData.GetElementAsString("security");
            SequenceNr = _securityData.GetElementAsInt32("sequenceNumber");

            if (_securityData.HasElement("securityError"))
            {
                _securityError = new SecurityError(_securityData.GetElement("securityError"));
            }
            else
            {
                if (_securityData.HasElement("fieldData"))
                {
                    Element _fieldDataArray = _securityData.GetElement("fieldData");
                    for (int i = 0; i < context.Fields.Count; i++)
                    {
                        if (_fieldDataArray.HasElement(context.Fields[i]))
                        {
                            var field = new FieldData(_fieldDataArray.GetElement(context.Fields[i]));
                            Fields[field.Name] = field;
                        }
                    }
                }

                if (_securityData.HasElement("fieldExceptions"))
                {
                    Element _fieldExceptionsArray = _securityData.GetElement("fieldExceptions");
                    for (int i = 0; i < _fieldExceptionsArray.NumValues; i++)
                    {
                        FieldExceptions.Add(new FieldException(_fieldExceptionsArray.GetValueAsElement(i)));
                    }
                }
            }
        }

        public string Security { get; set; }

        public int Valor { get; set; }

        public int SequenceNr { get; set; }

        public Dictionary<string, FieldData> Fields { get; set; }

        public HashSet<FieldException> FieldExceptions { get; set; }

        public SecurityError SecurityError
        {
            get { return _securityError; }
        }
    }
}