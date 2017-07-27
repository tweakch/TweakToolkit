using System;

namespace TweakToolkit.EntityFramework
{
    public class CreatedEventArgs : EventArgs
    {
        public CreatedEventArgs(CreateMessage message, object item)
        {
            Message = message;
            Item = item;
        }

        public CreateMessage Message { get; set; }

        public object Item { get; private set; }
    }
}