namespace TweakToolkit.EntityFramework.Strategies
{
    public class CreateHouseStrategy : GatewayStrategy
    {
        public CreateHouseStrategy(TweakTestDataEntities db)
        {
            Db = db;
        }

        public TweakTestDataEntities Db { get; set; }

        protected override object DoWork(object message)
        {
            var createMessage = message as CreateMessage;
            if (createMessage == null) return false;

            var house = createMessage.Item as House;

            if (house != null && house.Address != null)
            {
                Db.HouseSet.Add(house);
                return Db.SaveChanges() > 0;
            }
            return house;
        }
    }
}