namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class IssuerRatingWebsiteDescription
    {
        public int IssuerId { get; set; }

        public string Bank { get; set; }

        public string RatingSP { get; set; }

        public string RatingMoody { get; set; }

        public string RatingFitch { get; set; }

        public System.DateTime DateSP { get; set; }

        public System.DateTime DateMoody { get; set; }

        public System.DateTime DateFitch { get; set; }

        public string CommentEN { get; set; }

        public string Comment { get; set; }

        public string Website { get; set; }

        public string LogoFileName { get; set; }

        public byte[] ByteLogo { get; set; }
    }
}