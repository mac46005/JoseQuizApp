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
                    color = Color.FromHex("#c2f0c2");
                }
                else
                {
                    color = Color.FromHex("#ffb3b3");
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
