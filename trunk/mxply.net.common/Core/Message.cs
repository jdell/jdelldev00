using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Core
{
    public abstract class Message
    {
        public static readonly string NOTIFY_ADMINISTRATOR = "Contact with the administrator.";
        public static readonly string CACHE_NOT_LOADED = "The app cannot be initialized.";
        public static readonly string ACCESS_NOT_ALLOWED = "You are not allowed to execute this action.";
    }
}
