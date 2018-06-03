using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Faking.Test.Tests
{
    [TestFixture]
    public class StringGeneratorTest
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
            var value = faker.Create<string>();
            Assert.IsInstanceOf<string>(value);
        }

        [Test]
        public void NameTest()
        {
            var value = faker.Create<string>("name");
            Assert.IsFalse(value.Contains(" "), "A name must not contains spaces");
        }

        [Test]
        public void IdentifierTest()
        {
            var value = faker.Create<string>("id");
            Assert.IsFalse(value.Contains(" "), "An identifier must not contains spaces");
        }

        [Test]
        public void TitleTest()
        {
            var value = faker.Create<string>("title");
            Assert.IsTrue(value.Contains(" "), "A title must contains spaces");
            Assert.IsFalse(value.EndsWith("."), "A title must not end with \".\"");
        }

        [Test]
        public void ParagraphTest()
        {
            var value = faker.Create<string>("description");
            Assert.IsTrue(value.Contains(" "), "A paragraph must contains spaces");
            Assert.IsTrue(value.EndsWith("."), "A paragraph must end with \".\"");
        }

        [Test]
        public void LinkTest()
        {
            var value = faker.Create<string>("url");
            Assert.IsTrue(value.StartsWith("http://"), "A link must start with \"http://\"");
        }

        [Test]
        public void EmailTest()
        {
            var value = faker.Create<string>("email");
            Assert.IsTrue(value.Split('@').Length == 2, "A paragraph must be X@Y");
        }
    }
}
