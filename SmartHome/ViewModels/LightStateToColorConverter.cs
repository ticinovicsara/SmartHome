using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SmartHome.ViewModels
{
    public class LightStateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isLightOn)
            {
                return isLightOn ? Color.FromArgb("#FFD700") : Color.FromArgb("#DBD7D2") ;
            }
            return Color.FromArgb("#DBD7D2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
