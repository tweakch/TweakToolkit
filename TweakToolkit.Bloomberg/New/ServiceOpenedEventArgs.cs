using System;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class ServiceOpenedEventArgs  : EventArgs
    {
        public Service Service { get; set; }

        public ServiceOpenedEventArgs(Service service)
        {
            Service = service;
        }
    }
}