using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Exceptions
{
    public class NullReferenceException : BaseException
    {
        public NullReferenceException(Type t, string actionName)
            : base(String.Format("Null object! [Type : {0} - Action : {1}]", t.Name, actionName))
        {
        }
    }
}
