using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RazorTemplateViewer.Convertors
{
    public class BooleanToVisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value is bool b && b;
            if(parameter?.ToString() == "reverse")
            {
                return !boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
         
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility v && v == Visibility.Visible;
        }
    }
}
