using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using log4net;
using System.Diagnostics;

namespace com.mxply.net.logging
{
    public class LogUtil
    {
        #region varibles privadas
        private static ILog _logger;
        private static LogUtil _instance;
        private static readonly object padlock = new object();
        private bool _initialized;
        #endregion

        #region parte pública

        #region ctor
        private LogUtil()
        {
            
        }
        #endregion

        public void Initialize(string ApplicationRootPath)
        {

            string fullPath = Path.Combine(Path.Combine(ApplicationRootPath, "Config"),
                ConfigurationManager.AppSettings[CfgUtils.CFGKEY_LOG4NETFILE]);

            string logPath = Path.Combine(ApplicationRootPath, "Logs");
            if (!Directory.Exists(logPath))
            {
                try
                {
                    Directory.CreateDirectory(logPath);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("ApplicationRootPath={0} - LogPath={1} - Error={2}", fullPath, logPath, ex);
                }
            }

            log4net.Config.XmlConfigurator.Configure(new FileInfo(fullPath));
            _logger = LogManager.GetLogger(ConfigurationManager.AppSettings[CfgUtils.CFGKEY_LOG4NETLOGGERNAME]);
            _initialized = true;

        }

        private void checkInitialized()
        {
            if (!_initialized)
            {
                Trace.TraceError(string.Format("No se ha inicializado el componente Log4Net"));
                throw new System.Exception("No se ha inicializado el componente Log4Net");
            }
        }

        private string setHighLight(object message)
        {
            return string.Format("-------------------- {0} --------------------", message);
        }

        public void Debug(object message, System.Exception exception)
        {
            checkInitialized();
            _logger.Debug(message, exception);
        }
        public void Debug(object message)
        {
            checkInitialized();
            _logger.Debug(message);
        }

        public void Error(object message, System.Exception exception)
        {
            checkInitialized();
            _logger.Error(message, exception);
        }
        public void Error(object message)
        {
            checkInitialized();
            _logger.Error(message);
        }

        public void Error(System.Exception exception)
        {
            checkInitialized();
            _logger.Error(exception);
        }

        public void Info(object message, bool highlight)
        {
            Info(setHighLight(highlight));
        }
        public void Info(object message)
        {
            checkInitialized();
            _logger.Info(message);
        }

        public void Warn(object message)
        {
            checkInitialized();
            _logger.Warn(message);
        }

        public void Fatal(object message)
        {
            checkInitialized();
            _logger.Fatal(message);
        }

        #endregion

        #region propiedades
        public static LogUtil Manager
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LogUtil();
                        }
                    }
                }
                return _instance;
            }
        }


        public bool Initialized
        {
            get { return _initialized; }
        }

        #endregion
    }
}
