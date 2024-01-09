namespace TestDataGeneration.UnitTests
{
    public class SequentialRangeSetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddValueTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            var value = 'x';
            var actual = target.Add(value);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AddRangeValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            Assert.That(target.First, Is.Null);
            Assert.That(target.Last, Is.Null);
            var start1 = 'd';
            var end1 = 'f';
            target.Add(start1, end1);
            var first = target.First;
            Assert.That(first, Is.Not.Null);
            Assert.That(target.Last, Is.Not.Null);
            Assert.That(target.Last, Is.SameAs(first));
            Assert.That(first.Previous, Is.Null);
            Assert.That(first.Next, Is.Null);
            Assert.That(first.Start, Is.EqualTo(start1));
            Assert.That(first.End, Is.EqualTo(end1));
            Assert.That(first.IsSingleValue, Is.False);
            Assert.That(first.Owner, Is.SameAs(target));

            var value1 = 'w';
            target.Add(value1);
            Assert.That(target.First, Is.Not.Null);
            Assert.That(target.First, Is.SameAs(first));
            var last = target.Last;
            Assert.That(last, Is.Not.Null);
            Assert.That(first.Previous, Is.Null);
            Assert.That(first.Next, Is.Not.Null);
            Assert.That(first.Next, Is.SameAs(last));
            Assert.That(last.Previous, Is.Not.Null);
            Assert.That(last.Previous, Is.SameAs(first));
            Assert.That(last.Next, Is.Null);
            Assert.That(first.Start, Is.EqualTo(start1));
            Assert.That(first.End, Is.EqualTo(end1));
            Assert.That(last.Start, Is.EqualTo(value1));
            Assert.That(last.End, Is.EqualTo(value1));
            Assert.That(last.IsSingleValue, Is.True);
            Assert.That(first.IsSingleValue, Is.False);
            Assert.That(first.Owner, Is.SameAs(target));
            Assert.That(last.Owner, Is.SameAs(target));

            var start2 = 'k';
            var end2 = 'm';
            target.Add(start2, end2);
            var middle = first.Next;
            Assert.That(middle, Is.Not.Null);
            Assert.That(target.First, Is.Not.Null);
            Assert.That(target.First, Is.SameAs(first));
            Assert.That(middle, Is.Not.Null);
            Assert.That(target.Last, Is.Not.Null);
            Assert.That(target.Last, Is.SameAs(last));
            Assert.That(first, Is.Not.SameAs(last));
            Assert.That(middle, Is.Not.SameAs(last));
            Assert.That(first.Start, Is.EqualTo(start1));
            Assert.That(first.End, Is.EqualTo(end1));
            Assert.That(middle.Start, Is.EqualTo(start2));
            Assert.That(middle.End, Is.EqualTo(end2));
            Assert.That(last.Start, Is.EqualTo(value1));
            Assert.That(last.End, Is.EqualTo(value1));
            Assert.That(first.Owner, Is.SameAs(target));
            Assert.That(middle.Owner, Is.SameAs(target));
            Assert.That(last.Owner, Is.SameAs(target));
            Assert.That(first.Previous, Is.Null);
            Assert.That(middle.Previous, Is.Not.Null);
            Assert.That(middle.Previous, Is.SameAs(first));
            Assert.That(middle.Next, Is.Not.Null);
            Assert.That(middle.Next, Is.SameAs(last));
            Assert.That(last.Previous, Is.Not.Null);
            Assert.That(last.Previous, Is.SameAs(middle));
            Assert.That(last.Next, Is.Null);
        }

        [Test]
        public void AddRangeItemTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            var item = new SequentialRangeSet<char>.RangeItem('n', 'z', SequentialRangeSet.CharRangeAccessors.Instance);
            target.Add(item);
            Assert.That(item.Owner, Is.SameAs(target));
        }

        [Test]
        public void ClearTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
            var first = target.First;
            var last = target.Last;
            Assert.That(first, Is.Not.Null);
            Assert.That(last, Is.Not.Null);
            var middle = first.Next;
            Assert.That(middle, Is.Not.Null);
            Assert.That(first.Owner, Is.Not.Null);
            Assert.That(middle.Owner, Is.Not.Null);
            Assert.That(last.Owner, Is.Not.Null);
            Assert.That(first.Owner, Is.SameAs(target));
            Assert.That(middle.Owner, Is.SameAs(target));
            Assert.That(last.Owner, Is.SameAs(target));
            Assert.That(first.Previous, Is.Null);
            Assert.That(middle.Previous, Is.Not.Null);
            Assert.That(middle.Previous, Is.SameAs(first));
            Assert.That(middle.Next, Is.Not.Null);
            Assert.That(middle.Next, Is.SameAs(last));
            Assert.That(last.Previous, Is.Not.Null);
            Assert.That(last.Previous, Is.SameAs(middle));
            Assert.That(last.Next, Is.Null);
            target.Clear();
            Assert.That(target.First, Is.Null);
            Assert.That(target.Last, Is.Null);
            Assert.That(first.Owner, Is.Null);
            Assert.That(middle.Owner, Is.Null);
            Assert.That(last.Owner, Is.Null);
            Assert.That(first.Previous, Is.Null);
            Assert.That(middle.Previous, Is.Null);
            Assert.That(last.Previous, Is.Null);
            Assert.That(first.Next, Is.Null);
            Assert.That(middle.Next, Is.Null);
            Assert.That(last.Next, Is.Null);
        }

        [Test]
        public void ContainsValueTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'c', 'g' },
                'm',
                { 'l', 'y' }
            };
            var actual = target.Contains('a');
            Assert.That(actual, Is.False);
            actual = target.Contains('c');
            Assert.That(actual, Is.True);
            actual = target.Contains('e');
            Assert.That(actual, Is.True);
            actual = target.Contains('g');
            Assert.That(actual, Is.True);
            actual = target.Contains('h');
            Assert.That(actual, Is.False);
            actual = target.Contains('l');
            Assert.That(actual, Is.False);
            actual = target.Contains('m');
            Assert.That(actual, Is.True);
            actual = target.Contains('l');
            Assert.That(actual, Is.False);
            actual = target.Contains('k');
            Assert.That(actual, Is.False);
            actual = target.Contains('l');
            Assert.That(actual, Is.True);
            actual = target.Contains('y');
            Assert.That(actual, Is.True);
            actual = target.Contains('z');
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ContainsItemTest()
        {
            var item1 = new SequentialRangeSet<char>.RangeItem('c', 'g', SequentialRangeSet.CharRangeAccessors.Instance);
            var item2 = new SequentialRangeSet<char>.RangeItem('m', SequentialRangeSet.CharRangeAccessors.Instance);
            var item3 = new SequentialRangeSet<char>.RangeItem('l', 'y', SequentialRangeSet.CharRangeAccessors.Instance);
            var item4 = new SequentialRangeSet<char>.RangeItem('l', 'y', SequentialRangeSet.CharRangeAccessors.Instance);
            var target = new SequentialRangeSet.CharRangeSet
            {
                item1,
                item2,
                item3
            };

            var actual = target.Contains(item1);
            Assert.That(actual, Is.True);
            actual = target.Contains(item2);
            Assert.That(actual, Is.True);
            actual = target.Contains(item3);
            Assert.That(actual, Is.True);
            actual = target.Contains(item4);
            Assert.That(actual, Is.False);
            target.Remove(item2);
            actual = target.Contains(item2);
            Assert.That(actual, Is.False);
        }

        [Test]
        public void CountTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }

        [Test]
        public void GetAllValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }

        [Test]
        public void GetAvailableRangesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }

        [Test]
        public void GetEnumeratorTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }

        [Test]
        public void RemoveValueTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }

        [Test]
        public void RemoveRangeValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }

        [Test]
        public void RemoveItemTest()
        {
            var target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'z' }
            };
        }
    }
}