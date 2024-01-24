namespace TestDataGeneration.UnitTests;

static class HelperMethods
{
    internal static readonly Random SharedRandom = new();

    internal static T GetRandomItem<T>(IList<T> list)
    {
        if (list is null || list.Count == 0) return default!;
        return list[(list.Count == 1) ? 0 : SharedRandom.Next(0, list.Count)];
    }
    
    internal static T GetRandomItem<T>(params T[] items) => GetRandomItem((IList<T>)items);
    
    internal static IEnumerable<T> GetRandomItems<T>(int count, IList<T> list)
    {
        if (count > 0 && list is not null && list.Count > 0)
        {
            if (list.Count == 1)
            {
                T i = list[0];
                for (var n = 0; n < count; n++) yield return i;
            }
            else
                for (var n = 0; n < count; n++) yield return list[SharedRandom.Next(0, list.Count)];
        }
    }
    
    internal static IEnumerable<T> GetRandomItems<T>(int minCount, int maxCount, IList<T> list)
    {
        int count = (minCount == maxCount) ? minCount : SharedRandom.Next(minCount, maxCount + 1);
        if (count > 0 && list is not null && list.Count > 0)
        {
            if (list.Count == 1)
            {
                T i = list[0];
                for (var n = 0; n < count; n++) yield return i;
            }
            else
                for (var n = 0; n < count; n++) yield return list[SharedRandom.Next(0, list.Count)];
        }
    }
    
    internal static IEnumerable<T> GetRandomItems<T>(int count, params T[] items) => GetRandomItems(count, (IList<T>)items);
    
    internal static IEnumerable<T> GetRandomItems<T>(int minCount, int maxCount, params T[] items) => GetRandomItems(minCount, maxCount, (IList<T>)items);
    
    internal static string GetRandomString(int minLength, int maxLength, params char[] chars) => new(GetRandomItems(minLength, maxLength, chars).ToArray());

    internal static string GetRandomString(int length, params char[] chars) => new(GetRandomItems(length, chars).ToArray());

    internal static string GetRandomString(int minLength, int maxLength, IList<char> chars) => new(GetRandomItems(minLength, maxLength, chars).ToArray());

    internal static string GetRandomString(int minLength, int maxLength, string chars) => new(GetRandomItems(minLength, maxLength, chars.ToCharArray()).ToArray());

    internal static string GetRandomString(int length, IList<char> chars) => new(GetRandomItems(length, chars).ToArray());

    internal static string GetRandomString(int length, string chars) => new(GetRandomItems(length, chars.ToCharArray()).ToArray());

    internal static int GetRandomIntByLength(int minLength, int maxLength, bool nonZero = false)
    {
        int length = (minLength == maxLength) ? minLength : SharedRandom.Next(minLength, maxLength + 1);
        if (length < 2) return SharedRandom.Next(nonZero ? 1 : 0, 10);
        int minValue = 10, maxValue = 100;
        while (length > 2)
        {
            minValue *= 10;
            if (maxValue * 10L > int.MaxValue)
            {
                maxValue = int.MaxValue;
                break;
            }
            maxValue *= 10;
        }
        return SharedRandom.Next(minValue, maxValue);
    }

    internal static IEnumerable<char> GetAllTestCharacters()
    {
        for (char c = char.MinValue; c < char.MaxValue; c++)
            yield return c;
        yield return char.MaxValue;
    }

