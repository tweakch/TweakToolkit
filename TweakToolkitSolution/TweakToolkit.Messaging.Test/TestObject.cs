namespace TweakToolkit.Messaging.Test
{
    public class TestObject
    {
        public TestObject(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}