using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

namespace com.mxply.net.logging
{
    public class Config
    {
        static void CheckKey(string key)
        {
            bool success;
            CfgUtils.ExisteKeyEnCfg(key, out success);
            if (!success)
                CfgUtils.ThrowRequisiteException(key, "Clave de configuración no encontrada");

        }
        static string _zipTempFolder;
        public static String ZipTempFolder
        {
            get
            {
                if (_zipTempFolder == null) CheckKey("ZipTempFolder");
                return _zipTempFolder = ConfigurationManager.AppSettings.Get("ZipTempFolder");
            }
        }
        public static String VirtualPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            }
        }
    }
}
