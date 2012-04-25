using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Wpf.Events;

namespace com.mxply.net.common.EventAggregator
{
    public class GenericEvent<TValue> : CompositeWpfEvent<EventParameters<TValue>> { }

    public class EventParameters<TValue>
    {
        public string Topic { get; set; }
        public TValue Value { get; set; }
    }
}
