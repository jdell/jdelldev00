using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Exceptions
{
    public class ValidatingException : BaseException
    {
        public ValidatingException(string message)
            : base(message)
        {
        }
        public ValidatingException(string message, string detail)
            : base(message, detail)
        {
        }
    }
}
