namespace Faker.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for single characters.
    /// </summary>
    public class CharacterGenerator : IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(char) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        /// <summary>
        /// Creates a random letter.
        /// </summary>
        /// <returns></returns>
        public char CreateLetter()
        {
            return (char)('a' + Faker.Random.Next(0, 26));
        }

        public object Create(string name, Type type)
        {
            return this.CreateLetter();
        }
    }
}
