using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.EventAggregator
{
    public static class ExtensionServices
    {
        //Supplying event broking mechanizm to each object in the application.
        public static void PublishEvent<TEventsubject>(this TEventsubject eventArgs, string eventTopic)
        {
            ServicesFactory.EventService.GetEvent<GenericEvent<TEventsubject>>()
                .Publish(new EventParameters<TEventsubject> { Topic = eventTopic, Value = eventArgs });
        }
    }
}
