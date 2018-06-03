namespace Faker.Generators
{
    using System;

    /// <summary>
    /// An object that can generates realistic fake data for types.
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// The types that are supported by this generator.
        /// </summary>
        //Type[] MockedTypes { get; }

        bool CanCreate(string name, Type type);

        /// <summary>
        /// Create a fake instance for a given type and property name.
        /// </summary>
        /// <param name="name">A name that will help to generate more realistic data. It could be a property name for instance.</param>
        /// <param name="type">The type of the requested fake data.</param>
        /// <returns>A fake instance.</returns>
        object Create(string name, Type type);
    }
}
