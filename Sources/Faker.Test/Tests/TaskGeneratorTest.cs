using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faking.Test.Tests
{
    [TestClass]
    public class TaskGeneratorTest
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
            var value = faker.Create<Task>();

            Assert.IsInstanceOfType(value, typeof(Task));

            var value2 = faker.Create<Task<int>>();

            Assert.IsInstanceOfType(value2, typeof(Task<int>));
        }

        [TestMethod]
        public async Task AwaitTest()
        {
            var result = await faker.Create<Task<int>>();

            Assert.IsInstanceOfType(result, typeof(int));

            var task = faker.Create<Task>();

            Assert.IsNotNull (task);

            await task;
        }
    }
}
