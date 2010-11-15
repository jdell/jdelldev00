using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Exceptions
{
    public class MissingIdException : BaseException
    {
        public MissingIdException(Type t, string actionName)
            : base(String.Format("Missing Id! [Type : {0} - Action : {1}]", t.Name, actionName))
        {
        }
    }
}
