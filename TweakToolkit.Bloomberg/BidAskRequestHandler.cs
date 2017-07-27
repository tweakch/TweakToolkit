using System;
using System.Collections.Generic;
using TweakToolkit.Bloomberg.Properties;

namespace TweakToolkit.Bloomberg
{
    public class BidAskRequestHandler
    {
        private static BloombergReferenceDataHandler bloombergHandler;

        public static BloombergReferenceDataHandler BloombergHandler
        {
            get { return bloombergHandler ?? (bloombergHandler = new BloombergReferenceDataHandler()); }
        }

        public static void Request(List<string> securities)
        {
            BloombergHandler.Clear();
            BloombergHandler.AddField(Settings.Default.Bloomberg_Field_Bid);
            BloombergHandler.AddField(Settings.Default.Bloomberg_Field_Ask);
            BloombergHandler.AddField(Settings.Default.Bloomberg_Field_Time);

            foreach (string security in securities) BloombergHandler.AddSecurity(security);

            //return BloombergHandler.SendRequest();
        }

        public static void RequestAsync(string security, Action<BidAskResponse> callback)
        {
            RequestAsync(new List<string> { security }, callback);
        }

        public static void RequestAsync(List<string> securities, Action<BidAskResponse> callback)
        {
            if (securities.Count == 0)
            {
                callback(null);
            }
            else
            {
                BloombergHandler.Clear();
                BloombergHandler.AddField(Settings.Default.Bloomberg_Field_Bid);
                BloombergHandler.AddField(Settings.Default.Bloomberg_Field_Ask);
                BloombergHandler.AddField(Settings.Default.Bloomberg_Field_Time);

                foreach (string security in securities) BloombergHandler.AddSecurity(security);
                BloombergHandler.SendRequestAsync(response => callback(new BidAskResponse(response)));
            }
        }
    }
}