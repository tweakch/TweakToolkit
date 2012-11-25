namespace TweakToolkit.WCF.Test.Wrapper
{
    public class BaseValueWebsiteDescription
    {
        public BaseValueWebsiteDescription(EntityFramework.WebsiteData.BaseValueWebsiteData data)
        {
            Valor = data.Valor;
            Name = data.Name;
        }

        public int Valor { get; set; }

        public string Name { get; set; }
    }
}