    internal static void AssertCompleteEnumTestCoverage<T>(T flag, T expectedValue, T[]? notExpectedValues = null)
        where T : struct, Enum
    {
        T[] v;
        if (expectedValue.Equals(flag)) Assert.Inconclusive($"The {nameof(expectedValue)} is the same as {nameof(flag)} {flag:F}");
        if (notExpectedValues is null)
            v = Enum.GetValues<T>().Where(c => !expectedValue.Equals(c)).ToArray();
        else
        {
            if (notExpectedValues.Contains(flag)) Assert.Inconclusive($"The {nameof(notExpectedValues)} array contains {flag:F}");
            if (notExpectedValues.Distinct().Count() != notExpectedValues.Length) Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: The {nameof(notExpectedValues)} array has duplicate values.");
            if (notExpectedValues.Contains(expectedValue)) Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: The {nameof(expectedValue)} exists in the {nameof(notExpectedValues)} array");
            v = Enum.GetValues<T>().Where(c => !c.Equals(flag) && !expectedValue.Equals(c) && !notExpectedValues.Contains(c)).ToArray();
        }
        switch (v.Length)
        {
            case 0:
                break;
            case 1:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} is not the {nameof(expectedValue)} and does not exist in the {nameof(notExpectedValues)} array");
                break;
            case 2:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} are not the {nameof(expectedValue)} and do not exist in the {nameof(notExpectedValues)} array");
                break;
            default:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} are not the {nameof(expectedValue)} and do not exist in the {nameof(notExpectedValues)} array");
                break;
        }
    }

    internal static void AssertCompleteEnumTestCoverage<T>(T flag, T[]? expectedValues, T[]? notExpectedValues)
        where T : struct, Enum
    {
        T[] v;
        if (expectedValues is null)
        {
            if (notExpectedValues is null)
                v = Enum.GetValues<T>().Where(c => !c.Equals(flag)).ToArray();
            else
            {
                if (notExpectedValues.Contains(flag)) Assert.Inconclusive($"The {nameof(notExpectedValues)} array contains {flag:F}");
                if (notExpectedValues.Distinct().Count() != notExpectedValues.Length)
                    switch ((v = notExpectedValues.GroupBy(v => v).Where(g => g.Skip(1).Any()).Select(g => g.Key).ToArray()).Length)
                    {
                        case 0:
                            break;
                        case 1:
                            Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} has duplicate values in the {nameof(notExpectedValues)} array");
                            break;
                        case 2:
                            Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} have duplicate values in the {nameof(notExpectedValues)} array");
                            break;
                        default:
                            Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} have duplicate values in the {nameof(notExpectedValues)} array");
                            break;
                    }
                v = Enum.GetValues<T>().Where(c => !c.Equals(flag) && !notExpectedValues.Contains(c)).ToArray();
            }
        }
        else
        {
            if (expectedValues.Contains(flag)) Assert.Inconclusive($"The {nameof(expectedValues)} array contains {flag:F}");
            if (expectedValues.Distinct().Count() != expectedValues.Length)
                switch ((v = expectedValues.GroupBy(v => v).Where(g => g.Skip(1).Any()).Select(g => g.Key).ToArray()).Length)
                {
                    case 0:
                        break;
                    case 1:
                        Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} has duplicate values in the {nameof(expectedValues)} array");
                        break;
                    case 2:
                        Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} have duplicate values in the {nameof(expectedValues)} array");
                        break;
                    default:
                        Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} have duplicate values in the {nameof(expectedValues)} array");
                        break;
                }
            if (notExpectedValues is null)
                v = Enum.GetValues<T>().Where(c => !c.Equals(flag) && !expectedValues.Contains(c)).ToArray();
            else
            {
                if (notExpectedValues.Contains(flag)) Assert.Inconclusive($"The {nameof(notExpectedValues)} array contains {flag:F}");
                if (notExpectedValues.Distinct().Count() != notExpectedValues.Length)
                    switch ((v = notExpectedValues.GroupBy(v => v).Where(g => g.Skip(1).Any()).Select(g => g.Key).ToArray()).Length)
                    {
                        case 0:
                            break;
                        case 1:
                            Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} has duplicate values in the {nameof(notExpectedValues)} array");
                            break;
                        case 2:
                            Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} have duplicate values in the {nameof(notExpectedValues)} array");
                            break;
                        default:
                            Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} have duplicate values in the {nameof(notExpectedValues)} array");
                            break;
                    }
                switch ((v = expectedValues.Where(c => notExpectedValues.Contains(c)).ToArray()).Length)
                {
                    case 0:
                        break;
                    case 1:
                        Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} exists in both the {nameof(expectedValues)} and {nameof(notExpectedValues)} arrays");
                        break;
                    case 2:
                        Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} exist in both the {nameof(expectedValues)} and {nameof(notExpectedValues)} arrays");
                        break;
                    default:
                        Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} exist in both the {nameof(expectedValues)} and {nameof(notExpectedValues)} arrays");
                        break;
                }
                v = Enum.GetValues<T>().Where(c => !c.Equals(flag) && !expectedValues.Contains(c) && !notExpectedValues.Contains(c)).ToArray();
            }
        }
        switch (v.Length)
        {
            case 0:
                break;
            case 1:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} does not exist in neither the {nameof(expectedValues)} nor the {nameof(notExpectedValues)} array");
                break;
            case 2:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} are not included in neither the {nameof(expectedValues)} nor the {nameof(notExpectedValues)} array");
                break;
            default:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} are not included in neither the {nameof(expectedValues)} nor the {nameof(notExpectedValues)} array");
                break;
        }
    }

    internal static void AssertCompleteEnumTestCoverage<T>(T flag, T[]? expectedValues, T notExpectedValue)
        where T : struct, Enum
    {
        T[] v;
        if (notExpectedValue.Equals(flag)) Assert.Inconclusive($"The {nameof(notExpectedValue)} is the same as {nameof(flag)} {flag:F}");
        if (expectedValues is null)
            v = Enum.GetValues<T>().Where(c => !notExpectedValue.Equals(c)).ToArray();
        else
        {
            if (expectedValues.Contains(flag)) Assert.Inconclusive($"The {nameof(expectedValues)} array contains {flag:F}");
            if (expectedValues.Distinct().Count() != expectedValues.Length) Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: The {nameof(expectedValues)} array has duplicate values.");
            if (expectedValues.Contains(notExpectedValue)) Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: The {nameof(notExpectedValue)} exists in the {nameof(expectedValues)} array");
            v = Enum.GetValues<T>().Where(c => !c.Equals(flag) && !notExpectedValue.Equals(c) && !expectedValues.Contains(c)).ToArray();
        }
        switch (v.Length)
        {
            case 0:
                break;
            case 1:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} is not the {nameof(notExpectedValue)} and does not exist in the {nameof(expectedValues)} array");
                break;
            case 2:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {v[0]:F} and {v[1]:F} are not the {nameof(notExpectedValue)} and do not exist in the {nameof(expectedValues)} array");
                break;
            default:
                Assert.Inconclusive($"Where {nameof(flag)} is {flag:F}: {string.Join(", ", v[0..^2])}, and {v[^1]:F} are not the {nameof(notExpectedValue)} and do not exist in the {nameof(expectedValues)} array");
                break;
        }
    }
}
