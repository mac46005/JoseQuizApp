using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace JoseQuizApp.Converters
{
    public class ResultItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = Color.Accent;
            if (value is bool)
            {
                bool isTrue = (bool)value;
                if (isTrue == true)
                {
                    //green
                    color = Color.FromHex("#00802b");
                }
                else
                {
                    //red
                    color = Color.FromHex("#ff4d4d");
                }


            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
