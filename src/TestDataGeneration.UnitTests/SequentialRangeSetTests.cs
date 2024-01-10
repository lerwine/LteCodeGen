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
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;
            Assert.Multiple(() =>
            {
                Assert.That(setChangeToken, Is.Not.Null);
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
            
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

            actual = target.Add(char_Z, 'y');
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.False);
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_7));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_Z_z));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;
            target.Add(item_l_p);
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_l_p));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

            var cannot_add = new SequentialRangeSet<char>.RangeItem(item_L_P_start, item_L_P_end, SequentialRangeSet.CharRangeAccessors.Instance);
            Assert.Throws<InvalidOperationException>(() => target.Add(cannot_add));
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(item_L_P));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(item_l_p));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;
            var first = target.First!;
            var last = target.Last!;
            Assert.Multiple(() =>
            {
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
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
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
            setChangeToken = ((IHasChangeToken)target).ChangeToken;

            target.Clear();
            Assert.Multiple(() =>
            {
                Assert.That(target.First, Is.Null);
                Assert.That(target.Last, Is.Null);
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.SameAs(setChangeToken));
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
                { 'a', 'f' }, // 6
                'm', // 1
                { 'k', 'o' } // 5
            };
            actual = target.Count();
            Assert.That(actual, Is.EqualTo(12));
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

            var range_a_f_start = 'a';
            var range_a_f_end = 'f';
            var range_m_value = 'm';
            var range_k_o_start = 'k';
            var range_k_o_end = 'o';
            target = new SequentialRangeSet.CharRangeSet
            {
                { range_a_f_start, range_a_f_end },
                range_m_value,
                { range_k_o_start, range_k_o_end }
            };
            var range_a_f = target.First!;
            var range_k_o = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(range_a_f, Is.Not.Null);
                Assert.That(range_a_f.Start, Is.EqualTo(range_a_f_start));
                Assert.That(range_a_f.End, Is.EqualTo(range_a_f_end));
                Assert.That(range_a_f.IsSingleValue, Is.False);
                Assert.That(range_a_f.Previous, Is.Null);
                Assert.That(range_a_f.Owner, Is.Not.Null);
                Assert.That(range_a_f.Owner, Is.SameAs(target));

                Assert.That(range_k_o, Is.Not.Null);
                Assert.That(range_k_o.Start, Is.EqualTo(range_k_o_start));
                Assert.That(range_k_o.End, Is.EqualTo(range_k_o_end));
                Assert.That(range_k_o.IsSingleValue, Is.False);
                Assert.That(range_k_o.Next, Is.Null);
                Assert.That(range_k_o.Owner, Is.Not.Null);
                Assert.That(range_k_o.Owner, Is.SameAs(target));
            });
            var range_m = range_a_f.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(range_m, Is.Not.Null);
                Assert.That(range_m.Start, Is.EqualTo(range_m_value));
                Assert.That(range_m.End, Is.EqualTo(range_m_value));
                Assert.That(range_m.IsSingleValue, Is.True);
                Assert.That(range_m.Previous, Is.Not.Null);
                Assert.That(range_m.Previous, Is.SameAs(range_a_f));
                Assert.That(range_m.Owner, Is.Not.Null);
                Assert.That(range_m.Owner, Is.SameAs(target));
                
                Assert.That(range_k_o.Previous, Is.Not.Null);
                Assert.That(range_k_o.Previous, Is.SameAs(range_m));
                
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_a_f));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_k_o));
            });
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;

            var actual = target.Remove('b');
            var range_c_f = range_a_f.Next!;
            var range_a = range_a_f;
            var range_a_value = range_a_f_start;
            var range_c_f_start = 'c';
            var range_c_f_end = range_a_f_end;
            Assert.Multiple(() =>
            {
                Assert.That(range_c_f, Is.Not.Null);
                Assert.That(range_c_f, Is.Not.SameAs(range_a));
                Assert.That(range_c_f, Is.Not.SameAs(range_m));
                Assert.That(range_c_f, Is.Not.SameAs(range_k_o));
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_a));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_k_o));
                Assert.That(((IHasChangeToken)target).ChangeToken, Is.Not.SameAs(setChangeToken));
            });
            Assert.Multiple(() =>
            {
                Assert.That(range_a.Start, Is.EqualTo(range_a_value));
                Assert.That(range_a.End, Is.EqualTo(range_a_value));
                Assert.That(range_a.IsSingleValue, Is.True);
                Assert.That(range_a.Previous, Is.Null);

                Assert.That(range_c_f.Start, Is.EqualTo(range_c_f_start));
                Assert.That(range_c_f.End, Is.EqualTo(range_c_f_end));
                Assert.That(range_c_f.IsSingleValue, Is.False);
                Assert.That(range_c_f.Previous, Is.Not.Null);
                Assert.That(range_c_f.Previous, Is.SameAs(range_a));
                Assert.That(range_c_f.Next, Is.Not.Null);
                Assert.That(range_c_f.Next, Is.SameAs(range_m));

                Assert.That(range_m.Start, Is.EqualTo(range_m_value));
                Assert.That(range_m.IsSingleValue, Is.True);
                Assert.That(range_m.End, Is.EqualTo(range_m_value));
                Assert.That(range_m.Previous, Is.Not.Null);
                Assert.That(range_m.Previous, Is.SameAs(range_c_f));
                Assert.That(range_m.Next, Is.Not.Null);
                Assert.That(range_m.Next, Is.SameAs(range_k_o));

                Assert.That(range_k_o.Start, Is.EqualTo(range_k_o_start));
                Assert.That(range_k_o.End, Is.EqualTo(range_k_o_end));
                Assert.That(range_k_o.IsSingleValue, Is.False);
                Assert.That(range_k_o.Previous, Is.Not.Null);
                Assert.That(range_k_o.Previous, Is.SameAs(range_m));
                Assert.That(range_k_o.Next, Is.Null);
            });
            setChangeToken = ((IHasChangeToken)target).ChangeToken;
        }

        [Test]
        public void RemoveRangeValuesTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();

            var range_a_f_start = 'a';
            var range_a_f_end = 'f';
            var range_m_value = 'm';
            var range_k_o_start = 'k';
            var range_k_o_end = 'o';
            target = new SequentialRangeSet.CharRangeSet
            {
                { range_a_f_start, range_a_f_end },
                range_m_value,
                { range_k_o_start, range_k_o_end }
            };
            var range_a_f = target.First!;
            var range_k_o = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(range_a_f, Is.Not.Null);
                Assert.That(range_a_f.Start, Is.EqualTo(range_a_f_start));
                Assert.That(range_a_f.End, Is.EqualTo(range_a_f_end));
                Assert.That(range_a_f.IsSingleValue, Is.False);
                Assert.That(range_a_f.Previous, Is.Null);
                Assert.That(range_a_f.Owner, Is.Not.Null);
                Assert.That(range_a_f.Owner, Is.SameAs(target));

                Assert.That(range_k_o, Is.Not.Null);
                Assert.That(range_k_o.Start, Is.EqualTo(range_k_o_start));
                Assert.That(range_k_o.End, Is.EqualTo(range_k_o_end));
                Assert.That(range_k_o.IsSingleValue, Is.False);
                Assert.That(range_k_o.Next, Is.Null);
                Assert.That(range_k_o.Owner, Is.Not.Null);
                Assert.That(range_k_o.Owner, Is.SameAs(target));
            });
            var range_m = range_a_f.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(range_m, Is.Not.Null);
                Assert.That(range_m.Start, Is.EqualTo(range_m_value));
                Assert.That(range_m.End, Is.EqualTo(range_m_value));
                Assert.That(range_m.IsSingleValue, Is.True);
                Assert.That(range_m.Previous, Is.Not.Null);
                Assert.That(range_m.Previous, Is.SameAs(range_a_f));
                Assert.That(range_m.Owner, Is.Not.Null);
                Assert.That(range_m.Owner, Is.SameAs(target));
                
                Assert.That(range_k_o.Previous, Is.Not.Null);
                Assert.That(range_k_o.Previous, Is.SameAs(range_m));
                
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_a_f));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_k_o));
            });
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;
        }

        [Test]
        public void RemoveItemTest()
        {
            var target = new SequentialRangeSet.CharRangeSet();

            var range_a_f_start = 'a';
            var range_a_f_end = 'f';
            var range_m_value = 'm';
            var range_k_o_start = 'k';
            var range_k_o_end = 'o';
            target = new SequentialRangeSet.CharRangeSet
            {
                { range_a_f_start, range_a_f_end },
                range_m_value,
                { range_k_o_start, range_k_o_end }
            };
            var range_a_f = target.First!;
            var range_k_o = target.Last!;
            Assert.Multiple(() =>
            {
                Assert.That(range_a_f, Is.Not.Null);
                Assert.That(range_a_f.Start, Is.EqualTo(range_a_f_start));
                Assert.That(range_a_f.End, Is.EqualTo(range_a_f_end));
                Assert.That(range_a_f.IsSingleValue, Is.False);
                Assert.That(range_a_f.Previous, Is.Null);
                Assert.That(range_a_f.Owner, Is.Not.Null);
                Assert.That(range_a_f.Owner, Is.SameAs(target));

                Assert.That(range_k_o, Is.Not.Null);
                Assert.That(range_k_o.Start, Is.EqualTo(range_k_o_start));
                Assert.That(range_k_o.End, Is.EqualTo(range_k_o_end));
                Assert.That(range_k_o.IsSingleValue, Is.False);
                Assert.That(range_k_o.Next, Is.Null);
                Assert.That(range_k_o.Owner, Is.Not.Null);
                Assert.That(range_k_o.Owner, Is.SameAs(target));
            });
            var range_m = range_a_f.Next!;
            Assert.Multiple(() =>
            {
                Assert.That(range_m, Is.Not.Null);
                Assert.That(range_m.Start, Is.EqualTo(range_m_value));
                Assert.That(range_m.End, Is.EqualTo(range_m_value));
                Assert.That(range_m.IsSingleValue, Is.True);
                Assert.That(range_m.Previous, Is.Not.Null);
                Assert.That(range_m.Previous, Is.SameAs(range_a_f));
                Assert.That(range_m.Owner, Is.Not.Null);
                Assert.That(range_m.Owner, Is.SameAs(target));
                
                Assert.That(range_k_o.Previous, Is.Not.Null);
                Assert.That(range_k_o.Previous, Is.SameAs(range_m));
                
                Assert.That(target.First, Is.Not.Null);
                Assert.That(target.First, Is.SameAs(range_a_f));
                Assert.That(target.Last, Is.Not.Null);
                Assert.That(target.Last, Is.SameAs(range_k_o));
            });
            var setChangeToken = ((IHasChangeToken)target).ChangeToken;
        }
    }
}