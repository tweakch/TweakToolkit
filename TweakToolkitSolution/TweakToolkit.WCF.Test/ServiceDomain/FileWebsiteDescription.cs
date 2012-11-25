using System.IO;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class FileWebsiteDescription
    {
        public FileWebsiteDescription()
        {
            
        }

        public byte[] ByteFile { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }

        public int SortOrder { get; set; }

        public int Valor { get; set; }
    }
}