using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Faking.Test.Tests
{
	[TestFixtureAttribute]
    public class IntegerGeneratorTest
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
            var value = faker.Create<int>();
            Assert.IsInstanceOf<int>(value);
        }

        [Test]
        public void AgeTest()
        {
            var value = faker.Create<int>("age");
            Assert.IsTrue(value > 0 && value < 100);
        }
        
        [Test]
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
