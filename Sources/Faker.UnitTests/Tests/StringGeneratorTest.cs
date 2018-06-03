using System.Linq;
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

		[Test]
		public void EanTest()
		{
			var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

			var value = faker.Create<string>("ean13");
			Assert.IsTrue(value.Length == 13, "A ean 13 code must be 13 character long");
			Assert.IsTrue(value.Any(x => digits.Contains(x)), "A ean 13 code must be only composed of digits");

			value = faker.Create<string>("ean8");
			Assert.IsTrue(value.Length == 8, "A ean 8 code must be 13 character long");
			Assert.IsTrue(value.Any(x => digits.Contains(x)), "A ean 8 code must be only composed of digits");
		}
    }
}
