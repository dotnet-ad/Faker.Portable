namespace Faking.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for booleans.
    /// </summary>
    public class BooleanGenerator : IGenerator
    {
		public Type[] MockedTypes => new Type[] { typeof(bool) };
 
        public object Create(string name, Type type) => Faker.Random.Next(0, 2) == 0 ? false : true;

        public bool CanCreate(string name, Type type) => this.MockedTypes.Contains(type);
    }
}
