using System;
using System.Globalization;
using Xamarin.Forms;

namespace ListView
{
   
       
        public class IntToBoolConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
            return value="Gray";//return (int)value != 0;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)value ? 1 : 0;
            }
        }


}

