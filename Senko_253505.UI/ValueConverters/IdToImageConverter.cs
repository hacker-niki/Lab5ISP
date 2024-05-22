using System.Globalization;

namespace Senko_253505.UI.ValueConverters;

public class IdToImageConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var id = (int)(value ?? 0);
        return $"{FileSystem.CacheDirectory}/{id}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return 0;
    }
}