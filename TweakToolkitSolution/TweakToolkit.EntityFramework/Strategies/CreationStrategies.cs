namespace TweakToolkit.EntityFramework.Strategies
{
    public class CreationStrategies
    {
        public static GatewayStrategy Resolve(TweakTestDataEntities db, CreateMessage message)
        {
            var item = message.Item;

            if (item is House)
            {
                return new CreateHouseStrategy(db);
            }
            return null;
        }
    }
}