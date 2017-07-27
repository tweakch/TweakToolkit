namespace TweakToolkit.EntityFramework
{
    public class CreateMessage
    {
        public CreateMessage(object item)
        {
            Item = item;
        }

        public object Item { get; private set; }
    }
}