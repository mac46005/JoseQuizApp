using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace JoseQuizApp.Converters
{
    class SecondaryColorResultItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color colorResult = Color.Accent;
            if (value is bool)
            {
                bool isTrue = (bool)value;
                if (isTrue == true)
                {
                    //dark green
                    colorResult = Color.FromHex("#004d00");

                }
                else
                {
                    //dark red
                    colorResult = Color.FromHex("#990000");

                }
            }
            return colorResult;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
