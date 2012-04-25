using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace com.mxply.net.common.Converts
{
    public class BooleanConverterTo<T> : IValueConverter
    {
        public T True { get; set; }
        public T False { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Boolean)
            {
                return ((bool)value) ? True : False;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanToVisibilityConverter : BooleanConverterTo<Visibility>
    {
        public BooleanToVisibilityConverter()
            : base()
        {
            True = Visibility.Visible;
            False = Visibility.Collapsed;
        }
    }
}
