namespace Faker.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// A generator for integers.
    /// </summary>
    public class IntegerGenerator : IGenerator
    {

        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(int), typeof(long), typeof(byte) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        /// <summary>
        /// Creates a random age.
        /// </summary>
        /// <returns></returns>
        public int CreateAge()
        {
            return Faker.Random.Next(5, 90);
        }

        /// <summary>
        /// Creates a random year.
        /// </summary>
        /// <returns></returns>
        public int CreateYear()
        {
            return Faker.Random.Next(1980, DateTime.Today.Year + 1);
        }

        /// <summary>
        /// Creates a random month.
        /// </summary>
        /// <returns></returns>
        public int CreateMonth()
        {
            return Faker.Random.Next(1, 13);
        }

        /// <summary>
        /// Creates a random day index.
        /// </summary>
        /// <returns></returns>
        public int CreateDay()
        {
            return Faker.Random.Next(1,29);
        }

        /// <summary>
        /// Creates a random timestamp.
        /// </summary>
        /// <returns></returns>
        public long CreateTimestamp()
        {
            return ((long)Faker.Random.Next(0, 100000)) * 100000 + (long)Faker.Random.Next(0, 1000);
        }

        /// <summary>
        /// Creates a random percent.
        /// </summary>
        /// <returns></returns>
        public int CreatePercent()
        {
            return Faker.Random.Next(0, 101);
        }

        /// <summary>
        /// Creates a random byte.
        /// </summary>
        /// <returns></returns>
        public byte CreateByte()
        {
            return (byte) Faker.Random.Next(0,256);
        }

        /// <summary>
        /// Creates a random integer.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int CreateInteger(int min = Constants.DefaultNumberMin, int max = Constants.DefaultNumberMax)
        {
            return Faker.Random.Next(min, max);
        }

        public object Create(string name, Type type)
        {
            name = name.ToLower().Trim();

            if(type == typeof(byte))
                return this.CreateByte();
            
            if (name.Contains("timestamp") ||
                name.Contains("date") ||
                name.Contains("ts"))
                return this.CreateTimestamp();

            if (name.Contains("age"))
                return this.CreateAge();

            if (name.Contains("day"))
                return this.CreateDay();

            if (name.Contains("year"))
                return this.CreateYear();

            if (name.Contains("month"))
                return this.CreateMonth();

            if (name.Contains("percent"))
                return this.CreatePercent();

            return this.CreateInteger();
        }
    }
}
