using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Faking.Test.Tests
{
    [TestFixture]
    public class ArrayGeneratorTest
    {
        private Faker faker;

		[SetUp]
        public void Initialize()
        {
            faker = new Faker();
        }

        [Test]
        public void CreationTest()
        {
            var value = faker.Create<int[]>();
            Assert.IsInstanceOf<int[]>(value);
            Assert.AreNotEqual(0, value.Length);

            var value2 = faker.Create<int[,]>();
            Assert.IsInstanceOf<int[,]>(value2);
            Assert.AreNotEqual(0, value2.GetLength(1));
            Assert.AreNotEqual(0, value2.GetLength(1));

            var value3 = faker.Create<int[][]>();
            Assert.IsInstanceOf<int[][]>(value3);
            Assert.AreNotEqual(0, value3.Length);
            Assert.AreNotEqual(0, value3[0].Length);
        }
    }
}
