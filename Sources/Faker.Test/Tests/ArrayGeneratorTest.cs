using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Test.Tests
{
    [TestClass]
    public class ArrayGeneratorTest
    {
        private Faker faker;

        [TestInitialize]
        public void Initialize()
        {
            faker = new Faker();
        }

        [TestMethod]
        public void CreationTest()
        {
            var value = faker.Create<int[]>();
            Assert.IsInstanceOfType(value, typeof(int[]));
            Assert.AreNotEqual(0, value.Length);

            var value2 = faker.Create<int[,]>();
            Assert.IsInstanceOfType(value2, typeof(int[,]));
            Assert.AreNotEqual(0, value2.GetLength(1));
            Assert.AreNotEqual(0, value2.GetLength(1));

            var value3 = faker.Create<int[][]>();
            Assert.IsInstanceOfType(value3, typeof(int[][]));
            Assert.AreNotEqual(0, value3.Length);
            Assert.AreNotEqual(0, value3[0].Length);
        }
    }
}
