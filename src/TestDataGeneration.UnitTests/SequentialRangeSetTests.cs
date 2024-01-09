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
            var value_x = 'x';
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(setChangeToken, Is.Not.Null);
            var actual = target.Add(value_x);
            // {
            //     item_x = { Start = 'x', End = 'x' }
            // }
            var item_x = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_x, Is.Not.Null);
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_x));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_x));
                Assert.That(item_x.End, Is.EqualTo(value_x));
                Assert.That(item_x.Previous, Is.Null);
                Assert.That(item_x.Next, Is.Null);
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
            });
            var changeToken_x = ((IHasChangeToken)item_x).ChangeToken;
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken_x, Is.Not.Null);
                Assert.That(setChangeToken, Is.Not.Null);
            });

            var value_u = 'u';
            actual = target.Add(value_u);
            // {
            //     item_u = { Start = 'u', End = 'u' },
            //     item_x = { Start = 'x', End = 'x' }
            // }
            var item_u = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_u, Is.Not.Null);
                Assert.That(item_u, Is.Not.SameAs(item_x));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_x));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_u.IsSingleValue, Is.True);
                Assert.That(item_u.Start, Is.EqualTo(value_u));
                Assert.That(item_u.End, Is.EqualTo(value_u));
                Assert.That(item_u.Previous, Is.Null);
                Assert.That(item_u.Next, Is.Not.Null);
                Assert.That(item_u.Next, Is.SameAs(item_x));
                Assert.That(item_u.Owner, Is.Not.Null);
                Assert.That(item_u.Owner, Is.SameAs(target));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_x));
                Assert.That(item_x.End, Is.EqualTo(value_x));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Null);
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_x).ChangeToken, Is.SameAs(changeToken_x));
            });
            var changeToken_u = ((IHasChangeToken)item_u).ChangeToken;
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken_u, Is.Not.Null);
                Assert.That(setChangeToken, Is.Not.Null);
            });

            var value_z = 'z';
            actual = target.Add(value_z);
            // {
            //     item_u = { Start = 'u', End = 'u' },
            //     item_x = { Start = 'x', End = 'x' },
            //     item_z = { Start = 'z', End = 'z' }
            // }
            var item_z = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_z, Is.Not.Null);
                Assert.That(item_z, Is.Not.SameAs(item_u));
                Assert.That(item_z, Is.Not.SameAs(item_x));
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_u));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_u.IsSingleValue, Is.True);
                Assert.That(item_u.Start, Is.EqualTo(value_u));
                Assert.That(item_u.End, Is.EqualTo(value_u));
                Assert.That(item_u.Previous, Is.Null);
                Assert.That(item_u.Next, Is.Not.Null);
                Assert.That(item_u.Next, Is.SameAs(item_x));
                Assert.That(item_u.Owner, Is.Not.Null);
                Assert.That(item_u.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_u).ChangeToken, Is.SameAs(changeToken_u));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_x));
                Assert.That(item_x.End, Is.EqualTo(value_x));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Not.Null);
                Assert.That(item_x.Next, Is.SameAs(item_z));
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_x).ChangeToken, Is.SameAs(changeToken_x));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_z.IsSingleValue, Is.True);
                Assert.That(item_z.Start, Is.EqualTo(value_z));
                Assert.That(item_z.End, Is.EqualTo(value_z));
                Assert.That(item_z.Previous, Is.Not.Null);
                Assert.That(item_z.Previous, Is.SameAs(item_x));
                Assert.That(item_z.Next, Is.Null);
                Assert.That(item_z.Owner, Is.Not.Null);
                Assert.That(item_z.Owner, Is.SameAs(target));
            });
            var changeToken_z = ((IHasChangeToken)item_z).ChangeToken;
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken_z, Is.Not.Null);
                Assert.That(setChangeToken, Is.Not.Null);
            });

            var value_w = 'w';
            actual = target.Add(value_w);
            // {
            //     item_u = { Start = 'u', End = 'u' },
            //     item_x = { Start = 'w', End = 'x' },
            //     item_z = { Start = 'z', End = 'z' }
            // }
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_u));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_z));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_u.IsSingleValue, Is.True);
                Assert.That(item_u.Start, Is.EqualTo(value_u));
                Assert.That(item_u.End, Is.EqualTo(value_u));
                Assert.That(item_u.Previous, Is.Null);
                Assert.That(item_u.Next, Is.Not.Null);
                Assert.That(item_u.Next, Is.SameAs(item_x));
                Assert.That(item_u.Owner, Is.Not.Null);
                Assert.That(item_u.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_u).ChangeToken, Is.SameAs(changeToken_u));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_w));
                Assert.That(item_x.End, Is.EqualTo(value_x));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Not.Null);
                Assert.That(item_x.Next, Is.SameAs(item_z));
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_x).ChangeToken, Is.Not.SameAs(changeToken_x));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_z.IsSingleValue, Is.True);
                Assert.That(item_z.Start, Is.EqualTo(value_z));
                Assert.That(item_z.End, Is.EqualTo(value_z));
                Assert.That(item_z.Previous, Is.Not.Null);
                Assert.That(item_z.Previous, Is.SameAs(item_x));
                Assert.That(item_z.Next, Is.Null);
                Assert.That(item_z.Owner, Is.Not.Null);
                Assert.That(item_z.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_z).ChangeToken, Is.SameAs(changeToken_z));
            });
            changeToken_x = ((IHasChangeToken)item_x).ChangeToken;
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken_x, Is.Not.Null);
                Assert.That(setChangeToken, Is.Not.Null);
            });

            var value_y = 'y';
            actual = target.Add(value_y);
            // {
            //     item_u = { Start = 'u', End = 'u' },
            //     item_x = { Start = 'w', End = 'z' }
            // }
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_u));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_x));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_u.IsSingleValue, Is.True);
                Assert.That(item_u.Start, Is.EqualTo(value_u));
                Assert.That(item_u.End, Is.EqualTo(value_u));
                Assert.That(item_u.Previous, Is.Null);
                Assert.That(item_u.Next, Is.Not.Null);
                Assert.That(item_u.Next, Is.SameAs(item_x));
                Assert.That(item_u.Owner, Is.Not.Null);
                Assert.That(item_u.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_u).ChangeToken, Is.SameAs(changeToken_u));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_w));
                Assert.That(item_x.End, Is.EqualTo(value_z));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Null);
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_x).ChangeToken, Is.Not.SameAs(changeToken_x));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_z.IsSingleValue, Is.True);
                Assert.That(item_z.Start, Is.EqualTo(value_z));
                Assert.That(item_z.End, Is.EqualTo(value_z));
                Assert.That(item_z.Previous, Is.Null);
                Assert.That(item_z.Next, Is.Null);
                Assert.That(item_z.Owner, Is.Null);
                Assert.That(((IHasChangeToken)item_z).ChangeToken, Is.SameAs(changeToken_z));
            });
            changeToken_x = ((IHasChangeToken)item_x).ChangeToken;
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken_x, Is.Not.Null);
                Assert.That(setChangeToken, Is.Not.Null);
            });
            
            foreach (char c in new char[] { value_u, value_w, value_x, value_y, value_z })
            {
                actual = target.Add(c);
                Assert.Multiple(() =>
                {
                    Assert.That(actual, Is.False);
                    Assert.That(target.First, Is.Not.Null);
                    Assert.That(target.First, Is.SameAs(item_u));
                    Assert.That(target.Last, Is.Not.Null);
                    Assert.That(target.Last, Is.SameAs(item_x));
                    Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
                });
                Assert.Multiple(() =>
                {
                    Assert.That(item_u.IsSingleValue, Is.True);
                    Assert.That(item_u.Start, Is.EqualTo(value_u));
                    Assert.That(item_u.End, Is.EqualTo(value_u));
                    Assert.That(item_u.Previous, Is.Null);
                    Assert.That(item_u.Next, Is.Not.Null);
                    Assert.That(item_u.Next, Is.SameAs(item_x));
                    Assert.That(item_u.Owner, Is.Not.Null);
                    Assert.That(item_u.Owner, Is.SameAs(target));
                    Assert.That(((IHasChangeToken)item_u).ChangeToken, Is.SameAs(changeToken_u));
                });
                Assert.Multiple(() =>
                {
                    Assert.That(item_x.IsSingleValue, Is.True);
                    Assert.That(item_x.Start, Is.EqualTo(value_w));
                    Assert.That(item_x.End, Is.EqualTo(value_z));
                    Assert.That(item_x.Previous, Is.Not.Null);
                    Assert.That(item_x.Previous, Is.SameAs(item_u));
                    Assert.That(item_x.Next, Is.Null);
                    Assert.That(item_x.Owner, Is.Not.Null);
                    Assert.That(item_x.Owner, Is.SameAs(target));
                    Assert.That(((IHasChangeToken)item_x).ChangeToken, Is.SameAs(changeToken_x));
                });
            }

            var value_Z = 'Z';
            actual = target.Add(value_Z);
            // {
            //     item_Z = { Start = 'Z', End = 'Z' },
            //     item_u = { Start = 'u', End = 'u' },
            //     item_x = { Start = 'w', End = 'z' }
            // }
            var item_Z = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(item_Z, Is.Not.Null);
                Assert.That(item_Z, Is.Not.SameAs(item_u));
                Assert.That(item_Z, Is.Not.SameAs(item_x));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_x));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_Z.IsSingleValue, Is.True);
                Assert.That(item_Z.Start, Is.EqualTo(value_Z));
                Assert.That(item_Z.End, Is.EqualTo(value_Z));
                Assert.That(item_Z.Previous, Is.Null);
                Assert.That(item_Z.Next, Is.Not.Null);
                Assert.That(item_Z.Next, Is.SameAs(item_u));
                Assert.That(item_Z.Owner, Is.Not.Null);
                Assert.That(item_Z.Owner, Is.SameAs(target));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_u.IsSingleValue, Is.True);
                Assert.That(item_u.Start, Is.EqualTo(value_u));
                Assert.That(item_u.End, Is.EqualTo(value_u));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_Z));
                Assert.That(item_u.Next, Is.Not.Null);
                Assert.That(item_u.Next, Is.SameAs(item_x));
                Assert.That(item_u.Owner, Is.Not.Null);
                Assert.That(item_u.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_u).ChangeToken, Is.SameAs(changeToken_u));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_w));
                Assert.That(item_x.End, Is.EqualTo(value_z));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Null);
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
                Assert.That(((IHasChangeToken)item_x).ChangeToken, Is.SameAs(changeToken_x));
            });
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
            var value_a = 'a';
            var value_f = 'f';
            var value_m = 'm';
            var value_k = 'k';
            var value_z = 'z';
            var target = new SequentialRangeSet.CharRangeSet();
            target.Add(start: value_a, end: value_f);
            target.Add(value: value_m);
            target.Add(start: value_k, end: value_z);
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
            var not_contains_A = 'A';
            var not_contains_B = 'B';
            var start_C = 'C';
            var not_contains_c = 'c';
            var contains_E = 'E';
            var end_G = 'G';
            var not_contains_H = 'H';
            var not_contains_l = 'l';
            var value_m = 'm';
            var not_contains_n = 'n';
            var not_contains_o = 'o';
            var start_p = 'p';
            var contains_q = 'q';
            var not_contains_S = 'S';
            var contains_x = 'x';
            var end_y = 'y';
            var not_contains_z = 'z';
            var target = new SequentialRangeSet.CharRangeSet();
            target.Add(start: start_C, end: end_G);
            target.Add(value: value_m);
            target.Add(start: start_p, end: end_y);
            var actual = target.Contains(not_contains_A);
            Assert.That(actual, Is.False);
            actual = target.Contains(not_contains_B);
            Assert.That(actual, Is.False);
            actual = target.Contains(start_C);
            Assert.That(actual, Is.True);
            actual = target.Contains(not_contains_c);
            Assert.That(actual, Is.False);
            actual = target.Contains(contains_E);
            Assert.That(actual, Is.True);
            actual = target.Contains(end_G);
            Assert.That(actual, Is.True);
            actual = target.Contains(not_contains_H);
            Assert.That(actual, Is.False);
            actual = target.Contains(not_contains_l);
            Assert.That(actual, Is.False);
            actual = target.Contains(value_m);
            Assert.That(actual, Is.True);
            actual = target.Contains(not_contains_n);
            Assert.That(actual, Is.False);
            actual = target.Contains(not_contains_o);
            Assert.That(actual, Is.False);
            actual = target.Contains(start_p);
            Assert.That(actual, Is.True);
            actual = target.Contains(contains_q);
            Assert.That(actual, Is.True);
            actual = target.Contains(not_contains_S);
            Assert.That(actual, Is.False);
            actual = target.Contains(contains_x);
            Assert.That(actual, Is.True);
            actual = target.Contains(end_y);
            Assert.That(actual, Is.True);
            actual = target.Contains(not_contains_z);
            Assert.That(actual, Is.False);
        }

        [Test]
        public void ContainsItemTest()
        {
            var item_c_g = new SequentialRangeSet<char>.RangeItem(start: 'c', end: 'g', SequentialRangeSet.CharRangeAccessors.Instance);
            var orphaned_b_h = new SequentialRangeSet<char>.RangeItem(start: 'b', end: 'h', SequentialRangeSet.CharRangeAccessors.Instance);
            var orphaned_d_f = new SequentialRangeSet<char>.RangeItem(start: 'd', end: 'f', SequentialRangeSet.CharRangeAccessors.Instance);
            var orphaned_l_m = new SequentialRangeSet<char>.RangeItem(start: 'l', end: 'm', SequentialRangeSet.CharRangeAccessors.Instance);
            var item_m = new SequentialRangeSet<char>.RangeItem(value: 'm', SequentialRangeSet.CharRangeAccessors.Instance);
            var added_n = 'n';
            var orphaned_m_n = new SequentialRangeSet<char>.RangeItem(start: 'm', end: added_n, SequentialRangeSet.CharRangeAccessors.Instance);
            var item_o_q = new SequentialRangeSet<char>.RangeItem(start: 'o', end: 'q', SequentialRangeSet.CharRangeAccessors.Instance);
            var orphaned_o_q = new SequentialRangeSet<char>.RangeItem(start: 'o', end: 'q', SequentialRangeSet.CharRangeAccessors.Instance);
            var target = new SequentialRangeSet.CharRangeSet
            {
                item_c_g,
                item_m,
                item_o_q
            };

            var actual = target.Contains(item_c_g);
            Assert.That(actual, Is.True);
            actual = target.Contains(orphaned_b_h);
            Assert.That(actual, Is.False);
            actual = target.Contains(orphaned_d_f);
            Assert.That(actual, Is.False);
            actual = target.Contains(orphaned_l_m);
            Assert.That(actual, Is.False);
            actual = target.Contains(item_m);
            Assert.That(actual, Is.True);
            actual = target.Contains(orphaned_m_n);
            Assert.That(actual, Is.False);
            actual = target.Contains(item_o_q);
            Assert.That(actual, Is.True);
            actual = target.Contains(orphaned_o_q);
            Assert.That(actual, Is.False);
            target.Remove(item_m);
            actual = target.Contains(item_m);
            Assert.That(actual, Is.False);

            target.Add(added_n);
            actual = target.Contains(item_c_g);
            Assert.That(actual, Is.True);
            actual = target.Contains(orphaned_b_h);
            Assert.That(actual, Is.False);
            actual = target.Contains(orphaned_d_f);
            Assert.That(actual, Is.False);
            actual = target.Contains(orphaned_l_m);
            Assert.That(actual, Is.False);
            actual = target.Contains(item_m);
            Assert.That(actual, Is.True);
            actual = target.Contains(orphaned_m_n);
            Assert.That(actual, Is.False);
            actual = target.Contains(item_o_q);
            Assert.That(actual, Is.False);
            actual = target.Contains(orphaned_o_q);
            Assert.That(actual, Is.False);
            target.Remove(item_m);
            actual = target.Contains(item_m);
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