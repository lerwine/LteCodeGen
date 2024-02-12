using System.Numerics;
using NUnit.Framework.Internal;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests;

public partial class NumberRangesListTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorTest0()
    {
        var target = new NumberRangesList<char>();
        Assert.That(target, Is.Empty);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorWithNumberExtentsArgsTestData))]
    public NumberExtents<char>[] ConstructorWithNumberExtentsArgsTest1((char First, char Last)[] list, int expectedCount)
    {
        var target = new NumberRangesList<char>(list.AsEnumerable());
        Assert.That(target.Count, Is.EqualTo(expectedCount));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorWithNumberExtentsArgsTestData))]
    public NumberExtents<char>[] ConstructorWithNumberExtentsArgsTest2((char First, char Last)[] list, int expectedCount)
    {
        var target = new NumberRangesList<char>(list);
        Assert.That(target.Count, Is.EqualTo(expectedCount));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorWithTupleArgsTestData))]
    public NumberExtents<char>[] ConstructorWithTupleArgsTest1((char First, char Last)[] list, int expectedCount)
    {
        var target = new NumberRangesList<char>(list.AsEnumerable());
        Assert.That(target, Has.Count.EqualTo(expectedCount));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorWithTupleArgsTestData))]
    public NumberExtents<char>[] ConstructorWithTupleArgsTest2((char First, char Last)[] list, int expectedCount)
    {
        var target = new NumberRangesList<char>(list);
        Assert.That(target, Has.Count.EqualTo(expectedCount));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd1Test1Data))]
    public NumberExtents<char>[] Add1Test1(NumberExtents<char>[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(value);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd1Test2Data))]
    public NumberExtents<char>[] Add1Test2(NumberExtents<char>[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(value);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd1Test3Data))]
    public NumberExtents<char>[] Add1Test3(NumberExtents<char>[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(value);
        Assert.That(actual, Is.False);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd1Test4Data))]
    public NumberExtents<char>[] Add1Test4(NumberExtents<char>[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(value);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd1Test5Data))]
    public NumberExtents<char>[] Add1Test5(NumberExtents<char>[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(value);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd1Test6Data))]
    public NumberExtents<char>[] Add1Test6(NumberExtents<char>[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(value);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test1Data))]
    public NumberExtents<char>[] Add2Test1(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test2Data))]
    public NumberExtents<char>[] Add2Test2(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test3Data))]
    public NumberExtents<char>[] Add2Test3(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test4Data))]
    public NumberExtents<char>[] Add2Test4(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test5Data))]
    public NumberExtents<char>[] Add2Test5(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test6Data))]
    public NumberExtents<char>[] Add2Test6(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test7Data))]
    public NumberExtents<char>[] Add2Test7(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test8Data))]
    public NumberExtents<char>[] Add2Test8(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test9Data))]
    public NumberExtents<char>[] Add2Test9(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.False);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test10Data))]
    public NumberExtents<char>[] Add2Test10(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test11Data))]
    public NumberExtents<char>[] Add2Test11(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAdd2Test12Data))]
    public NumberExtents<char>[] Add2Test12(NumberExtents<char>[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Add(first, last);
        Assert.That(actual, Is.True);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetClearTestData))]
    public void ClearTest((char First, char Last)[] list)
    {
        var target = new NumberRangesList<char>(list);
        target.Clear();
        Assert.That(target, Has.Count.EqualTo(0));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetContains1Test1Data))]
    public bool Contains1Test1((char First, char Last)[] list, char value)
    {
        var target = new NumberRangesList<char>(list);
        return target.Contains(value);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetContains1Test2Data))]
    public bool Contains1Test2((char First, char Last)[] list, NumberExtents<char> item)
    {
        var target = new NumberRangesList<char>(list);
        return target.Contains(item);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetContains2TestData))]
    public bool Contains2Test((char First, char Last)[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        return target.Contains(first, last);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetContainsAllTestData))]
    public bool ContainsAllTest((char First, char Last)[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        return target.ContainsAll(first, last);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetItemAtTestData))]
    public NumberExtents<char> GetItemAtTest((char First, char Last)[] list, int index)
    {
        var target = new NumberRangesList<char>(list);
        return target.GetItemAt(index);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetValueAtTestData))]
    public char GetValueAtTest((char First, char Last)[] list, BigInteger index)
    {
        var target = new NumberRangesList<char>(list);
        return target.GetValueAt(index);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetValueCountTestData))]
    public BigInteger GetValueCountTest((char First, char Last)[] list)
    {
        var target = new NumberRangesList<char>(list);
        return target.GetValueCount();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIndexOfTestData))]
    public int IndexOfTest((char First, char Last)[] list, NumberExtents<char> value)
    {
        var target = new NumberRangesList<char>(list);
        return target.IndexOf(value);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIsProperSubsetOfTestData))]
    public bool IsProperSubsetOfTest((char First, char Last)[] list, IEnumerable<NumberExtents<char>> other)
    {
        var target = new NumberRangesList<char>(list);
        return target.IsProperSubsetOf(other);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIsProperSupersetOfTestData))]
    public bool IsProperSupersetOfTest((char First, char Last)[] list, IEnumerable<NumberExtents<char>> other)
    {
        var target = new NumberRangesList<char>(list);
        return target.IsProperSupersetOf(other);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIsSubsetOfTestData))]
    public bool IsSubsetOfTest((char First, char Last)[] list, IEnumerable<NumberExtents<char>> other)
    {
        var target = new NumberRangesList<char>(list);
        return target.IsSubsetOf(other);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIsSupersetOfTestData))]
    public bool IsSupersetOfTest((char First, char Last)[] list, IEnumerable<NumberExtents<char>> other)
    {
        var target = new NumberRangesList<char>(list);
        return target.IsSupersetOf(other);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetOverlapsTestData))]
    public bool OverlapsTest((char First, char Last)[] list, IEnumerable<NumberExtents<char>> other)
    {
        var target = new NumberRangesList<char>(list);
        return target.Overlaps(other);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAnyOverlapsTestData))]
    public bool AnyOverlapsTest((char First, char Last)[] list, char first, char last)
    {
        var target = new NumberRangesList<char>(list);
        return target.AnyOverlaps(first, last);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetRemove1Test1Data))]
    public NumberExtents<char>[] Remove1Test1((char First, char Last)[] list, char value, bool expectedResult)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Remove(value);
        Assert.That(actual, Is.EqualTo(expectedResult));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetRemove1Test2Data))]
    public NumberExtents<char>[] Remove1Test2((char First, char Last)[] list, NumberExtents<char> item, bool expectedResult)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Remove(item);
        Assert.That(actual, Is.EqualTo(expectedResult));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetRemove2TestData))]
    public NumberExtents<char>[] Remove2Test((char First, char Last)[] list, char first, char last, bool expectedResult)
    {
        var target = new NumberRangesList<char>(list);
        var actual = target.Remove(first, last);
        Assert.That(actual, Is.EqualTo(expectedResult));
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetRemoveAtTestData))]
    public NumberExtents<char>[] RemoveAtTest((char First, char Last)[] list, int index)
    {
        var target = new NumberRangesList<char>(list);
        target.RemoveAt(index);
        return target.ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetSetEqualsTestData))]
    public bool SetEqualsTest((char First, char Last)[] list, IEnumerable<NumberExtents<char>> other)
    {
        var target = new NumberRangesList<char>(list);
        return target.SetEquals(other);
    }
}