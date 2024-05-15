namespace DelegatesAndEvents;

public static class Extension
{
    public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, double> convertToNumber) where T : class
    {
        T? retValue = null;
        double max = double.MinValue;
        foreach (T item in collection)
        {
            double d = convertToNumber(item);
            if (d > max)
            {
                retValue = item;
                max = d;
            }
        }

        return retValue;
    }
}
