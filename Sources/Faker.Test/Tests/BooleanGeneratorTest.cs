using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Faking.Test.Tests
{
    [TestClass]
    public class BooleanGeneratorTest
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
            var value = faker.Create<bool>();

            Assert.IsInstanceOfType(value, typeof(bool));
        }
    }
}
