using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Core
{
    public abstract class BaseCache:ICache
    {
        public abstract bool InitializeApp();
        public abstract bool FinalizeApp();

        protected abstract bool CheckDBIntegrity();
    }

    public interface ICache
    {
        bool InitializeApp();
        bool FinalizeApp();
    }
}
