namespace SmartHome.ViewModels
{
    public class LightStateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isLightOn)
            {
                return isLightOn ? Color.FromArgb("#FBEC5D") : Color.FromArgb("#708090");
            }
            return Color.FromArgb("#708090");
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
