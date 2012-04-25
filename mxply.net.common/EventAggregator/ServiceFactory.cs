using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.EventAggregator
{
    public static class ServicesFactory
    {
        // Singleton instance of the EventAggregator service
        private static Microsoft.Practices.Composite.Events.EventAggregator eventService = null;

        // Lock (sync) object
        private static object _syncRoot = new object();

        // Factory method
        public static Microsoft.Practices.Composite.Events.EventAggregator EventService
        {
            get
            {
                // Lock execution thread in case of multi-threaded
                // (concurrent) access.
                lock (_syncRoot)
                {
                    if (null == eventService)
                    {
                        eventService = new Microsoft.Practices.Composite.Events.EventAggregator();
                    }
                    // Return singleton instance
                    return eventService;
                } // lock
            }
        }
    }
}
