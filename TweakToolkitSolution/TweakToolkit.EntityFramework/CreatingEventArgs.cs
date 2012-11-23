using System;

namespace TweakToolkit.EntityFramework
{
    public class CreatingEventArgs : EventArgs
    {
        public CreatingEventArgs(CreateMessage message)
        {
            Message = message;
        }

        public CreateMessage Message { get; private set; }

        public bool Result { get; set; }
    }
}