
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
    public class TaskGeneratorTest
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
            var value = faker.Create<Task>();

            Assert.IsInstanceOf<Task>(value);

            var value2 = faker.Create<Task<int>>();

            Assert.IsInstanceOf(typeof(Task<int>), value2);
        }

        [Test]
        public async Task AwaitTest()
        {
            var result = await faker.Create<Task<int>>();

            Assert.IsInstanceOf<int>(result);

            var task = faker.Create<Task>();

            Assert.IsNotNull (task);

            await task;
        }
    }
}
