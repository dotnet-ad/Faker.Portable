using System;
using NUnit.Framework;

namespace Faking.Test.Tests
{
    [TestFixture]
    public class BooleanGeneratorTest
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
            var value = faker.Create<bool>();

			Assert.IsInstanceOf<bool>(value);
        }
    }
}
