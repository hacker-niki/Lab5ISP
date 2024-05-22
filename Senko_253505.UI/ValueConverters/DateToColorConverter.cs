using System.Globalization;

namespace Senko_253505.UI.ValueConverters;

public class DateToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var strValue = value.ToString();
        if (strValue != null)
            if (DateTime.Now - DateTime.ParseExact(strValue, "dd.MM.yyyy", null) < TimeSpan.FromDays(365 * 2))
                return Colors.Green;

        return Colors.Red;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}