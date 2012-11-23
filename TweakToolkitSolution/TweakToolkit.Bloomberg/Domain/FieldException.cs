using System;
using System.Runtime.Serialization;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Domain
{
    [Serializable]
    public class FieldException : Exception
    {
        private readonly string _message;
        private string _fieldId;

        private Element element;

        public FieldException()
        {
        }

        public FieldException(string message)
            : base(message)
        {
            _message = message;
        }

        public FieldException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected FieldException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public FieldException(Element element)
        {
            // TODO: Complete member initialization
            this.element = element;
        }

        public string FieldId
        {
            get { return _fieldId; }
            set { _fieldId = value; }
        }

        public override string Message
        {
            get { return _message; }
        }

        public ErrorInfo Info { get; set; }
    }
}