using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MyToolkit.MVVM;
using TweakToolkit.Bloomberg.Exceptions;
using TweakToolkit.Bloomberg.Wrapper;

namespace TweakToolkit.Bloomberg
{
    public abstract class ABloombergHandlerBase<TNotify> : NotifyPropertyChanged<TNotify>
        where TNotify : ABloombergHandlerBase<TNotify>
    {
        protected Dictionary<DataService, string> ServiceHostNames = new Dictionary<DataService, string>
                                                                         {
                                                                             {DataService.MarketData, "//blp/mktdata"},
                                                                             {
                                                                                 DataService.ReferenceData,
                                                                                 "//blp/refdata"
                                                                             },
                                                                             {DataService.HistoryData, "//blp/histdata"},
                                                                             {DataService.FieldData, "//blp/apiflds"}
                                                                         };

        private DataService dataServiceType;

        protected ABloombergHandlerBase(DataService service)
        {
            SetDataService(service);
        }

        protected ABloombergHandlerBase()
            : this(DataService.Undefined)
        {
        }

        protected BloombergSessionWrapper SessionWrapper { get; set; }

        /// <summary>
        ///     Setting this property will do the following things to the programm flow:
        ///     1. Return if the current value is equal to the new one
        ///     2. Create a Session to bloomberg
        ///     - if there isn't already one or
        ///     - if the DataServiceType has changed
        /// </summary>
        private DataService DataServiceType
        {
            get { return dataServiceType; }
            set
            {
                if (IsCorrectSession(value)) return;
                dataServiceType = value;
                CreateSession(value);
                try
                {
                    if (OpenSerivce()) return;
                    if (SessionWrapper != null) SessionWrapper.Stop();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(KeyNotFoundException))
                    {
                        Console.WriteLine("DataServiceType was not found. " + value);
                    }
                    else
                    {
                        throw new OpenServiceException(ex);
                    }
                }
            }
        }

        public int Port
        {
            get { return SessionWrapper.Port; }
            set
            {
                SessionWrapper.Port = value;
                RaisePropertyChanged(m => m.Port);
            }
        }

        public string Host
        {
            get { return SessionWrapper.Host; }
            set
            {
                SessionWrapper.Host = value;
                RaisePropertyChanged(m => m.Host);
            }
        }

        private bool IsCorrectSession(DataService newServiceType)
        {
            return (SessionWrapper != null && DataServiceType == newServiceType);
        }

        private bool StartSession()
        {
            return SessionWrapper.Start();
        }

        public void StopSession()
        {
            SessionWrapper.Stop();
        }

        private void SetDataService(DataService service)
        {
            DataServiceType = service;
        }

        public abstract bool ParseCommandLine(string[] args);

        public abstract void PrintUsage();

        private bool OpenSerivce()
        {
            return SessionWrapper.OpenService(ServiceHostNames[DataServiceType]);
        }

        private void CreateSession(DataService service)
        {
            if (SessionWrapper != null) StopSession();
            SessionWrapper = new BloombergSessionWrapper();
            SessionWrapper.PropertyChanged += SessionWrapperPropertyChanged;
            if (!StartSession()) throw new SessionNotStartedException();
            SetDataService(service);
            RegisterEventHandlers(SessionWrapper);
        }

        protected abstract void RegisterEventHandlers(BloombergSessionWrapper wrapper);

        private void SessionWrapperPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }

        protected static bool DoesMatch(string s, string s1)
        {
            return string.Compare(s, s1, true, CultureInfo.CurrentCulture) == 0;
        }
    }
}