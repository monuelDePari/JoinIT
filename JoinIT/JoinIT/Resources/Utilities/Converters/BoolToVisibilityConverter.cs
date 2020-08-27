namespace JoinIT.Resources.Utilities.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility ReturnValue = Visibility.Collapsed;

            if (value is bool)
            {
                switch ((bool)value)
                {
                    case true: ReturnValue = Visibility.Visible; break;
                    case false: ReturnValue = Visibility.Collapsed; break;
                }
            }
            return ReturnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool ReturnValue = false;
            if (value is Visibility)
            {
                switch ((Visibility)value)
                {
                    case Visibility.Visible: ReturnValue = true; break;
                    case Visibility.Collapsed: ReturnValue = false; break;
                    case Visibility.Hidden: ReturnValue = false; break;
                }
            }
            return ReturnValue;
        }
    }
}
