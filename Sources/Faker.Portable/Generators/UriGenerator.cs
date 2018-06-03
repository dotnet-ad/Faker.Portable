namespace Faker.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// A generator for uris.
    /// </summary>
    public class UriGenerator : IGenerator
    {
		public UriGenerator(Faker owner)
		{
			this.owner = owner;
		}

		readonly Faker owner;

		public Type[] MockedTypes => new Type[] { typeof(Uri) };

        public bool CanCreate(string name, Type type) => this.MockedTypes.Contains(type);

        public object Create(string name, Type type) => new Uri((string)this.owner.Create(typeof(string),"uri_" + name));
    }
}
