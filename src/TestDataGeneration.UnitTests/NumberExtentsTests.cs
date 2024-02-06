using System.Numerics;
using NUnit.Framework;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public partial class NumberExtentsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTest1Data))]
        public bool IsMoreThanOneAfterTest1(char value, NumberExtents<char> extents)
        {
            return value.IsMoreThanOneAfter(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTest2Data))]
        public bool IsMoreThanOneAfterTest2(NumberExtents<char> extents, char value)
        {
            return NumberExtents.IsMoreThanOneAfter(extents, value);
        }
        
        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTest1Data))]
        public bool IsMoreThanOneAfterTest3(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsMoreThanOneAfter(list.AddLast(extents));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTest2Data))]
        public bool IsMoreThanOneAfterTest4(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).IsMoreThanOneAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneAfterTest1Data))]
        public bool IsNotMoreThanOneAfterTest1(char value, NumberExtents<char> extents)
        {
            return value.IsNotMoreThanOneAfter(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneAfterTest2Data))]
        public bool IsNotMoreThanOneAfterTest2(NumberExtents<char> extents, char value)
        {
            return extents.IsNotMoreThanOneAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneAfterTest1Data))]
        public bool IsNotMoreThanOneAfterTest3(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsNotMoreThanOneAfter(list.AddLast(extents));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneAfterTest2Data))]
        public bool IsNotMoreThanOneAfterTest4(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).IsNotMoreThanOneAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTest1Data))]
        public bool IsMoreThanOneBeforeTest1(char value, NumberExtents<char> extents)
        {
            return value.IsMoreThanOneBefore(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTest2Data))]
        public bool IsMoreThanOneBeforeTest2(NumberExtents<char> extents, char value)
        {
            return NumberExtents.IsMoreThanOneBefore(extents, value);
        }
        

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTest1Data))]
        public bool IsMoreThanOneBeforeTest3(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsMoreThanOneBefore(list.AddLast(extents));
        }
        

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTest2Data))]
        public bool IsMoreThanOneBeforeTest4(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).IsMoreThanOneBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneBeforeTest1Data))]
        public bool IsNotMoreThanOneBeforeTest1(char value, NumberExtents<char> extents)
        {
            return value.IsNotMoreThanOneBefore(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneBeforeTest2Data))]
        public bool IsNotMoreThanOneBeforeTest2(NumberExtents<char> extents, char value)
        {
            return extents.IsNotLessThanOneBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneBeforeTest1Data))]
        public bool IsNotMoreThanOneBeforeTest3(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsNotMoreThanOneBefore(list.AddLast(extents));
        }
        

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneBeforeTest2Data))]
        public bool IsNotMoreThanOneBeforeTest4(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).IsNotMoreThanOneBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsLessThanTest1Data))]
        public bool IsLessThanTest1(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsLessThan(list.AddLast(extents));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsLessThanTest2Data))]
        public bool IsLessThanTest2(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).IsLessThan(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsGreaterThanTest1Data))]
        public bool IsGreaterThanTest1(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsGreaterThan(list.AddLast(extents));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsGreaterThanTest2Data))]
        public bool IsGreaterThanTest2(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).IsGreaterThan(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsIncludedInTestData))]
        public bool IsIncludedInTest(char value, NumberExtents<char> extents)
        {
            LinkedList<NumberExtents<char>> list = new();
            return value.IsIncludedIn(list.AddLast(extents));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIncludesTestData))]
        public bool IncludesTest(NumberExtents<char> extents, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            return list.AddLast(extents).Includes(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetWithFirstTestData))]
        public NumberExtents<char> WithFirstTest(NumberExtents<char> extents, char value)
        {
            return extents.WithFirst(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetWithLastTestData))]
        public NumberExtents<char> WithLastTest(NumberExtents<char> extents, char value)
        {
            return extents.WithLast(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddFirstTest1Data))]
        public NumberExtents<char>[] AddFirstTest1(NumberExtents<char>[] existing, char first, char last)
        {
            LinkedList<NumberExtents<char>> list = new(existing);
            list.AddFirst(first, last);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddFirstTest2Data))]
        public NumberExtents<char>[] AddFirstTest2(NumberExtents<char>[] existing, char value)
        {
            LinkedList<NumberExtents<char>> list = new(existing);
            list.AddFirst(value);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddLastTest1Data))]
        public NumberExtents<char>[] AddLastTest1(NumberExtents<char>[] existing, char first, char last)
        {
            LinkedList<NumberExtents<char>> list = new(existing);
            list.AddLast(first, last);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddLastTest2Data))]
        public NumberExtents<char>[] AddLastTest2(NumberExtents<char>[] existing, char value)
        {
            LinkedList<NumberExtents<char>> list = new(existing);
            list.AddLast(value);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddPreviousTest1Data))]
        public NumberExtents<char>[] AddPreviousTest1(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
        {
            LinkedList<NumberExtents<char>> list = new();
            var node = list.AddLast(target);
            if (before.HasValue) list.AddFirst(before.Value);
            if (after.HasValue) list.AddLast(after.Value);
            node.AddPrevious(first, last);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddPreviousTest2Data))]
        public NumberExtents<char>[] AddPreviousTest2(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            var node = list.AddLast(target);
            if (before.HasValue) list.AddFirst(before.Value);
            if (after.HasValue) list.AddLast(after.Value);
            node.AddPrevious(value);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddNextTest1Data))]
        public NumberExtents<char>[] AddNextTest1(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
        {
            LinkedList<NumberExtents<char>> list = new();
            var node = list.AddLast(target);
            if (before.HasValue) list.AddFirst(before.Value);
            if (after.HasValue) list.AddLast(after.Value);
            node.AddNext(first, last);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAddNextTest2Data))]
        public NumberExtents<char>[] AddNextTest2(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
        {
            LinkedList<NumberExtents<char>> list = new();
            var node = list.AddLast(target);
            if (before.HasValue) list.AddFirst(before.Value);
            if (after.HasValue) list.AddLast(after.Value);
            node.AddNext(value);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetRemoveAndGetNextTestData))]
        public NumberExtents<char>[] RemoveAndGetNextTest(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>[] after, NumberExtents<char>? expected)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.RemoveAndGetNext();
            Assert.That(actual?.Value, Is.EqualTo(expected));
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetRemoveAndGetPreviousTestData))]
        public NumberExtents<char>[] RemoveAndGetPreviousTest(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>[] after, NumberExtents<char>? expected)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.RemoveAndGetPrevious();
            Assert.That(actual?.Value, Is.EqualTo(expected));
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetTryExpandTest1Data))]
        public NumberExtents<char>[] TryExpandTest1(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, NumberExtents<char>[] after)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.TryExpand(first, last);
            Assert.That(actual, Is.False);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetTryExpandTest2Data))]
        public NumberExtents<char>[] TryExpandTest2(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, NumberExtents<char>[] after)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.TryExpand(first, last);
            Assert.That(actual, Is.True);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetTryExpandTest3Data))]
        public NumberExtents<char>[] TryExpandTest3(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, NumberExtents<char>[] after)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.TryExpand(first, last);
            Assert.That(actual, Is.True);
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetTryExpandFirstTestData))]
        public NumberExtents<char>[] TryExpandFirstTest(NumberExtents<char>[] before, NumberExtents<char> target, char value, NumberExtents<char>? after, bool expected)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            if (after.HasValue) list.AddLast(after.Value);
            var actual = node.TryExpandFirst(value);
            Assert.That(actual, Is.EqualTo(expected));
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetTryExpandLastTestData))]
        public NumberExtents<char>[] TryExpandLastTest(NumberExtents<char>? before, NumberExtents<char> target, char value, NumberExtents<char>[] after, bool expected)
        {
            LinkedList<NumberExtents<char>> list = new();
            if (before.HasValue) list.AddLast(before.Value);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.TryExpandLast(value);
            Assert.That(actual, Is.EqualTo(expected));
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetInvalidExtentsTestData))]
        public void InvalidExtentsTest(char first, char last)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new NumberExtents<char>(first, last));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorTestData))]
        public (char First, char Last, BigInteger GetCount) ConstructorTest(char first, char last)
        {
            var target = new NumberExtents<char>(first, last);
            return (target.First, target.Last, target.GetCount());
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetCompareToTestData))]
        public int CompareToTest(NumberExtents<char> lValue, NumberExtents<char> rValue)
        {
            var result = lValue.CompareTo(rValue);
            return (result < 0) ? -1 : (result > 0) ? 1 : 0;
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetEqualsTestData))]
        public bool EqualsTest(NumberExtents<char> lValue, NumberExtents<char> rValue)
        {
            return lValue.Equals(rValue);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetToStringTestData))]
        public string ToStringTest(NumberExtents<char> value)
        {
            return value.ToString();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAsEnumerableTestData))]
        public char[] AsEnumerableTest(NumberExtents<char> value)
        {
            return value.AsEnumerable().ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetContainsTestData))]
        public bool ContainsTest(NumberExtents<char> extents, char value)
        {
            return extents.Contains(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetImmediatelyFollowsTestData))]
        public bool IsFirstAdjacentToTest(NumberExtents<char> extents, char value)
        {
            return extents.ImmediatelyFollows(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetImmediatelyPrecedesTestData))]
        public bool IsLastAdjacentToTest(NumberExtents<char> extents, char value)
        {
            return extents.ImmediatelyPrecedes(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsBeforeTestData))]
        public bool IsBeforeTest(NumberExtents<char> extents, char value)
        {
            return extents.IsBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTestData))]
        public bool IsFirstMoreThanOneAfterTest(NumberExtents<char> extents, char value)
        {
            return extents.IsMoreThanOneAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsAfterTestData))]
        public bool IsAfterTest(NumberExtents<char> extents, char value)
        {
            return extents.IsAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTestData))]
        public bool IsLastMoreThanOneBeforeTest(NumberExtents<char> extents, char value)
        {
            return extents.IsMoreThanOneBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetRelationOfTestData))]
        public ExtentValueRelativity GetRelationOfTest(NumberExtents<char> extents, char value)
        {
            return extents.GetRelationOf(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetRelationToTestData))]
        public ExtentRelativity GetRelationToTest(NumberExtents<char> extents, NumberExtents<char> other)
        {
            return extents.GetRelationTo(other);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetReverseTestData))]
        public char[] ReverseTest(NumberExtents<char> value)
        {
            return value.Reverse().ToArray();
        }
    }
}