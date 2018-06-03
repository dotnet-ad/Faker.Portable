namespace Faking.Generators
{
    using System;

    /// <summary>
    /// Generator for booleans.
    /// </summary>
    public class BooleanGenerator : IGenerator
    {
        public object Create(string name, Type type) => Faker.Random.Next(0, 2) == 0 ? false : true;

        public bool CanCreate(string name, Type type) => type == typeof(bool);
    }
}
