﻿using SharpArch.Core;
using NUnit.Framework;

namespace Tests.SharpArch.Core
{
    [TestFixture]
    public class ValueObjectTests
    {
        public class DummyValueType : ValueObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class AnotherDummyValueType :  ValueObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Test]
        public void ShouldNotBeEqualWhenComparingDifferentTypes() {
            var valType = new DummyValueType { Id = 1, Name = "Luis" };
            var anotherType = new AnotherDummyValueType {
                Id = 1,
                Name = "Luis"
            };
            Assert.IsFalse(anotherType.Equals(valType));
        }

        [Test]
        public void ShouldBeEqualWithSameReference() {
            var valType = new DummyValueType();
            Assert.AreEqual(valType, valType);
        }

        [Test]
        public void ShouldBeEqualSameReferenceWithNonNullValues() {
            var valType = new DummyValueType { Id = 1, Name = "Luis" };
            Assert.AreEqual(valType, valType);
        }

        [Test]
        public void ShouldBeEqualWithDifferentReferences() {
            var valType = new DummyValueType { Id = 1, Name = "Luis" };
            var anotherValType = new DummyValueType { Id = 1, Name = "Luis" };
            Assert.AreEqual(anotherValType, valType);
        }

        [Test]
        public void ShouldnotBeEqualWithDifferentReferencesAndDifferentIds() {
            var valType = new DummyValueType { Id = 1, Name = "Luis" };
            var anotherValType = new DummyValueType {
                Id = 10,
                Name = "Luis"
            };
            Assert.AreNotEqual(anotherValType, valType);
        }

        [Test]
        public void ShouldNotBeEqualToNull() {
            var valType = new DummyValueType { Id = 1, Name = "Luis" };
            Assert.AreNotEqual(null, valType);
            Assert.AreNotEqual(valType, null);
        }

        [Test]
        public void ShouldGenerateSameHashcodeWhenEquals() {
            var valType = new DummyValueType { Id = 10, Name = "Miguel" };
            var anotherValType = new DummyValueType {
                Id = 10,
                Name = "Miguel"
            };
            Assert.AreEqual(valType.GetHashCode(), anotherValType.GetHashCode());
        }

        [Test]
        public void ShouldCompareAndReturnNotEqualWithOperators() {
            var valType = new DummyValueType { Id = 10, Name = "jose" };
            var anotherValType = new DummyValueType {
                Id = 20,
                Name = "Rui"
            };

            Assert.IsFalse(valType == anotherValType);
            Assert.IsTrue(valType != anotherValType);
        }

        [Test]
        public void ShouldNotBeEqualToNullWithOperators() {
            var valType = new DummyValueType { Id = 1, Name = "Luis" };

            Assert.IsFalse(null == valType);
            Assert.IsFalse(valType == null);
            Assert.IsTrue(null != valType);
            Assert.IsTrue(valType != null);
        }
    }
}