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
            Assert.That(target.ContainsAllPossibleValues, Is.False);
            var value_x = 'x';
            var changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
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
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
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
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

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
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
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
            // Assert.Multiple(() =>
            // {
                Assert.That(item_x.IsSingleValue, Is.True);
                Assert.That(item_x.Start, Is.EqualTo(value_x));
                Assert.That(item_x.End, Is.EqualTo(value_x));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Null);
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
            // });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

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
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
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
                Assert.That(item_x.Next, Is.Not.Null);
                Assert.That(item_x.Next, Is.SameAs(item_z));
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
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
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

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
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
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
                Assert.That(item_x.Start, Is.EqualTo(value_w));
                Assert.That(item_x.End, Is.EqualTo(value_x));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Not.Null);
                Assert.That(item_x.Next, Is.SameAs(item_z));
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
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
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

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
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
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
                Assert.That(item_x.Start, Is.EqualTo(value_w));
                Assert.That(item_x.End, Is.EqualTo(value_z));
                Assert.That(item_x.Previous, Is.Not.Null);
                Assert.That(item_x.Previous, Is.SameAs(item_u));
                Assert.That(item_x.Next, Is.Null);
                Assert.That(item_x.Owner, Is.Not.Null);
                Assert.That(item_x.Owner, Is.SameAs(target));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_z.IsSingleValue, Is.True);
                Assert.That(item_z.Start, Is.EqualTo(value_z));
                Assert.That(item_z.End, Is.EqualTo(value_z));
                Assert.That(item_z.Previous, Is.Null);
                Assert.That(item_z.Next, Is.Null);
                Assert.That(item_z.Owner, Is.Null);
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
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
                    Assert.That(target.ContainsAllPossibleValues, Is.False);
                    Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
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
                    Assert.That(item_x.Start, Is.EqualTo(value_w));
                    Assert.That(item_x.End, Is.EqualTo(value_z));
                    Assert.That(item_x.Previous, Is.Not.Null);
                    Assert.That(item_x.Previous, Is.SameAs(item_u));
                    Assert.That(item_x.Next, Is.Null);
                    Assert.That(item_x.Owner, Is.Not.Null);
                    Assert.That(item_x.Owner, Is.SameAs(target));
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
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
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
            });
        }

        [Test]
        public void AddRangeValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            var changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken, Is.Not.Null);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
            });
            var char_l = 'l';
            var char_o = 'o';
            var actual = target.Add(char_l, char_o);
            var item_l_o = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_l_o, Is.Not.Null);
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_o));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_l_o.Previous, Is.Null);
                Assert.That(item_l_o.Next, Is.Null);
                Assert.That(item_l_o.Start, Is.EqualTo(char_l));
                Assert.That(item_l_o.End, Is.EqualTo(char_o));
                Assert.That(item_l_o.IsSingleValue, Is.False);
                Assert.That(item_l_o.Owner, Is.Not.Null);
                Assert.That(item_l_o.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_s = 's';
            actual = target.Add(char_s, char_s);
            var item_s = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_s, Is.Not.Null);
                Assert.That(item_s, Is.Not.SameAs(item_l_o));
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_l_o));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_s.Previous, Is.Not.Null);
                Assert.That(item_s.Previous, Is.SameAs(item_l_o));
                Assert.That(item_s.Next, Is.Null);
                Assert.That(item_s.Start, Is.EqualTo(char_s));
                Assert.That(item_s.End, Is.EqualTo(char_s));
                Assert.That(item_s.IsSingleValue, Is.True);
                Assert.That(item_s.Owner, Is.Not.Null);
                Assert.That(item_s.Owner, Is.SameAs(target));

                Assert.That(item_l_o.Previous, Is.Null);
                Assert.That(item_l_o.Next, Is.Not.Null);
                Assert.That(item_l_o.Next, Is.SameAs(item_s));
                Assert.That(item_l_o.Start, Is.EqualTo(char_l));
                Assert.That(item_l_o.End, Is.EqualTo(char_o));
                Assert.That(item_l_o.IsSingleValue, Is.False);
                Assert.That(item_l_o.Owner, Is.Not.Null);
                Assert.That(item_l_o.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_i = 'i';
            var char_j = 'j';
            actual = target.Add(char_i, char_j);
            var item_i_j = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_i_j, Is.Not.Null);
                Assert.That(item_i_j, Is.Not.SameAs(item_l_o));
                Assert.That(item_i_j, Is.Not.SameAs(item_s));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_s));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_i_j.Previous, Is.Null);
                Assert.That(item_i_j.Next, Is.Not.Null);
                Assert.That(item_i_j.Next, Is.SameAs(item_l_o));
                Assert.That(item_i_j.Start, Is.EqualTo(char_i));
                Assert.That(item_i_j.End, Is.EqualTo(char_j));
                Assert.That(item_i_j.IsSingleValue, Is.False);
                Assert.That(item_i_j.Owner, Is.Not.Null);
                Assert.That(item_i_j.Owner, Is.SameAs(target));

                Assert.That(item_l_o.Previous, Is.Not.Null);
                Assert.That(item_l_o.Previous, Is.SameAs(item_i_j));
                Assert.That(item_l_o.Next, Is.Not.Null);
                Assert.That(item_l_o.Next, Is.SameAs(item_s));
                Assert.That(item_l_o.Start, Is.EqualTo(char_l));
                Assert.That(item_l_o.End, Is.EqualTo(char_o));
                Assert.That(item_l_o.IsSingleValue, Is.False);
                Assert.That(item_l_o.Owner, Is.Not.Null);
                Assert.That(item_l_o.Owner, Is.SameAs(target));
                
                Assert.That(item_s.Previous, Is.Not.Null);
                Assert.That(item_s.Previous, Is.SameAs(item_l_o));
                Assert.That(item_s.Next, Is.Null);
                Assert.That(item_s.Start, Is.EqualTo(char_s));
                Assert.That(item_s.End, Is.EqualTo(char_s));
                Assert.That(item_s.IsSingleValue, Is.True);
                Assert.That(item_s.Owner, Is.Not.Null);
                Assert.That(item_s.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_r = 'r';
            var char_t = 't';
            actual = target.Add(char_r, char_t);
            var item_r_t = item_s;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_i_j));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_r_t));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_i_j.Previous, Is.Null);
                Assert.That(item_i_j.Next, Is.Not.Null);
                Assert.That(item_i_j.Next, Is.SameAs(item_l_o));
                Assert.That(item_i_j.Start, Is.EqualTo(char_i));
                Assert.That(item_i_j.End, Is.EqualTo(char_j));
                Assert.That(item_i_j.IsSingleValue, Is.False);
                Assert.That(item_i_j.Owner, Is.Not.Null);
                Assert.That(item_i_j.Owner, Is.SameAs(target));

                Assert.That(item_l_o.Previous, Is.Not.Null);
                Assert.That(item_l_o.Previous, Is.SameAs(item_i_j));
                Assert.That(item_l_o.Next, Is.Not.Null);
                Assert.That(item_l_o.Next, Is.SameAs(item_r_t));
                Assert.That(item_l_o.Start, Is.EqualTo(char_l));
                Assert.That(item_l_o.End, Is.EqualTo(char_o));
                Assert.That(item_l_o.IsSingleValue, Is.False);
                Assert.That(item_l_o.Owner, Is.Not.Null);
                Assert.That(item_l_o.Owner, Is.SameAs(target));
                
                Assert.That(item_r_t.Previous, Is.Not.Null);
                Assert.That(item_r_t.Previous, Is.SameAs(item_l_o));
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Not.Null);
                Assert.That(item_r_t.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_p = 'p';
            actual = target.Add('m', char_p);
            var item_l_p = item_l_o;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_i_j));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_r_t));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_i_j.Previous, Is.Null);
                Assert.That(item_i_j.Next, Is.Not.Null);
                Assert.That(item_i_j.Next, Is.SameAs(item_l_p));
                Assert.That(item_i_j.Start, Is.EqualTo(char_i));
                Assert.That(item_i_j.End, Is.EqualTo(char_j));
                Assert.That(item_i_j.IsSingleValue, Is.False);
                Assert.That(item_i_j.Owner, Is.Not.Null);
                Assert.That(item_i_j.Owner, Is.SameAs(target));

                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_i_j));
                Assert.That(item_l_p.Next, Is.Not.Null);
                Assert.That(item_l_p.Next, Is.SameAs(item_r_t));
                Assert.That(item_l_p.Start, Is.EqualTo(char_l));
                Assert.That(item_l_p.End, Is.EqualTo(char_p));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
                
                Assert.That(item_r_t.Previous, Is.Not.Null);
                Assert.That(item_r_t.Previous, Is.SameAs(item_l_p));
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Not.Null);
                Assert.That(item_r_t.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            var char_b = 'b';
            var char_c = 'c';
            actual = target.Add(char_c, char_b);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_i_j));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_r_t));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_i_j.Previous, Is.Null);
                Assert.That(item_i_j.Next, Is.Not.Null);
                Assert.That(item_i_j.Next, Is.SameAs(item_l_p));
                Assert.That(item_i_j.Start, Is.EqualTo(char_i));
                Assert.That(item_i_j.End, Is.EqualTo(char_j));
                Assert.That(item_i_j.IsSingleValue, Is.False);
                Assert.That(item_i_j.Owner, Is.Not.Null);
                Assert.That(item_i_j.Owner, Is.SameAs(target));

                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_i_j));
                Assert.That(item_l_p.Next, Is.Not.Null);
                Assert.That(item_l_p.Next, Is.SameAs(item_r_t));
                Assert.That(item_l_p.Start, Is.EqualTo(char_l));
                Assert.That(item_l_p.End, Is.EqualTo(char_p));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
                
                Assert.That(item_r_t.Previous, Is.Not.Null);
                Assert.That(item_r_t.Previous, Is.SameAs(item_l_p));
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Not.Null);
                Assert.That(item_r_t.Owner, Is.SameAs(target));
            });

            actual = target.Add(char_j, 'n');
            var item_i_p = item_i_j;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_i_p));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_r_t));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_i_p.Previous, Is.Null);
                Assert.That(item_i_p.Next, Is.Not.Null);
                Assert.That(item_i_p.Next, Is.SameAs(item_r_t));
                Assert.That(item_i_p.Start, Is.EqualTo(char_i));
                Assert.That(item_i_p.End, Is.EqualTo(char_p));
                Assert.That(item_i_p.IsSingleValue, Is.False);
                Assert.That(item_i_p.Owner, Is.Not.Null);
                Assert.That(item_i_p.Owner, Is.SameAs(target));

                Assert.That(item_l_p.Previous, Is.Null);
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Start, Is.EqualTo(char_l));
                Assert.That(item_l_p.End, Is.EqualTo(char_p));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Owner, Is.Null);
                
                Assert.That(item_r_t.Previous, Is.Not.Null);
                Assert.That(item_r_t.Previous, Is.SameAs(item_i_p));
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Not.Null);
                Assert.That(item_r_t.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_A = 'A';
            var char_X = 'X';
            actual = target.Add(char_A, char_X);
            var item_A_X = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_A_X, Is.Not.Null);
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_r_t));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_A_X.Previous, Is.Null);
                Assert.That(item_A_X.Next, Is.Not.Null);
                Assert.That(item_A_X.Next, Is.SameAs(item_i_p));
                Assert.That(item_A_X.Start, Is.EqualTo(char_A));
                Assert.That(item_A_X.End, Is.EqualTo(char_X));
                Assert.That(item_A_X.IsSingleValue, Is.False);
                Assert.That(item_A_X.Owner, Is.Not.Null);
                Assert.That(item_A_X.Owner, Is.SameAs(target));

                Assert.That(item_i_p.Previous, Is.Not.Null);
                Assert.That(item_i_p.Previous, Is.SameAs(item_A_X));
                Assert.That(item_i_p.Next, Is.Not.Null);
                Assert.That(item_i_p.Next, Is.SameAs(item_r_t));
                Assert.That(item_i_p.Start, Is.EqualTo(char_i));
                Assert.That(item_i_p.End, Is.EqualTo(char_p));
                Assert.That(item_i_p.IsSingleValue, Is.False);
                Assert.That(item_i_p.Owner, Is.Not.Null);
                Assert.That(item_i_p.Owner, Is.SameAs(target));

                Assert.That(item_r_t.Previous, Is.Not.Null);
                Assert.That(item_r_t.Previous, Is.SameAs(item_i_p));
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Not.Null);
                Assert.That(item_r_t.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Add(char_b, char_c);
            var item_b_c = item_A_X.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_b_c, Is.Not.Null);
                Assert.That(item_b_c, Is.Not.SameAs(item_A_X));
                Assert.That(item_b_c, Is.Not.SameAs(item_i_p));
                Assert.That(item_b_c, Is.Not.SameAs(item_r_t));
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_A_X));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_r_t));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_A_X.Previous, Is.Null);
                Assert.That(item_A_X.Start, Is.EqualTo(char_A));
                Assert.That(item_A_X.End, Is.EqualTo(char_X));
                Assert.That(item_A_X.IsSingleValue, Is.False);
                Assert.That(item_A_X.Owner, Is.Not.Null);
                Assert.That(item_A_X.Owner, Is.SameAs(target));

                Assert.That(item_b_c.Previous, Is.Not.Null);
                Assert.That(item_b_c.Previous, Is.SameAs(item_A_X));
                Assert.That(item_b_c.Next, Is.Not.Null);
                Assert.That(item_b_c.Next, Is.SameAs(item_i_p));
                Assert.That(item_b_c.Start, Is.EqualTo(char_b));
                Assert.That(item_b_c.End, Is.EqualTo(char_c));
                Assert.That(item_b_c.IsSingleValue, Is.False);
                Assert.That(item_b_c.Owner, Is.Not.Null);
                Assert.That(item_b_c.Owner, Is.SameAs(target));

                Assert.That(item_i_p.Previous, Is.Not.Null);
                Assert.That(item_i_p.Previous, Is.SameAs(item_b_c));
                Assert.That(item_i_p.Next, Is.Not.Null);
                Assert.That(item_i_p.Next, Is.SameAs(item_r_t));
                Assert.That(item_i_p.Start, Is.EqualTo(char_i));
                Assert.That(item_i_p.End, Is.EqualTo(char_p));
                Assert.That(item_i_p.IsSingleValue, Is.False);
                Assert.That(item_i_p.Owner, Is.Not.Null);
                Assert.That(item_i_p.Owner, Is.SameAs(target));

                Assert.That(item_r_t.Previous, Is.Not.Null);
                Assert.That(item_r_t.Previous, Is.SameAs(item_i_p));
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Not.Null);
                Assert.That(item_r_t.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_Z = 'z';
            var char_z = 'z';
            actual = target.Add(char_Z, char_z);
            var item_Z_z = item_b_c;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_A_X));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_Z_z));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_A_X.Previous, Is.Null);
                Assert.That(item_A_X.Next, Is.Not.Null);
                Assert.That(item_A_X.Next, Is.SameAs(item_Z_z));
                Assert.That(item_A_X.Start, Is.EqualTo(char_A));
                Assert.That(item_A_X.End, Is.EqualTo(char_X));
                Assert.That(item_A_X.IsSingleValue, Is.False);
                Assert.That(item_A_X.Owner, Is.Not.Null);
                Assert.That(item_A_X.Owner, Is.SameAs(target));

                Assert.That(item_Z_z.Previous, Is.Not.Null);
                Assert.That(item_Z_z.Previous, Is.SameAs(item_A_X));
                Assert.That(item_Z_z.Next, Is.Null);
                Assert.That(item_Z_z.Start, Is.EqualTo(char_Z));
                Assert.That(item_Z_z.End, Is.EqualTo(char_z));
                Assert.That(item_Z_z.IsSingleValue, Is.False);
                Assert.That(item_Z_z.Owner, Is.Not.Null);
                Assert.That(item_Z_z.Owner, Is.SameAs(target));

                Assert.That(item_i_p.Previous, Is.Null);
                Assert.That(item_i_p.Next, Is.Null);
                Assert.That(item_i_p.Start, Is.EqualTo(char_i));
                Assert.That(item_i_p.End, Is.EqualTo(char_p));
                Assert.That(item_i_p.IsSingleValue, Is.False);
                Assert.That(item_i_p.Owner, Is.Null);

                Assert.That(item_r_t.Previous, Is.Null);
                Assert.That(item_r_t.Next, Is.Null);
                Assert.That(item_r_t.Start, Is.EqualTo(char_r));
                Assert.That(item_r_t.End, Is.EqualTo(char_t));
                Assert.That(item_r_t.IsSingleValue, Is.False);
                Assert.That(item_r_t.Owner, Is.Null);
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var char_7 = '7';
            actual = target.Add(char_7, char_7);
            var item_7 = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(item_7, Is.Not.Null);
                Assert.That(item_7, Is.Not.SameAs(item_A_X));
                Assert.That(item_7, Is.Not.SameAs(item_Z_z));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_Z_z));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_7.Previous, Is.Null);
                Assert.That(item_7.Start, Is.EqualTo(char_7));
                Assert.That(item_7.End, Is.EqualTo(char_7));
                Assert.That(item_7.IsSingleValue, Is.True);
                Assert.That(item_7.Owner, Is.Not.Null);
                Assert.That(item_7.Owner, Is.SameAs(target));

                Assert.That(item_A_X.Previous, Is.Not.Null);
                Assert.That(item_A_X.Previous, Is.SameAs(item_7));
                Assert.That(item_A_X.Start, Is.EqualTo(char_A));
                Assert.That(item_A_X.End, Is.EqualTo(char_X));
                Assert.That(item_A_X.IsSingleValue, Is.False);
                Assert.That(item_A_X.Owner, Is.Not.Null);
                Assert.That(item_A_X.Owner, Is.SameAs(target));

                Assert.That(item_Z_z.Previous, Is.Not.Null);
                Assert.That(item_Z_z.Previous, Is.SameAs(item_A_X));
                Assert.That(item_Z_z.Next, Is.Null);
                Assert.That(item_Z_z.Start, Is.EqualTo(char_Z));
                Assert.That(item_Z_z.End, Is.EqualTo(char_z));
                Assert.That(item_Z_z.IsSingleValue, Is.False);
                Assert.That(item_Z_z.Owner, Is.Not.Null);
                Assert.That(item_Z_z.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Add(char_Z, 'y');
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_7));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_Z_z));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_7.Previous, Is.Null);
                Assert.That(item_7.Start, Is.EqualTo(char_7));
                Assert.That(item_7.End, Is.EqualTo(char_7));
                Assert.That(item_7.IsSingleValue, Is.True);
                Assert.That(item_7.Owner, Is.Not.Null);
                Assert.That(item_7.Owner, Is.SameAs(target));

                Assert.That(item_A_X.Previous, Is.Not.Null);
                Assert.That(item_A_X.Previous, Is.SameAs(item_7));
                Assert.That(item_A_X.Start, Is.EqualTo(char_A));
                Assert.That(item_A_X.End, Is.EqualTo(char_X));
                Assert.That(item_A_X.IsSingleValue, Is.False);
                Assert.That(item_A_X.Owner, Is.Not.Null);
                Assert.That(item_A_X.Owner, Is.SameAs(target));

                Assert.That(item_Z_z.Previous, Is.Not.Null);
                Assert.That(item_Z_z.Previous, Is.SameAs(item_A_X));
                Assert.That(item_Z_z.Next, Is.Null);
                Assert.That(item_Z_z.Start, Is.EqualTo(char_Z));
                Assert.That(item_Z_z.End, Is.EqualTo(char_z));
                Assert.That(item_Z_z.IsSingleValue, Is.False);
                Assert.That(item_Z_z.Owner, Is.Not.Null);
                Assert.That(item_Z_z.Owner, Is.SameAs(target));
            });
            
            actual = target.Add(char_7, char_7);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_7));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_Z_z));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_7.Previous, Is.Null);
                Assert.That(item_7.Start, Is.EqualTo(char_7));
                Assert.That(item_7.End, Is.EqualTo(char_7));
                Assert.That(item_7.IsSingleValue, Is.True);
                Assert.That(item_7.Owner, Is.Not.Null);
                Assert.That(item_7.Owner, Is.SameAs(target));

                Assert.That(item_A_X.Previous, Is.Not.Null);
                Assert.That(item_A_X.Previous, Is.SameAs(item_7));
                Assert.That(item_A_X.Start, Is.EqualTo(char_A));
                Assert.That(item_A_X.End, Is.EqualTo(char_X));
                Assert.That(item_A_X.IsSingleValue, Is.False);
                Assert.That(item_A_X.Owner, Is.Not.Null);
                Assert.That(item_A_X.Owner, Is.SameAs(target));

                Assert.That(item_Z_z.Previous, Is.Not.Null);
                Assert.That(item_Z_z.Previous, Is.SameAs(item_A_X));
                Assert.That(item_Z_z.Next, Is.Null);
                Assert.That(item_Z_z.Start, Is.EqualTo(char_Z));
                Assert.That(item_Z_z.End, Is.EqualTo(char_z));
                Assert.That(item_Z_z.IsSingleValue, Is.False);
                Assert.That(item_Z_z.Owner, Is.Not.Null);
                Assert.That(item_Z_z.Owner, Is.SameAs(target));
            });
        }

        [Test]
        public void AddRangeItemTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            var item_l_p_start = 'l';
            var item_l_p_end = 'p';
            var item_l_p = new SequentialRangeSet<char>.RangeItem(item_l_p_start, item_l_p_end, SequentialRangeSet.CharRangeAccessors.Instance);
            var changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            target.Add(item_l_p);
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_l_p));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_l_p.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_l_p.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Previous, Is.Null);
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var item_L_P_start = 'L';
            var item_L_P_end = 'P';
            var item_L_P = new SequentialRangeSet<char>.RangeItem(item_L_P_start, item_L_P_end, SequentialRangeSet.CharRangeAccessors.Instance);
            target.Add(item_l_p);
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_L_P));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_L_P.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_L_P.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_L_P.IsSingleValue, Is.False);
                Assert.That(item_L_P.Previous, Is.Null);
                Assert.That(item_L_P.Next, Is.Not.Null);
                Assert.That(item_L_P.Next, Is.SameAs(item_l_p));
                Assert.That(item_L_P.Owner, Is.Not.Null);
                Assert.That(item_L_P.Owner, Is.SameAs(target));
                
                Assert.That(item_l_p.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_l_p.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_L_P));
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var cannot_add = new SequentialRangeSet<char>.RangeItem(item_L_P_start, item_L_P_end, SequentialRangeSet.CharRangeAccessors.Instance);
            Assert.Throws<InvalidOperationException>(() => target.Add(cannot_add));
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_L_P));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_L_P.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_L_P.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_L_P.IsSingleValue, Is.False);
                Assert.That(item_L_P.Previous, Is.Null);
                Assert.That(item_L_P.Next, Is.Not.Null);
                Assert.That(item_L_P.Next, Is.SameAs(item_l_p));
                Assert.That(item_L_P.Owner, Is.Not.Null);
                Assert.That(item_L_P.Owner, Is.SameAs(target));
                
                Assert.That(item_l_p.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_l_p.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_L_P));
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
                
                Assert.That(cannot_add.Start, Is.EqualTo(item_l_p_start));
                Assert.That(cannot_add.End, Is.EqualTo(item_l_p_end));
                Assert.That(cannot_add.IsSingleValue, Is.False);
                Assert.That(cannot_add.Previous, Is.Null);
                Assert.That(cannot_add.Next, Is.Null);
                Assert.That(cannot_add.Owner, Is.Null);
            });
            
            cannot_add = new SequentialRangeSet<char>.RangeItem(item_L_P_end, item_l_p_start, SequentialRangeSet.CharRangeAccessors.Instance);
            Assert.Throws<InvalidOperationException>(() => target.Add(cannot_add));
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_L_P));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_L_P.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_L_P.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_L_P.IsSingleValue, Is.False);
                Assert.That(item_L_P.Previous, Is.Null);
                Assert.That(item_L_P.Next, Is.Not.Null);
                Assert.That(item_L_P.Next, Is.SameAs(item_l_p));
                Assert.That(item_L_P.Owner, Is.Not.Null);
                Assert.That(item_L_P.Owner, Is.SameAs(target));
                
                Assert.That(item_l_p.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_l_p.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_L_P));
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
                
                Assert.That(cannot_add.Start, Is.EqualTo(item_l_p_start));
                Assert.That(cannot_add.End, Is.EqualTo(item_l_p_end));
                Assert.That(cannot_add.IsSingleValue, Is.False);
                Assert.That(cannot_add.Previous, Is.Null);
                Assert.That(cannot_add.Next, Is.Null);
                Assert.That(cannot_add.Owner, Is.Null);
            });
            
            var c = 'q';
            cannot_add = new SequentialRangeSet<char>.RangeItem(item_l_p_start, c, SequentialRangeSet.CharRangeAccessors.Instance);
            Assert.Throws<InvalidOperationException>(() => target.Add(cannot_add));
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_L_P));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_L_P.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_L_P.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_L_P.IsSingleValue, Is.False);
                Assert.That(item_L_P.Previous, Is.Null);
                Assert.That(item_L_P.Next, Is.Not.Null);
                Assert.That(item_L_P.Next, Is.SameAs(item_l_p));
                Assert.That(item_L_P.Owner, Is.Not.Null);
                Assert.That(item_L_P.Owner, Is.SameAs(target));
                
                Assert.That(item_l_p.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_l_p.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_L_P));
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
                
                Assert.That(cannot_add.Start, Is.EqualTo(item_l_p_start));
                Assert.That(cannot_add.End, Is.EqualTo(c));
                Assert.That(cannot_add.IsSingleValue, Is.False);
                Assert.That(cannot_add.Previous, Is.Null);
                Assert.That(cannot_add.Next, Is.Null);
                Assert.That(cannot_add.Owner, Is.Null);
            });

            c = 'K';
            cannot_add = new SequentialRangeSet<char>.RangeItem(c, c, SequentialRangeSet.CharRangeAccessors.Instance);
            Assert.Throws<InvalidOperationException>(() => target.Add(cannot_add));
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_L_P));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_L_P.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_L_P.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_L_P.IsSingleValue, Is.False);
                Assert.That(item_L_P.Previous, Is.Null);
                Assert.That(item_L_P.Next, Is.Not.Null);
                Assert.That(item_L_P.Next, Is.SameAs(item_l_p));
                Assert.That(item_L_P.Owner, Is.Not.Null);
                Assert.That(item_L_P.Owner, Is.SameAs(target));
                
                Assert.That(item_l_p.Start, Is.EqualTo(item_l_p_start));
                Assert.That(item_l_p.End, Is.EqualTo(item_l_p_end));
                Assert.That(item_l_p.IsSingleValue, Is.False);
                Assert.That(item_l_p.Previous, Is.Not.Null);
                Assert.That(item_l_p.Previous, Is.SameAs(item_L_P));
                Assert.That(item_l_p.Next, Is.Null);
                Assert.That(item_l_p.Owner, Is.Not.Null);
                Assert.That(item_l_p.Owner, Is.SameAs(target));
                
                Assert.That(cannot_add.Start, Is.EqualTo(c));
                Assert.That(cannot_add.End, Is.EqualTo(c));
                Assert.That(cannot_add.IsSingleValue, Is.True);
                Assert.That(cannot_add.Previous, Is.Null);
                Assert.That(cannot_add.Next, Is.Null);
                Assert.That(cannot_add.Owner, Is.Null);
            });
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
            var changeToken = ((IHasChangeToken)target).ChangeToken;
            var first = target.First!;
            var last = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(changeToken, Is.Not.Null);
                Assert.That(first, Is.Not.Null);
                Assert.That(last, Is.Not.Null);
                Assert.That(first, Is.Not.SameAs(last));
                Assert.That(first.Owner, Is.Not.Null);
                Assert.That(first.Owner, Is.SameAs(target));
                Assert.That(last.Owner, Is.Not.Null);
                Assert.That(last.Owner, Is.SameAs(target));
            });
            var middle = first.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(middle, Is.Not.Null);
                Assert.That(middle, Is.Not.SameAs(first));
                Assert.That(middle, Is.Not.SameAs(last));
                Assert.That(first.Previous, Is.Null);

                Assert.That(middle.Previous, Is.Not.Null);
                Assert.That(middle.Previous, Is.SameAs(first));
                Assert.That(middle.Next, Is.Not.Null);
                Assert.That(middle.Next, Is.SameAs(last));
                Assert.That(middle.Owner, Is.Not.Null);
                Assert.That(middle.Owner, Is.SameAs(target));

                Assert.That(last.Previous, Is.Not.Null);
                Assert.That(last.Previous, Is.SameAs(middle));
                Assert.That(last.Next, Is.Null);
            });
            target.Clear();
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
            });
            Assert.Multiple(() =>
            {
                Assert.That(first.Owner, Is.Null);
                Assert.That(first.Previous, Is.Null);
                Assert.That(first.Next, Is.Null);

                Assert.That(middle.Previous, Is.Null);
                Assert.That(middle.Next, Is.Null);
                Assert.That(middle.Owner, Is.Null);
                
                Assert.That(last.Previous, Is.Null);
                Assert.That(last.Next, Is.Null);
                Assert.That(last.Owner, Is.Null);
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            target.Clear();
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
            });
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
            var target = new SequentialRangeSet.CharRangeSet
            {
                { start_C, end_G },
                value_m,
                { start_p, end_y }
            };
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
            var target = new SequentialRangeSet.CharRangeSet();
            var actual = target.Count();
            Assert.That(actual, Is.EqualTo(0));

            target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'o' }
            };
            actual = target.Count();
            Assert.That(actual, Is.EqualTo(3));
        }

        [Test]
        public void GetAllValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            var actual = target.GetAllValues();
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Any(), Is.False);

            target = new SequentialRangeSet.CharRangeSet
            {
                { 'a', 'f' },
                'm',
                { 'k', 'o' }
            };

            actual = target.GetAllValues();
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.ToArray(), Is.EqualTo(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'm', 'k', 'l', 'm', 'n', 'o'}));
        }

        [Test]
        public void GetEnumeratorTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            var actual = target.GetEnumerator();
            Assert.That(actual, Is.Not.Null);
            using (actual)
                Assert.That(actual.MoveNext(), Is.False);
            
            var first_start = 'a';
            var first_end = 'f';
            var second_value = 'm';
            var third_start = 'k';
            var third_end = 'o';
            target = new SequentialRangeSet.CharRangeSet
            {
                { first_start, first_end },
                second_value,
                { third_start, third_end }
            };
            var firstRange = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(firstRange, Is.Not.Null);
                Assert.That(firstRange.Start, Is.EqualTo(first_start));
                Assert.That(firstRange.End, Is.EqualTo(first_end));
                Assert.That(firstRange.IsSingleValue, Is.False);
                Assert.That(firstRange.Previous, Is.Null);
                Assert.That(firstRange.Owner, Is.Not.Null);
                Assert.That(firstRange.Owner, Is.SameAs(target));
            });
            var secondRange = firstRange.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(secondRange, Is.Not.Null);
                Assert.That(firstRange.Start, Is.EqualTo(second_value));
                Assert.That(firstRange.End, Is.EqualTo(second_value));
                Assert.That(firstRange.IsSingleValue, Is.True);
                Assert.That(secondRange.Previous, Is.Not.Null);
                Assert.That(secondRange.Previous, Is.SameAs(firstRange));
                Assert.That(secondRange.Owner, Is.Not.Null);
                Assert.That(secondRange.Owner, Is.SameAs(target));
            });
            var thirdRange = secondRange.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(firstRange));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(thirdRange));
                Assert.That(thirdRange, Is.Not.Null);
                Assert.That(thirdRange.Start, Is.EqualTo(third_start));
                Assert.That(thirdRange.End, Is.EqualTo(third_end));
                Assert.That(thirdRange.IsSingleValue, Is.False);
                Assert.That(thirdRange.Previous, Is.Not.Null);
                Assert.That(thirdRange.Previous, Is.SameAs(secondRange));
                Assert.That(thirdRange.Next, Is.Null);
                Assert.That(thirdRange.Owner, Is.Not.Null);
                Assert.That(thirdRange.Owner, Is.SameAs(target));
            });

            actual = target.GetEnumerator();
            Assert.That(actual, Is.Not.Null);
            using (actual)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(actual.MoveNext(), Is.True);
                    var item = actual.Current;
                    Assert.That(item, Is.SameAs(firstRange));
                });
                Assert.Multiple(() =>
                {
                    Assert.That(actual.MoveNext(), Is.True);
                    var item = actual.Current;
                    Assert.That(item, Is.SameAs(firstRange));
                });
                Assert.Multiple(() =>
                {
                    Assert.That(actual.MoveNext(), Is.True);
                    var item = actual.Current;
                    Assert.That(item, Is.SameAs(firstRange));
                });
                Assert.That(actual.MoveNext(), Is.False);
            }
        }

        [Test]
        public void RemoveValueTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
            });
            var changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var actual = target.Remove(char.MinValue);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });

            actual = target.Remove(char.MaxValue);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });

            actual = target.Remove('Z');
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });

            target = new SequentialRangeSet.CharRangeSet
            {
                { char.MinValue, char.MaxValue }
            };
            var range_all = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(range_all, Is.Not.Null);
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_all));
                Assert.That(target.ContainsAllPossibleValues, Is.True);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(range_all.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_all.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_all.IsSingleValue, Is.False);
                Assert.That(range_all.IsMaxRange, Is.True);
                Assert.That(range_all.Previous, Is.Null);
                Assert.That(range_all.Next, Is.Null);
                Assert.That(range_all.Owner, Is.Not.Null);
                Assert.That(range_all.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove('y');
            var range_min_x_end = 'x';
            var range_min_x = range_all;
            var range_z_max_min = 'z';
            var range_z_max = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(range_z_max, Is.Not.Null);
                Assert.That(range_z_max, Is.Not.SameAs(range_min_x));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_min_x));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_min_x.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_min_x.End, Is.EqualTo(range_min_x_end));
                Assert.That(range_min_x.IsSingleValue, Is.False);
                Assert.That(range_min_x.IsMaxRange, Is.False);
                Assert.That(range_min_x.Previous, Is.Null);
                Assert.That(range_min_x.Next, Is.Not.Null);
                Assert.That(range_min_x.Next, Is.SameAs(range_z_max));
                Assert.That(range_min_x.Owner, Is.Not.Null);
                Assert.That(range_min_x.Owner, Is.SameAs(target));
                
                Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_z_max.IsSingleValue, Is.False);
                Assert.That(range_z_max.IsMaxRange, Is.False);
                Assert.That(range_z_max.Previous, Is.Not.Null);
                Assert.That(range_z_max.Previous, Is.SameAs(range_min_x));
                Assert.That(range_z_max.Next, Is.Null);
                Assert.That(range_z_max.Owner, Is.Not.Null);
                Assert.That(range_z_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            actual = target.Remove('w');
            var range_min_v_end = 'v';
            var range_min_v = range_min_x;
            var range_x_value = 'x';
            var range_x = range_min_v.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(range_x, Is.Not.Null);
                Assert.That(range_x, Is.Not.SameAs(range_min_v));
                Assert.That(range_x, Is.Not.SameAs(range_z_max));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_min_v));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_z_max));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_min_v.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_min_v.End, Is.EqualTo(range_min_v_end));
                Assert.That(range_min_v.IsSingleValue, Is.False);
                Assert.That(range_min_v.IsMaxRange, Is.False);
                Assert.That(range_min_v.Previous, Is.Null);
                Assert.That(range_min_v.Next, Is.Not.Null);
                Assert.That(range_min_v.Next, Is.SameAs(range_x));
                Assert.That(range_min_v.Owner, Is.Not.Null);
                Assert.That(range_min_v.Owner, Is.SameAs(target));
                
                Assert.That(range_x.Start, Is.EqualTo(range_x_value));
                Assert.That(range_x.End, Is.EqualTo(range_x_value));
                Assert.That(range_x.IsSingleValue, Is.True);
                Assert.That(range_x.IsMaxRange, Is.False);
                Assert.That(range_x.Previous, Is.Not.Null);
                Assert.That(range_x.Previous, Is.SameAs(range_min_v));
                Assert.That(range_x.Next, Is.Not.Null);
                Assert.That(range_x.Next, Is.SameAs(range_z_max));
                Assert.That(range_x.Owner, Is.Not.Null);
                Assert.That(range_x.Owner, Is.SameAs(target));
                
                Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_z_max.IsSingleValue, Is.False);
                Assert.That(range_z_max.IsMaxRange, Is.False);
                Assert.That(range_z_max.Previous, Is.Not.Null);
                Assert.That(range_z_max.Previous, Is.SameAs(range_x));
                Assert.That(range_z_max.Next, Is.Null);
                Assert.That(range_z_max.Owner, Is.Not.Null);
                Assert.That(range_z_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove('r');
            var range_min_q_end = 'q';
            var range_min_q = range_min_v;
            var range_s_v_start = 's';
            var range_s_v_end = 'v';
            var range_s_v = range_min_q.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(range_s_v, Is.Not.Null);
                Assert.That(range_s_v, Is.Not.SameAs(range_min_q));
                Assert.That(range_s_v, Is.Not.SameAs(range_x));
                Assert.That(range_s_v, Is.Not.SameAs(range_z_max));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_min_q));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_z_max));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_min_q.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_min_q.End, Is.EqualTo(range_min_q_end));
                Assert.That(range_min_q.IsSingleValue, Is.False);
                Assert.That(range_min_q.IsMaxRange, Is.False);
                Assert.That(range_min_q.Previous, Is.Null);
                Assert.That(range_min_q.Next, Is.Not.Null);
                Assert.That(range_min_q.Next, Is.SameAs(range_s_v));
                Assert.That(range_min_q.Owner, Is.Not.Null);
                Assert.That(range_min_q.Owner, Is.SameAs(target));
                
                Assert.That(range_s_v.Start, Is.EqualTo(range_s_v_start));
                Assert.That(range_s_v.End, Is.EqualTo(range_s_v_end));
                Assert.That(range_s_v.IsSingleValue, Is.False);
                Assert.That(range_s_v.IsMaxRange, Is.False);
                Assert.That(range_s_v.Previous, Is.Not.Null);
                Assert.That(range_s_v.Previous, Is.SameAs(range_min_q));
                Assert.That(range_s_v.Next, Is.Not.Null);
                Assert.That(range_s_v.Next, Is.SameAs(range_x));
                Assert.That(range_s_v.Owner, Is.Not.Null);
                Assert.That(range_s_v.Owner, Is.SameAs(target));
                
                Assert.That(range_x.Start, Is.EqualTo(range_x_value));
                Assert.That(range_x.End, Is.EqualTo(range_x_value));
                Assert.That(range_x.IsSingleValue, Is.True);
                Assert.That(range_x.IsMaxRange, Is.False);
                Assert.That(range_x.Previous, Is.Not.Null);
                Assert.That(range_x.Previous, Is.SameAs(range_s_v));
                Assert.That(range_x.Next, Is.Not.Null);
                Assert.That(range_x.Next, Is.SameAs(range_z_max));
                Assert.That(range_x.Owner, Is.Not.Null);
                Assert.That(range_x.Owner, Is.SameAs(target));
                
                Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_z_max.IsSingleValue, Is.False);
                Assert.That(range_z_max.IsMaxRange, Is.False);
                Assert.That(range_z_max.Previous, Is.Not.Null);
                Assert.That(range_z_max.Previous, Is.SameAs(range_x));
                Assert.That(range_z_max.Next, Is.Null);
                Assert.That(range_z_max.Owner, Is.Not.Null);
                Assert.That(range_z_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove(range_s_v_end);
            var range_s_u_start = range_s_v_start;
            var range_s_u_end = 'u';
            var range_s_u = range_s_v;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_min_q));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_z_max));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_min_q.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_min_q.End, Is.EqualTo(range_min_q_end));
                Assert.That(range_min_q.IsSingleValue, Is.False);
                Assert.That(range_min_q.IsMaxRange, Is.False);
                Assert.That(range_min_q.Previous, Is.Null);
                Assert.That(range_min_q.Next, Is.Not.Null);
                Assert.That(range_min_q.Next, Is.SameAs(range_s_u));
                Assert.That(range_min_q.Owner, Is.Not.Null);
                Assert.That(range_min_q.Owner, Is.SameAs(target));
                
                Assert.That(range_s_u.Start, Is.EqualTo(range_s_u_start));
                Assert.That(range_s_u.End, Is.EqualTo(range_s_u_end));
                Assert.That(range_s_u.IsSingleValue, Is.False);
                Assert.That(range_s_u.IsMaxRange, Is.False);
                Assert.That(range_s_u.Previous, Is.Not.Null);
                Assert.That(range_s_u.Previous, Is.SameAs(range_min_q));
                Assert.That(range_s_u.Next, Is.Not.Null);
                Assert.That(range_s_u.Next, Is.SameAs(range_x));
                Assert.That(range_s_u.Owner, Is.Not.Null);
                Assert.That(range_s_u.Owner, Is.SameAs(target));
                
                Assert.That(range_x.Start, Is.EqualTo(range_x_value));
                Assert.That(range_x.End, Is.EqualTo(range_x_value));
                Assert.That(range_x.IsSingleValue, Is.True);
                Assert.That(range_x.IsMaxRange, Is.False);
                Assert.That(range_x.Previous, Is.Not.Null);
                Assert.That(range_x.Previous, Is.SameAs(range_s_u));
                Assert.That(range_x.Next, Is.Not.Null);
                Assert.That(range_x.Next, Is.SameAs(range_z_max));
                Assert.That(range_x.Owner, Is.Not.Null);
                Assert.That(range_x.Owner, Is.SameAs(target));
                
                Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_z_max.IsSingleValue, Is.False);
                Assert.That(range_z_max.IsMaxRange, Is.False);
                Assert.That(range_z_max.Previous, Is.Not.Null);
                Assert.That(range_z_max.Previous, Is.SameAs(range_x));
                Assert.That(range_z_max.Next, Is.Null);
                Assert.That(range_z_max.Owner, Is.Not.Null);
                Assert.That(range_z_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            actual = target.Remove('t');
            var range_s_value = 's';
            var range_s = range_s_u;
            var range_u_value = 'u';
            var range_u = range_s.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(range_u, Is.Not.Null);
                Assert.That(range_u, Is.Not.SameAs(range_min_q));
                Assert.That(range_u, Is.Not.SameAs(range_s));
                Assert.That(range_u, Is.Not.SameAs(range_x));
                Assert.That(range_u, Is.Not.SameAs(range_z_max));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_min_q));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_z_max));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_min_q.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_min_q.End, Is.EqualTo(range_min_q_end));
                Assert.That(range_min_q.IsSingleValue, Is.False);
                Assert.That(range_min_q.IsMaxRange, Is.False);
                Assert.That(range_min_q.Previous, Is.Null);
                Assert.That(range_min_q.Next, Is.Not.Null);
                Assert.That(range_min_q.Next, Is.SameAs(range_s));
                Assert.That(range_min_q.Owner, Is.Not.Null);
                Assert.That(range_min_q.Owner, Is.SameAs(target));
                
                Assert.That(range_s.Start, Is.EqualTo(range_s_value));
                Assert.That(range_s.End, Is.EqualTo(range_s_value));
                Assert.That(range_s.IsSingleValue, Is.True);
                Assert.That(range_s.IsMaxRange, Is.False);
                Assert.That(range_s.Previous, Is.Not.Null);
                Assert.That(range_s.Previous, Is.SameAs(range_min_q));
                Assert.That(range_s.Next, Is.Not.Null);
                Assert.That(range_s.Next, Is.SameAs(range_u));
                Assert.That(range_s.Owner, Is.Not.Null);
                Assert.That(range_s.Owner, Is.SameAs(target));
                
                Assert.That(range_u.Start, Is.EqualTo(range_u_value));
                Assert.That(range_u.End, Is.EqualTo(range_u_value));
                Assert.That(range_u.IsSingleValue, Is.True);
                Assert.That(range_u.IsMaxRange, Is.False);
                Assert.That(range_u.Previous, Is.Not.Null);
                Assert.That(range_u.Previous, Is.SameAs(range_s));
                Assert.That(range_u.Next, Is.Not.Null);
                Assert.That(range_u.Next, Is.SameAs(range_x));
                Assert.That(range_u.Owner, Is.Not.Null);
                Assert.That(range_u.Owner, Is.SameAs(target));
                
                Assert.That(range_x.Start, Is.EqualTo(range_x_value));
                Assert.That(range_x.End, Is.EqualTo(range_x_value));
                Assert.That(range_x.IsSingleValue, Is.True);
                Assert.That(range_x.IsMaxRange, Is.False);
                Assert.That(range_x.Previous, Is.Not.Null);
                Assert.That(range_x.Previous, Is.SameAs(range_u));
                Assert.That(range_x.Next, Is.Not.Null);
                Assert.That(range_x.Next, Is.SameAs(range_z_max));
                Assert.That(range_x.Owner, Is.Not.Null);
                Assert.That(range_x.Owner, Is.SameAs(target));
                
                Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_z_max.IsSingleValue, Is.False);
                Assert.That(range_z_max.IsMaxRange, Is.False);
                Assert.That(range_z_max.Previous, Is.Not.Null);
                Assert.That(range_z_max.Previous, Is.SameAs(range_x));
                Assert.That(range_z_max.Next, Is.Null);
                Assert.That(range_z_max.Owner, Is.Not.Null);
                Assert.That(range_z_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            actual = target.Remove(range_u_value);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(range_u, Is.Not.Null);
                Assert.That(range_u, Is.Not.SameAs(range_min_q));
                Assert.That(range_u, Is.Not.SameAs(range_s));
                Assert.That(range_u, Is.Not.SameAs(range_x));
                Assert.That(range_u, Is.Not.SameAs(range_z_max));
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(target.IsEmpty, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_min_q));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_z_max));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_min_q.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_min_q.End, Is.EqualTo(range_min_q_end));
                Assert.That(range_min_q.IsSingleValue, Is.False);
                Assert.That(range_min_q.IsMaxRange, Is.False);
                Assert.That(range_min_q.Previous, Is.Null);
                Assert.That(range_min_q.Next, Is.Not.Null);
                Assert.That(range_min_q.Next, Is.SameAs(range_s));
                Assert.That(range_min_q.Owner, Is.Not.Null);
                Assert.That(range_min_q.Owner, Is.SameAs(target));
                
                Assert.That(range_s.Start, Is.EqualTo(range_s_value));
                Assert.That(range_s.End, Is.EqualTo(range_s_value));
                Assert.That(range_s.IsSingleValue, Is.True);
                Assert.That(range_s.IsMaxRange, Is.False);
                Assert.That(range_s.Previous, Is.Not.Null);
                Assert.That(range_s.Previous, Is.SameAs(range_min_q));
                Assert.That(range_s.Next, Is.Not.Null);
                Assert.That(range_s.Next, Is.SameAs(range_x));
                Assert.That(range_s.Owner, Is.Not.Null);
                Assert.That(range_s.Owner, Is.SameAs(target));
                
                Assert.That(range_u.Start, Is.EqualTo(range_u_value));
                Assert.That(range_u.End, Is.EqualTo(range_u_value));
                Assert.That(range_u.IsSingleValue, Is.True);
                Assert.That(range_u.IsMaxRange, Is.False);
                Assert.That(range_u.Previous, Is.Null);
                Assert.That(range_u.Next, Is.Null);
                Assert.That(range_u.Owner, Is.Null);
                
                Assert.That(range_x.Start, Is.EqualTo(range_x_value));
                Assert.That(range_x.End, Is.EqualTo(range_x_value));
                Assert.That(range_x.IsSingleValue, Is.True);
                Assert.That(range_x.IsMaxRange, Is.False);
                Assert.That(range_x.Previous, Is.Not.Null);
                Assert.That(range_x.Previous, Is.SameAs(range_s));
                Assert.That(range_x.Next, Is.Not.Null);
                Assert.That(range_x.Next, Is.SameAs(range_z_max));
                Assert.That(range_x.Owner, Is.Not.Null);
                Assert.That(range_x.Owner, Is.SameAs(target));
                
                Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_z_max.IsSingleValue, Is.False);
                Assert.That(range_z_max.IsMaxRange, Is.False);
                Assert.That(range_z_max.Previous, Is.Not.Null);
                Assert.That(range_z_max.Previous, Is.SameAs(range_x));
                Assert.That(range_z_max.Next, Is.Null);
                Assert.That(range_z_max.Owner, Is.Not.Null);
                Assert.That(range_z_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            foreach (var c in new char[] {  range_s_v_end, 'w', 'y' })
            {
                actual = target.Remove(c);
                Assert.Multiple(() =>
                {
                    Assert.That(actual, Is.False);
                    Assert.That(range_u, Is.Not.Null);
                    Assert.That(range_u, Is.Not.SameAs(range_min_q));
                    Assert.That(range_u, Is.Not.SameAs(range_s));
                    Assert.That(range_u, Is.Not.SameAs(range_x));
                    Assert.That(range_u, Is.Not.SameAs(range_z_max));
                    Assert.That(target.ContainsAllPossibleValues, Is.False);
                    Assert.That(target.IsEmpty, Is.False);
                    Assert.That(target.First, Is.Not.Null);
                    Assert.That(target.First, Is.SameAs(range_min_q));
                    Assert.That(target.Last, Is.Not.Null);
                    Assert.That(target.Last, Is.SameAs(range_z_max));
                    Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
                });
                Assert.Multiple(() =>
                {
                    Assert.That(range_min_q.Start, Is.EqualTo(char.MinValue));
                    Assert.That(range_min_q.End, Is.EqualTo(range_min_q_end));
                    Assert.That(range_min_q.IsSingleValue, Is.False);
                    Assert.That(range_min_q.IsMaxRange, Is.False);
                    Assert.That(range_min_q.Previous, Is.Null);
                    Assert.That(range_min_q.Next, Is.Not.Null);
                    Assert.That(range_min_q.Next, Is.SameAs(range_s));
                    Assert.That(range_min_q.Owner, Is.Not.Null);
                    Assert.That(range_min_q.Owner, Is.SameAs(target));
                    
                    Assert.That(range_s.Start, Is.EqualTo(range_s_value));
                    Assert.That(range_s.End, Is.EqualTo(range_s_value));
                    Assert.That(range_s.IsSingleValue, Is.True);
                    Assert.That(range_s.IsMaxRange, Is.False);
                    Assert.That(range_s.Previous, Is.Not.Null);
                    Assert.That(range_s.Previous, Is.SameAs(range_min_q));
                    Assert.That(range_s.Next, Is.Not.Null);
                    Assert.That(range_s.Next, Is.SameAs(range_x));
                    Assert.That(range_s.Owner, Is.Not.Null);
                    Assert.That(range_s.Owner, Is.SameAs(target));
                    
                    Assert.That(range_u.Start, Is.EqualTo(range_u_value));
                    Assert.That(range_u.End, Is.EqualTo(range_u_value));
                    Assert.That(range_u.IsSingleValue, Is.True);
                    Assert.That(range_u.IsMaxRange, Is.False);
                    Assert.That(range_u.Previous, Is.Null);
                    Assert.That(range_u.Next, Is.Null);
                    Assert.That(range_u.Owner, Is.Null);
                    
                    Assert.That(range_x.Start, Is.EqualTo(range_x_value));
                    Assert.That(range_x.End, Is.EqualTo(range_x_value));
                    Assert.That(range_x.IsSingleValue, Is.True);
                    Assert.That(range_x.IsMaxRange, Is.False);
                    Assert.That(range_x.Previous, Is.Not.Null);
                    Assert.That(range_x.Previous, Is.SameAs(range_s));
                    Assert.That(range_x.Next, Is.Not.Null);
                    Assert.That(range_x.Next, Is.SameAs(range_z_max));
                    Assert.That(range_x.Owner, Is.Not.Null);
                    Assert.That(range_x.Owner, Is.SameAs(target));
                    
                    Assert.That(range_z_max.Start, Is.EqualTo(range_z_max_min));
                    Assert.That(range_z_max.End, Is.EqualTo(char.MaxValue));
                    Assert.That(range_z_max.IsSingleValue, Is.False);
                    Assert.That(range_z_max.IsMaxRange, Is.False);
                    Assert.That(range_z_max.Previous, Is.Not.Null);
                    Assert.That(range_z_max.Previous, Is.SameAs(range_x));
                    Assert.That(range_z_max.Next, Is.Null);
                    Assert.That(range_z_max.Owner, Is.Not.Null);
                    Assert.That(range_z_max.Owner, Is.SameAs(target));
                });
            
            }
        }

        [Test]
        public void RemoveRangeValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
            });
            var changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            var actual = target.Remove(char.MinValue, char.MaxValue);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });

            actual = target.Remove('y', 'z');
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });

            target = new SequentialRangeSet.CharRangeSet
            {
                { char.MinValue, char.MaxValue }
            };
            var range_all = target.First!;
            Assert.Multiple(() =>
            {
                Assert.That(range_all, Is.Not.Null);
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_all));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_all.Start, Is.EqualTo(char.MinValue));
                Assert.That(range_all.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_all.IsSingleValue, Is.False);
                Assert.That(range_all.IsMaxRange, Is.True);
                Assert.That(range_all.Previous, Is.Null);
                Assert.That(range_all.Next, Is.Null);
                Assert.That(range_all.Owner, Is.Not.Null);
                Assert.That(range_all.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove(char.MinValue, 'A');
            var range_B_max_start = 'B';
            var range_B_max = range_all;
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_B_max));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_B_max));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_B_max.Start, Is.EqualTo(range_B_max_start));
                Assert.That(range_B_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_B_max.IsSingleValue, Is.False);
                Assert.That(range_B_max.IsMaxRange, Is.False);
                Assert.That(range_B_max.Previous, Is.Null);
                Assert.That(range_B_max.Next, Is.Null);
                Assert.That(range_B_max.Owner, Is.Not.Null);
                Assert.That(range_B_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            actual = target.Remove('G', 'g');
            var range_B_F_start = range_B_max_start;
            var range_B_F_end = 'F';
            var range_B_F = range_B_max;
            var range_H_max_start = 'H';
            var range_H_max = range_B_F.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(range_H_max, Is.Not.Null);
                Assert.That(range_H_max, Is.Not.SameAs(range_B_F));
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_B_F));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_B_F.Start, Is.EqualTo(range_B_F_start));
                Assert.That(range_B_F.End, Is.EqualTo(range_B_F_end));
                Assert.That(range_B_F.IsSingleValue, Is.False);
                Assert.That(range_B_F.IsMaxRange, Is.False);
                Assert.That(range_B_F.Previous, Is.Null);
                Assert.That(range_B_F.Next, Is.Not.Null);
                Assert.That(range_B_F.Next, Is.SameAs(range_H_max));
                Assert.That(range_B_F.Owner, Is.Not.Null);
                Assert.That(range_B_F.Owner, Is.SameAs(target));
                
                Assert.That(range_H_max.Start, Is.EqualTo(range_H_max_start));
                Assert.That(range_H_max.End, Is.EqualTo(char.MaxValue));
                Assert.That(range_H_max.IsSingleValue, Is.False);
                Assert.That(range_H_max.IsMaxRange, Is.False);
                Assert.That(range_H_max.Previous, Is.Not.Null);
                Assert.That(range_H_max.Previous, Is.SameAs(range_B_F));
                Assert.That(range_H_max.Next, Is.Null);
                Assert.That(range_H_max.Owner, Is.Not.Null);
                Assert.That(range_H_max.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove('X', char.MaxValue);
            var range_H_W_start = range_H_max_start;
            var range_H_W_end = 'W';
            var range_H_W = range_H_max;
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_B_F));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_H_W));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_B_F.Start, Is.EqualTo(range_B_F_start));
                Assert.That(range_B_F.End, Is.EqualTo(range_B_F_end));
                Assert.That(range_B_F.IsSingleValue, Is.False);
                Assert.That(range_B_F.IsMaxRange, Is.False);
                Assert.That(range_B_F.Previous, Is.Null);
                Assert.That(range_B_F.Next, Is.Not.Null);
                Assert.That(range_B_F.Next, Is.SameAs(range_H_W));
                Assert.That(range_B_F.Owner, Is.Not.Null);
                Assert.That(range_B_F.Owner, Is.SameAs(target));
                
                Assert.That(range_H_W.Start, Is.EqualTo(range_H_W_start));
                Assert.That(range_H_W.End, Is.EqualTo(range_H_W_end));
                Assert.That(range_H_W.IsSingleValue, Is.False);
                Assert.That(range_H_W.IsMaxRange, Is.False);
                Assert.That(range_H_W.Previous, Is.Not.Null);
                Assert.That(range_H_W.Previous, Is.SameAs(range_B_F));
                Assert.That(range_H_W.Next, Is.Null);
                Assert.That(range_H_W.Owner, Is.Not.Null);
                Assert.That(range_H_W.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove(range_B_F_end, range_H_W_start);
            var range_B_E_start = range_B_F_start;
            var range_B_E_end = 'E';
            var range_B_E = range_B_F;
            var range_I_W_start = 'I';
            var range_I_W_end = range_H_W_end;
            var range_I_W = range_H_W;
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_B_E));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_I_W));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_B_E.Start, Is.EqualTo(range_B_E_start));
                Assert.That(range_B_E.End, Is.EqualTo(range_B_E_end));
                Assert.That(range_B_E.IsSingleValue, Is.False);
                Assert.That(range_B_E.IsMaxRange, Is.False);
                Assert.That(range_B_E.Previous, Is.Null);
                Assert.That(range_B_E.Next, Is.Not.Null);
                Assert.That(range_B_E.Next, Is.SameAs(range_I_W));
                Assert.That(range_B_E.Owner, Is.Not.Null);
                Assert.That(range_B_E.Owner, Is.SameAs(target));
                
                Assert.That(range_I_W.Start, Is.EqualTo(range_I_W_start));
                Assert.That(range_I_W.End, Is.EqualTo(range_I_W_end));
                Assert.That(range_I_W.IsSingleValue, Is.False);
                Assert.That(range_I_W.IsMaxRange, Is.False);
                Assert.That(range_I_W.Previous, Is.Not.Null);
                Assert.That(range_I_W.Previous, Is.SameAs(range_B_E));
                Assert.That(range_I_W.Next, Is.Null);
                Assert.That(range_I_W.Owner, Is.Not.Null);
                Assert.That(range_I_W.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove(range_B_F_end, char.MaxValue);
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_B_E));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_B_E));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_B_E.Start, Is.EqualTo(range_B_E_start));
                Assert.That(range_B_E.End, Is.EqualTo(range_B_E_end));
                Assert.That(range_B_E.IsSingleValue, Is.False);
                Assert.That(range_B_E.IsMaxRange, Is.False);
                Assert.That(range_B_E.Previous, Is.Null);
                Assert.That(range_B_E.Next, Is.Null);
                Assert.That(range_B_E.Owner, Is.Not.Null);
                Assert.That(range_B_E.Owner, Is.SameAs(target));
                
                Assert.That(range_I_W.Start, Is.EqualTo(range_I_W_start));
                Assert.That(range_I_W.End, Is.EqualTo(range_I_W_end));
                Assert.That(range_I_W.IsSingleValue, Is.False);
                Assert.That(range_I_W.IsMaxRange, Is.False);
                Assert.That(range_I_W.Previous, Is.Null);
                Assert.That(range_I_W.Next, Is.Null);
                Assert.That(range_I_W.Owner, Is.Null);
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
        }

        [Test]
        public void RemoveItemTest()
        {
            var item_a_g = new SequentialRangeSet<char>.RangeItem('a', 'g', SequentialRangeSet.CharRangeAccessors.Instance);
            var item_i_k = new SequentialRangeSet<char>.RangeItem('i', 'k', SequentialRangeSet.CharRangeAccessors.Instance);
            var item_m_n = new SequentialRangeSet<char>.RangeItem('m', 'n', SequentialRangeSet.CharRangeAccessors.Instance);
            var item_p_z = new SequentialRangeSet<char>.RangeItem('p', 'z', SequentialRangeSet.CharRangeAccessors.Instance);
            var target = new SequentialRangeSet.CharRangeSet();
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(target.IsEmpty, Is.True);
                Assert.That(target.ContainsAllPossibleValues, Is.False);
            });
            var changeToken = ((IHasChangeToken)target).ChangeToken;

            var actual = target.Remove(item_a_g);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });

            target = new SequentialRangeSet.CharRangeSet
            {
                item_a_g,
                item_i_k,
                item_p_z
            };
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_a_g));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_p_z));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_a_g.Previous, Is.Null);
                Assert.That(item_a_g.Next, Is.Not.Null);
                Assert.That(item_a_g.Next, Is.SameAs(item_i_k));
                Assert.That(item_a_g.Owner, Is.Not.Null);
                Assert.That(item_a_g.Owner, Is.SameAs(target));
                
                Assert.That(item_i_k.Previous, Is.Not.Null);
                Assert.That(item_i_k.Previous, Is.SameAs(item_a_g));
                Assert.That(item_i_k.Next, Is.Not.Null);
                Assert.That(item_i_k.Next, Is.SameAs(item_p_z));
                Assert.That(item_i_k.Owner, Is.Not.Null);
                Assert.That(item_i_k.Owner, Is.SameAs(target));
                
                Assert.That(item_p_z.Previous, Is.Not.Null);
                Assert.That(item_p_z.Previous, Is.SameAs(item_i_k));
                Assert.That(item_p_z.Next, Is.Null);
                Assert.That(item_p_z.Owner, Is.Not.Null);
                Assert.That(item_p_z.Owner, Is.SameAs(target));
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);

            actual = target.Remove(item_m_n);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_a_g));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_p_z));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_a_g.Previous, Is.Null);
                Assert.That(item_a_g.Next, Is.Not.Null);
                Assert.That(item_a_g.Next, Is.SameAs(item_i_k));
                Assert.That(item_a_g.Owner, Is.Not.Null);
                Assert.That(item_a_g.Owner, Is.SameAs(target));
                
                Assert.That(item_i_k.Previous, Is.Not.Null);
                Assert.That(item_i_k.Previous, Is.SameAs(item_a_g));
                Assert.That(item_i_k.Next, Is.Not.Null);
                Assert.That(item_i_k.Next, Is.SameAs(item_p_z));
                Assert.That(item_i_k.Owner, Is.Not.Null);
                Assert.That(item_i_k.Owner, Is.SameAs(target));
                
                Assert.That(item_p_z.Previous, Is.Not.Null);
                Assert.That(item_p_z.Previous, Is.SameAs(item_i_k));
                Assert.That(item_p_z.Next, Is.Null);
                Assert.That(item_p_z.Owner, Is.Not.Null);
                Assert.That(item_p_z.Owner, Is.SameAs(target));
            });

            actual = target.Remove(item_p_z);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_a_g));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_i_k));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_a_g.Previous, Is.Null);
                Assert.That(item_a_g.Next, Is.Not.Null);
                Assert.That(item_a_g.Next, Is.SameAs(item_i_k));
                Assert.That(item_a_g.Owner, Is.Not.Null);
                Assert.That(item_a_g.Owner, Is.SameAs(target));
                
                Assert.That(item_i_k.Previous, Is.Not.Null);
                Assert.That(item_i_k.Previous, Is.SameAs(item_a_g));
                Assert.That(item_i_k.Next, Is.Null);
                Assert.That(item_i_k.Owner, Is.Not.Null);
                Assert.That(item_i_k.Owner, Is.SameAs(target));
                
                Assert.That(item_p_z.Previous, Is.Null);
                Assert.That(item_p_z.Next, Is.Null);
                Assert.That(item_p_z.Owner, Is.Null);
            });
            changeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.That(changeToken, Is.Not.Null);
            
            actual = target.Remove(item_p_z);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_a_g));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_i_k));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(changeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(item_a_g.Previous, Is.Null);
                Assert.That(item_a_g.Next, Is.Not.Null);
                Assert.That(item_a_g.Next, Is.SameAs(item_i_k));
                Assert.That(item_a_g.Owner, Is.Not.Null);
                Assert.That(item_a_g.Owner, Is.SameAs(target));
                
                Assert.That(item_i_k.Previous, Is.Not.Null);
                Assert.That(item_i_k.Previous, Is.SameAs(item_a_g));
                Assert.That(item_i_k.Next, Is.Null);
                Assert.That(item_i_k.Owner, Is.Not.Null);
                Assert.That(item_i_k.Owner, Is.SameAs(target));
            });
        }
    }
}