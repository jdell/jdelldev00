using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace com.mxply.net.logging
{
    public class CfgUtils
    {
        public const string CFGKEY_LOG4NETFILE = "Log4NetFile";
        public const string CFGKEY_LOG4NETLOGGERNAME = "Log4NetLoggerName";


        public static void CheckLog4Net(string ApplicationRootPath)
        {
            bool success;
            string retorno = ExisteKeyEnCfg(CFGKEY_LOG4NETFILE, out success);

            if (success)
            {
                string loggerName = ExisteKeyEnCfg(CFGKEY_LOG4NETLOGGERNAME, out success);

                if (success)
                {
                    string logPath = Path.Combine(Path.Combine(ApplicationRootPath, "Config"),
              ConfigurationManager.AppSettings[CFGKEY_LOG4NETFILE]);


                    if (!File.Exists(logPath))
                        ThrowRequisiteException("CheckLog4Net", String.Format("El fichero especificado no existe ({0}) [{1}]", retorno, logPath));

                    if (String.IsNullOrEmpty(loggerName))
                        ThrowRequisiteException("CheckLog4Net", "El Logger especificado no existe (" + loggerName + ")");

                }
                else
                    ThrowRequisiteException(CFGKEY_LOG4NETLOGGERNAME, "Clave de configuración no encontradda");
            }
            else ThrowRequisiteException(CFGKEY_LOG4NETFILE, "Clave de configuración no encontradda");

            LogUtil.Manager.Info("CheckLog4Net : [OK]");
        }

        public static void ThrowRequisiteException(string checkRequisiteName)
        {
            string msg = String.Format("{0} : [ERROR]", checkRequisiteName);
            if (LogUtil.Manager.Initialized)
                LogUtil.Manager.Error(msg);
            throw new Exception(msg);
        }

        public static void ThrowRequisiteException(string checkRequisiteName, string checkRequisiteMessage)
        {
            string msg = String.Format("{0} : [ERROR] ({1})", checkRequisiteName, checkRequisiteMessage);
            if (LogUtil.Manager.Initialized)
                LogUtil.Manager.Error(msg);
            throw new Exception(msg);
        }

        /// <summary>
        /// Indica si existe una clave en el fichero de configuración
        /// </summary>
        /// <param name="key">Clave de la sección de configuración a recuperar</param>
        /// <param name="success">Indica si la clave existe o no en el fichero de configuración</param>
        /// <returns>Valor en el fichero de configuración de la clave</returns>
        public static string ExisteKeyEnCfg(string key, out bool success)
        {
            string keyValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(keyValue))
            {
                if (LogUtil.Manager.Initialized)
                    LogUtil.Manager.Warn(String.Format("La clave solicitada : {0} no existe en el fichero de configuración", key));
                success = false;
                return String.Empty;
            }

            success = true;
            return keyValue;

        }

    }
}
