using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ClubUI
{
    public class ColorToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color couleur = (Color)value;
            return new SolidColorBrush(couleur);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
