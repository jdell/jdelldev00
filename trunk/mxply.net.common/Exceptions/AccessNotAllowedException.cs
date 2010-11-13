using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Exceptions
{
    public class AccessNotAllowedException : ValidatingException
    {
        public AccessNotAllowedException()
            : base(Core.Message.ACCESS_NOT_ALLOWED, Core.Message.NOTIFY_ADMINISTRATOR)
        {
        }
    }
}
