using System;
using System.Collections.Generic;
using System.IO;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Test
{
    public class TweakMessage : Message
    {
        public override string TopicName
        {
            get { throw new NotImplementedException(); }
        }

        public override Service Service
        {
            get { throw new NotImplementedException(); }
        }

        public override Name MessageType
        {
            get { throw new NotImplementedException(); }
        }

        public override Fragment FragmentType
        {
            get { throw new NotImplementedException(); }
        }

        public override CorrelationID CorrelationID
        {
            get { throw new NotImplementedException(); }
        }

        public override int NumCorrelationIDs
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerable<CorrelationID> CorrelationIDs
        {
            get { throw new NotImplementedException(); }
        }

        public override Element AsElement
        {
            get { throw new NotImplementedException(); }
        }

        public override bool IsValid
        {
            get { throw new NotImplementedException(); }
        }

        public override CorrelationID GetCorrelationID(int position)
        {
            throw new NotImplementedException();
        }

        public override bool HasElement(Name name)
        {
            throw new NotImplementedException();
        }

        public override bool HasElement(Name name, bool excludeNullElements)
        {
            throw new NotImplementedException();
        }

        public override bool HasElement(string name)
        {
            throw new NotImplementedException();
        }

        public override bool HasElement(string name, bool excludeNullElements)
        {
            throw new NotImplementedException();
        }

        public override Element GetElement(Name name)
        {
            throw new NotImplementedException();
        }

        public override Element GetElement(string name)
        {
            throw new NotImplementedException();
        }

        public override bool GetElementAsBool(Name name)
        {
            throw new NotImplementedException();
        }

        public override bool GetElementAsBool(string name)
        {
            throw new NotImplementedException();
        }

        public override char GetElementAsChar(Name name)
        {
            throw new NotImplementedException();
        }

        public override char GetElementAsChar(string name)
        {
            throw new NotImplementedException();
        }

        public override int GetElementAsInt32(Name name)
        {
            throw new NotImplementedException();
        }

        public override int GetElementAsInt32(string name)
        {
            throw new NotImplementedException();
        }

        public override long GetElementAsInt64(Name name)
        {
            throw new NotImplementedException();
        }

        public override long GetElementAsInt64(string name)
        {
            throw new NotImplementedException();
        }

        public override double GetElementAsFloat64(Name name)
        {
            throw new NotImplementedException();
        }

        public override double GetElementAsFloat64(string name)
        {
            throw new NotImplementedException();
        }

        public override float GetElementAsFloat32(Name name)
        {
            throw new NotImplementedException();
        }

        public override float GetElementAsFloat32(string name)
        {
            throw new NotImplementedException();
        }

        public override string GetElementAsString(Name name)
        {
            throw new NotImplementedException();
        }

        public override string GetElementAsString(string name)
        {
            throw new NotImplementedException();
        }

        public override byte[] GetElementAsBytes(Name name)
        {
            throw new NotImplementedException();
        }

        public override byte[] GetElementAsBytes(string name)
        {
            throw new NotImplementedException();
        }

        public override Datetime GetElementAsDatetime(Name name)
        {
            throw new NotImplementedException();
        }

        public override Datetime GetElementAsDatetime(string name)
        {
            throw new NotImplementedException();
        }

        public override Datetime GetElementAsDate(Name name)
        {
            throw new NotImplementedException();
        }

        public override Datetime GetElementAsDate(string name)
        {
            throw new NotImplementedException();
        }

        public override Datetime GetElementAsTime(Name name)
        {
            throw new NotImplementedException();
        }

        public override Datetime GetElementAsTime(string name)
        {
            throw new NotImplementedException();
        }

        public override Name GetElementAsName(Name name)
        {
            throw new NotImplementedException();
        }

        public override Name GetElementAsName(string name)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void Print(Stream output)
        {
            throw new NotImplementedException();
        }

        public override void Print(TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}