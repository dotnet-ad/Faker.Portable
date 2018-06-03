using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Test.Tests
{
    [TestClass]
    public class StringGeneratorTest
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
            var value = faker.Create<string>();
            Assert.IsInstanceOfType(value, typeof(string));
        }

        [TestMethod]
        public void NameTest()
        {
            var value = faker.Create<string>("name");
            Assert.IsFalse(value.Contains(" "), "A name must not contains spaces");
        }

        [TestMethod]
        public void IdentifierTest()
        {
            var value = faker.Create<string>("id");
            Assert.IsFalse(value.Contains(" "), "An identifier must not contains spaces");
        }

        [TestMethod]
        public void TitleTest()
        {
            var value = faker.Create<string>("title");
            Assert.IsTrue(value.Contains(" "), "A title must contains spaces");
            Assert.IsFalse(value.EndsWith("."), "A title must not end with \".\"");
        }

        [TestMethod]
        public void ParagraphTest()
        {
            var value = faker.Create<string>("description");
            Assert.IsTrue(value.Contains(" "), "A paragraph must contains spaces");
            Assert.IsTrue(value.EndsWith("."), "A paragraph must end with \".\"");
        }

        [TestMethod]
        public void LinkTest()
        {
            var value = faker.Create<string>("url");
            Assert.IsTrue(value.StartsWith("http://"), "A link must start with \"http://\"");
        }

        [TestMethod]
        public void EmailTest()
        {
            var value = faker.Create<string>("email");
            Assert.IsTrue(value.Split('@').Length == 2, "A paragraph must be X@Y");
        }
    }
}
