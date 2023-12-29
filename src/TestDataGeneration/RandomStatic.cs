using System.Collections.ObjectModel;

namespace TestDataGeneration;

public static class RandomStatic
{
    internal static Random Random { get; } = new();

    internal static bool GetRandomBoolean() => Random.Next(0, 2) == 1;

    internal static int GetRandomInteger(int minValue, int maxValue)
    {
        if (minValue > maxValue)
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} cannot be greater than {nameof(maxValue)}.");
        if (minValue == maxValue) return minValue;
        if (maxValue != int.MaxValue) return Random.Next(minValue, maxValue + 1);
        if (minValue == int.MinValue) return GetRandomBoolean() ? Random.Next(-1, maxValue) + 1 : Random.Next(minValue, 0);
        return Random.Next(minValue - 1, maxValue) + 1;
    }

    internal static IEnumerable<int> GetRandomIntegers(int repeat, int minValue, int maxValue)
    {
        if (minValue > maxValue)
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} cannot be greater than {nameof(maxValue)}.");
        if (minValue == maxValue)
            for (int i = 0; i < repeat; i++) yield return minValue;
        else if (maxValue != int.MaxValue)
            for (int i = 0; i < repeat; i++) yield return Random.Next(minValue, maxValue + 1);
        else if (minValue == int.MinValue)
            for (int i = 0; i < repeat; i++) yield return GetRandomBoolean() ? Random.Next(-1, maxValue) + 1 : Random.Next(minValue, 0);
        else
            for (int i = 0; i < repeat; i++) yield return Random.Next(minValue - 1, maxValue) + 1;
    }

    internal static IEnumerable<int> GetRandomIntegers(int minRepeat, int maxRepeat, int minValue, int maxValue)
    {
        if (minRepeat > maxRepeat)
            throw new ArgumentOutOfRangeException(nameof(minRepeat), $"{nameof(minRepeat)} cannot be greater than {nameof(maxRepeat)}.");
        return GetRandomIntegers(GetRandomInteger(minRepeat, maxRepeat), minValue, maxValue);
    }

    internal static T GetRandom<T>(ICollection<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source.Count < 1) throw new ArgumentException("Input collection cannot be empty.", nameof(source));
        if (source.Count == 1) return source.First();
        return source.Skip(GetRandomInteger(0, source.Count)).First();
    }

    internal static IEnumerable<T> PickRandom<T>(IList<T> source, int count)
    {
        if (source is null || count < 1 || source.Count == 0) yield break;
        if (source.Count <= count)
            foreach (T item in source)
                yield return item;
        else
        {
            int i = GetRandomInteger(0, source.Count);
            yield return source[i];
            if (count > 1)
            {
                Collection<int> indexes = new();
                for (var r = 1; r < count; r++)
                {
                    indexes.Add(i);
                    i = GetRandomInteger(0, source.Count);
                    while (indexes.Contains(i)) i = GetRandomInteger(0, source.Count);
                    yield return source[i];
                }
            }
        }
    }

    internal static IEnumerable<T> PickRandom<T>(IList<T> source, int minCount, int maxCount)
    {
        if (minCount > maxCount)
            throw new ArgumentOutOfRangeException(nameof(minCount), $"{nameof(minCount)} cannot be greater than {nameof(maxCount)}.");
        return PickRandom(source, GetRandomInteger(minCount, maxCount));
    }
}