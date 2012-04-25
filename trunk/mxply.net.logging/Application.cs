using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.logging
{
    public class Application
    {
        static Application application;
        bool initialized = false;
        private static object _lockPad = new object();
        private static object _lockPadInitialize = new object();
        
        public static Application SApplication
        {
            get 
            {
                if (application == null)
                {
                    lock (_lockPad)
                    {
                        if (application == null)
                            application = new Application();
                    }
                }
                return application; 
            } 
        }

        private Application()
        {
        }

        public void Initialize(string ApplicationRootPath, string ServiceName)
        {
            if (!initialized)
            {
                lock (_lockPadInitialize)
                {
                    if (!initialized)
                    {
                        if (String.IsNullOrEmpty(ApplicationRootPath))
                            throw new ArgumentNullException("ApplicationRootPath");

                        initialized = true;
                        LogUtil.Manager.Initialize(ApplicationRootPath);
                        CfgUtils.CheckLog4Net(ApplicationRootPath);
                        LogUtil.Manager.Info("***** Carga Aplicación - Servicio [" + ServiceName + "]*****");
                        //TODO: obtener el valor de endpoints del nodo client de web.config y comprobar si la url del site es la misma que en la que estamos en runtime y si no lo es cambiarla.
                      // ej. de como cmabiar algo en web.config http://stackoverflow.com/questions/2260317/change-a-web-config-programmatically-with-c-sharp-net
                    }
                }
            }
        }

    }
}
