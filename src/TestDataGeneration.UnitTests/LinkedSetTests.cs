using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestDataGeneration.UnitTests
{
    public class LinkedSetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void ClearTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void ContainsTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void CountTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void GetEnumeratorTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void GetItemAtTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void IndexOfTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        [Test]
        public void RemoveTest()
        {
            OrderedLinkedSet<TestNode> target = new();
            Assert.Pass();
        }

        class TestLinkedSet : OrderedLinkedSet<TestNode>
        {
            public LinkedList<LinkedSetItemInsertedEventArgs<TestNode>> AfterInsertEvents { get; } = new();
            
            public LinkedList<LinkedSetItemDeletedEventArgs<TestNode>> AfterRemoveEvents { get; } = new();
            
            protected override void OnAfterInsert(LinkedSetItemInsertedEventArgs<TestNode> args)
            {
                base.OnAfterInsert(args);
                AfterInsertEvents.AddLast(args);
            }

            protected override void OnAfterRemove(LinkedSetItemDeletedEventArgs<TestNode> args)
            {
                base.OnAfterRemove(args);
                AfterRemoveEvents.AddLast(args);
            }
        }
        class TestNode : OrderedLinkedSet<TestNode>.Node, IEquatable<TestNode>, IComparable<TestNode>
        {
            public TestNode(int value) => Value = value;

            public int Value { get; }

            public int AfterInsertCount { get; set; }

            public LinkedList<(OrderedLinkedSet<TestNode> Container, TestNode? RefNode, bool RefNodeIsPrevious)> AfterRemoveEvents { get; } = new();

            public override TestNode Clone() => new(Value);

            public int CompareTo(TestNode? other) => (other is null) ? 1 : ReferenceEquals(this, other) ? 0 : Value.CompareTo(other.Value);

            public bool Equals(TestNode? other) => other is not null && (ReferenceEquals(this, other) || Value == other.Value);

            public override bool Equals(object? obj) => obj is TestNode other && (ReferenceEquals(this, other) || Value == other.Value);

            public override int GetHashCode() => Value.GetHashCode();

            public override string ToString() => Value.ToString();

            protected override void OnAfterInsert() => AfterInsertCount++;

            protected override void OnAfterRemove(OrderedLinkedSet<TestNode> container, TestNode? refNode, bool refNodeIsPrevious)
            {
                base.OnAfterRemove(container, refNode, refNodeIsPrevious);
            }
        }
    }
}