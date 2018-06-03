namespace Faker.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// A generator for uris.
    /// </summary>
    public class UriGenerator : IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(Uri) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        public object Create(string name, Type type)
        {
            return new Uri((string)Faker.Default.Create(typeof(string),"uri" + name));
        }
    }
}
