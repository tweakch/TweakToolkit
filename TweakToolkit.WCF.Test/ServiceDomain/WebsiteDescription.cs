using System;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public abstract class WebsiteDescription
    {
        protected static string AssignString(object obj)
        {
            return (string)(obj ?? string.Empty);
        }

        protected static int AssignInteger(object obj)
        {
            return (int)(obj ?? 0);
        }

        protected static DateTime AssignDateTime(object obj)
        {
            return (DateTime)(obj ?? new DateTime(1900, 1, 1));
        }
    }
}