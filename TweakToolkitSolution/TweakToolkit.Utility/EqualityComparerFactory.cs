using System.Collections.Generic;

namespace TweakToolkit.Utility
{
    public class EqualityComparerFactory
    {
        public static IEqualityComparer<T> Create<T>()
        {
            return new EqualityComparer<T>();
        }
    }
}