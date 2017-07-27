using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Common;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    public abstract class AEventHandlerBase : ISessionEventHandler
    {
        protected static readonly Name ExceptionElementId = new Name("exceptions");
        protected static readonly Name FieldIdElementId = new Name("fieldId");
        protected static readonly Name ReasonElementId = new Name("reason");
        protected static readonly Name CategoryElementId = new Name("category");
        protected static readonly Name DescriptionElementId = new Name("description");
        protected static readonly Name IdElementId = new Name("id");
        protected static readonly Name FieldMnemonicElementId = new Name("mnemonic");
        protected static readonly Name FieldDataElementId = new Name("fieldData");
        protected static readonly Name FieldDescElementId = new Name("description");
        protected static readonly Name FieldInfoElementId = new Name("fieldInfo");
        protected static readonly Name FieldErrorElementId = new Name("fieldError");
        protected static readonly Name FieldMsgElementId = new Name("message");

        private static int _counter;
        protected int id;

        protected AEventHandlerBase()
        {
            id = _counter++;
        }

        public abstract void ProcessEvent(Event eventObj, BloombergSessionWrapper session);
    }
}