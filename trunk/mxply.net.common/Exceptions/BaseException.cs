using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(Exception ex)
            : base(string.Format("BaseException - {0}", ex.Message), ex)
        {
        }
        public BaseException(Exception ex, string message)
            : base(message, ex)
        {
        }
        public BaseException(string message)
            : base(message)
        {
        }
        public BaseException(string message, string detail)
            : base(message)
        {
            this._detail = detail;
        }

        private string _detail = string.Empty;
        public string Detail
        {
            get { return _detail; }
        }

        public string FullMessage
        {
            get
            {
                return String.Format("{0} {1}", this.Message, this._detail).Trim();
            }
        }

    }

}
