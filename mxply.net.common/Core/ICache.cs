using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Core
{
    public abstract class BaseCache
    {
        public abstract bool InitializeApp();
        public abstract bool FinalizeApp();

        protected abstract bool CheckDBIntegrity();
    }
}
