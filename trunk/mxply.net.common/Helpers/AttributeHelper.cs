using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace com.mxply.net.common.Helpers
{
    public abstract class AttributeHelper
    {
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        public static bool GetReadOnly(object obj, string propertyName)
        {
            if (obj == null) return true;

            Type type = obj.GetType();

            MemberInfo[] memInfo = type.GetMember(propertyName);

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(ReadOnlyAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((ReadOnlyAttribute)attrs[0]).IsReadOnly;
                }
            }

            return false;
        }

        //public static void SetReadOnly(object obj, bool value, params string[] propertyNames)
        //{
        //    if (obj == null) return;

        //    Type type = obj.GetType();
        //    //PropertyInfo property = type.GetProperty("")

        //    foreach (string propertyName in propertyNames)
        //    {                
        //        MemberInfo[] memInfo = type.GetMember(propertyName);

        //        if (memInfo != null && memInfo.Length > 0)
        //        {
        //            object[] attrs = memInfo[0].GetCustomAttributes(typeof(ReadOnlyAttribute), false);

        //            if (attrs != null && attrs.Length > 0)
        //            {
        //                ((AssignedResource)attrs[0]).Value = "";
        //            }
        //        }
        //    }

        //    return;
        //}
    }
    public abstract class AttributeHelper<T> where T : ICustomAttribute
    {
        public static object GetValue(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(T), false);

                if (attrs != null && attrs.Length > 0)
                    return ((T)attrs[0]).Value;
            }

            return en;
        }

        public static string GetDescription(Enum en)
        {
            object value = GetValue(en);
            return value != null ? Convert.ToString(value) : string.Empty;
        }
        public static double GetCanvasHeight(Enum en)
        {
            object value = GetValue(en);
            double res = 1;
            if (value != null) double.TryParse(Convert.ToString(value), out res);

            return res;
        }
        public static bool IsValidCanvasHeight(Enum en, double height)
        {
            bool res = false;
            foreach (Enum item in Enum.GetValues(en.GetType()))
            {
                object value = GetValue(en);
                double tmp = 1;
                if (value != null) double.TryParse(Convert.ToString(value), out tmp);
                res = height == tmp;
                if (res) break;
            }

            return res;
        }
    }
    public interface ICustomAttribute
    {
        object Value { get; set; }
    }
    public class AssignedResource : Attribute, ICustomAttribute
    {
        public AssignedResource(string resourceName)
            : base()
        {
            _resourceName = resourceName;
        }

        private string _resourceName;
        public object Value
        {
            get
            {
                return _resourceName;
            }
            set
            {
                _resourceName = Convert.ToString(value);
            }
        }
    }
    /// <summary>
    /// Ratio
    /// </summary>
    public class CanvasHeight : Attribute, ICustomAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ratio">A height value</param>
        public CanvasHeight(double height)
            : base()
        {
            Value = height;

        }

        private double _height;
        public object Value
        {
            get
            {
                return _height;
            }
            set
            {
                double tmp = 24;
                if (value != null) Double.TryParse(Convert.ToString(value), out tmp);
                if (tmp < 0) tmp = 0;
                _height = tmp;
            }
        }
    }
}
