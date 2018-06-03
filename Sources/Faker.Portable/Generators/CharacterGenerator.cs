namespace Faking.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for single characters.
    /// </summary>
    public class CharacterGenerator : IGenerator
    {
		public bool CanCreate(string name, Type type) =>  type == typeof(char);

        /// <summary>
        /// Creates a random letter.
        /// </summary>
        /// <returns></returns>
        public char CreateLetter() => (char)('a' + Faker.Random.Next(0, 26));

        public object Create(string name, Type type) =>  this.CreateLetter();
    }
}
