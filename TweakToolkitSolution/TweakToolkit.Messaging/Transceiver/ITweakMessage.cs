using System;

namespace TweakToolkit.Messaging.Transceiver
{
    public interface ITweakMessage
    {
        string DisplayName { get; set; }

        string Message { get; set; }

        Guid TransmitterId { get; set; }
    }
}