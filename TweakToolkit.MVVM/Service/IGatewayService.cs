namespace TweakToolkit.MVVM.Service
{
    public interface IGatewayService
    {
        void Read();

        object Create();

        event ReadModelsCompletedHandler ReadCompleted;

        void Update(object model);
    }
}