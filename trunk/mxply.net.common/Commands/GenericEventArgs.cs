using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.common.Commands
{
    public class GenericEventArgs<T> : System.EventArgs
    {
        /// <summary>
        /// Contained value
        /// </summary>
        public T Value { get; set; }

        public GenericEventArgs()
            : base()
        {
        }

        public GenericEventArgs(T value)
            : this()
        {
            Value = value;
        }
    }
}
