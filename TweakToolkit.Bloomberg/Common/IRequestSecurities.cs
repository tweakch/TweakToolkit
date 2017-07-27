using System.Collections.Generic;

namespace TweakToolkit.Bloomberg.Common
{
    public interface IRequestSecurities
    {
        int FieldCount { get; }

        int SecurityCount { get; }

        List<string> Securities { get; }

        List<string> Fields { get; }

        void AddSecurity(string ticker);

        void AddField(string field);

        void Clear();
    }
}