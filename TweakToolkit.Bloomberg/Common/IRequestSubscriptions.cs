using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Common
{
    public interface IRequestSubscriptions : IRequestSecurities
    {
        int SubscriptionCount { get; }

        List<Subscription> Subscriptions { get; }
    }
}