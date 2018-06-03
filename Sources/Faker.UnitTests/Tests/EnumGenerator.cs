using Faker.Test.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faking.Test.Tests
{
    [TestFixture]
    public class EnumGeneratorTest
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
            var value = faker.Create<Gender>();
            Assert.IsInstanceOf<Gender>(value);
        }
    }
}
