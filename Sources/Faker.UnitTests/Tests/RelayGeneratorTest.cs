﻿using NUnit.Framework;
using Mocker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faking.Test.Tests
{
    [TestFixture]
    public class RelayGeneratorTest
    {
        const string testResult = "this is a test";
        const string testResult2 = "this is an other test";
        const string testResult3 = "and again an other test";

        private Faker faker;

        [SetUp]
        public void Initialize()
        {
            faker = new Faker();
        }

        [Test]
        public void CreationTest()
        {
            faker.Register<string>(() => testResult);

            var value = faker.Create<string>();
            Assert.IsInstanceOf<string>(value);
            Assert.AreSame(testResult, value);

        }

        [Test]
        public void ObjectPropertiesTest()
        {
            faker.Register<string>(() => testResult);
            faker.Register<string>("title", () => testResult2);
            faker.Register<string>((n) => n.ToLower().Contains("name"), () => testResult3);

            var value = faker.Create<Article>();

            Assert.AreSame(testResult, value.Description);
            Assert.AreSame(testResult2, value.Title);
            Assert.AreSame(testResult3, value.Author.FirstName);
            Assert.AreSame(testResult3, value.Author.LastName);
        }

        [Test]
        public void ResetTest()
        {
            faker.Register<string>(() => testResult);

            var value = faker.Create<string>();

            Assert.AreSame(testResult, value);

            faker.Reset();

            value = faker.Create<string>();

            Assert.AreNotSame(testResult, value);

        }
    }
}
