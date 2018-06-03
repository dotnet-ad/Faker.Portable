using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Test.Tests
{
    [TestClass]
    public class IntegerGeneratorTest
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
            var value = faker.Create<int>();
            Assert.IsInstanceOfType(value, typeof(int));
        }

        [TestMethod]
        public void AgeTest()
        {
            var value = faker.Create<int>("age");
            Assert.IsTrue(value > 0 && value < 100);
        }
        
        [TestMethod]
        public void DatesTest()
        {
            var value = faker.Create<long>("date");
            Assert.IsTrue(value > 1000000);

            value = faker.Create<int>("month");
            Assert.IsTrue(value > 0 && value < 13);

            value = faker.Create<int>("day");
            Assert.IsTrue(value > 0 && value < 30);

            value = faker.Create<int>("year");
            Assert.IsTrue(value > 1900);
        }
    }
}
