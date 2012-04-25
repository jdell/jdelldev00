using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;

namespace com.mxply.net.common.Core
{
    public abstract class ActionBL<T>
    {
        protected abstract string GetConnectionName();
        protected string ConnectionName
        {
            get
            {
                return GetConnectionName();
            }
        }

        internal bool Implements(Type typeInterface)
        {
            return this.GetType().GetInterfaces().Contains(typeInterface);
        }

        public delegate void ProcessingHandler(ProgressEventArgs e);
        public event ProcessingHandler Processing;

        protected void OnProcessing(ProgressEventArgs e)
        {
            if (Processing != null)
                Processing(e);
        }


        bool _systemAction = false;
        internal bool SystemAction
        {
            get
            {
                return _systemAction;
            }
            set
            {
                _systemAction = value;
            }
        }
        protected ICache Cache { get; set; }
        public T execute(ICache cache)
        {
            try
            {
                this.Cache = cache;

                //  if ((!SystemAction)) //&& (_common.cache.MANTENIMIENTO != null) && (_common.cache.MANTENIMIENTO.EnMantenimiento))
                //  throw new _exceptions.common.OutOfServiceException("Aplicación fuera de servicio en estos momentos. Inténtelo más tarde.");

                if (!IsAllowed)
                    throw new Exceptions.AccessNotAllowedException();

                T res;// = null;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    res = action();

                    ts.Complete();
                }

                return res;
            }
            catch (System.Data.Common.DbException ex)
            {
                throw new Exceptions.BaseException(ex);
            }
            catch (Exceptions.BaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exceptions.BaseException(ex);
            }
        }
        protected abstract object action();

        protected String ConnectionString
        {
            get
            {
                //TODO: Connection String
                Uri p = new Uri(System.Reflection.Assembly.GetCallingAssembly().CodeBase);
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(p.LocalPath);
//#if !DEBUG
//#else
//                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(@"C:\Users\jreynoso\Desktop\dev\eSignature\Acs.eSignature.lib\bin\Debug\Acs.eSignature.lib.DLL");

//#endif
                System.Configuration.ConnectionStringSettings connectionString = config.ConnectionStrings.ConnectionStrings[this.ConnectionName];
                return connectionString.ConnectionString;
            }
        }

        private bool IsAllowed
        {
            get
            {
                bool res = false;

                res = true;

                //if (_common.cache.EMPLEADO != null)
                //{
                //    if (!res) res = ((Permiso & tPERMISO.GERENTE) != 0) && _common.cache.EMPLEADO.Gerente;
                //if (!res) res = ((Permiso & tPERMISO.ADMINISTRATIVO) != 0);// && _common.cache.USER.Administrativo;
                //    if (!res) res = ((Permiso & tPERMISO.TERAPEUTA) != 0) && _common.cache.EMPLEADO.Terapeuta;
                //if (!res) res = ((Permiso & tPERMISO.MASTERUSER) != 0) && ((_common.cache.IsMasterUser) || (_common.cache.IsSystemUser));
                //    if (!res) res = ((Permiso & tPERMISO.NINGUNO) != 0) && false;
                //    if (!res) res = SystemAction;
                //}
                //else
                //    res = SystemAction;


                return res;
            }
        }

    }

}
