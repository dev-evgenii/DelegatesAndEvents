using System.Globalization;

namespace DelegatesAndEvents;

public class Convertor
{
    public static double StringToDouble(string item)
    {
        item = item.Replace(',', '.');
        var isValidDouble = double.TryParse(item, NumberStyles.Any, CultureInfo.InvariantCulture, out var validDouble);

        if (isValidDouble)
        {
            return validDouble;
        }

        Console.WriteLine($"{item} wasn't recognized like a valid double");

        return double.MinValue;
    }
}
