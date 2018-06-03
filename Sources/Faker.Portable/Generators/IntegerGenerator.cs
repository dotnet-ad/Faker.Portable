namespace Faking.Generators
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

		public static int LastGeneratedIdentifier = 1;

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

		/// <summary>
		/// Creates a unique identifier.
		/// </summary>
		/// <returns>The identifier.</returns>
		public int CreateIdentifier() => LastGeneratedIdentifier++;

        /// <summary>
        /// Creates a random age.
        /// </summary>
        /// <returns></returns>
        public int CreateAge() => Faker.Random.Next(5, 90);

        /// <summary>
        /// Creates a random year.
        /// </summary>
        /// <returns></returns>
        public int CreateYear() => Faker.Random.Next(1980, DateTime.Today.Year + 1);

        /// <summary>
        /// Creates a random month.
        /// </summary>
        /// <returns></returns>
        public int CreateMonth() => Faker.Random.Next(1, 13);

        /// <summary>
        /// Creates a random day index.
        /// </summary>
        /// <returns></returns>
        public int CreateDay() => Faker.Random.Next(1,29);

        /// <summary>
        /// Creates a random timestamp.
        /// </summary>
        /// <returns></returns>
        public long CreateTimestamp() => ((long)Faker.Random.Next(0, 100000)) * 100000 + (long)Faker.Random.Next(0, 1000);

        /// <summary>
        /// Creates a random percent.
        /// </summary>
        /// <returns></returns>
        public int CreatePercent() => Faker.Random.Next(0, 101);

        /// <summary>
        /// Creates a random byte.
        /// </summary>
        /// <returns></returns>
        public byte CreateByte() => (byte) Faker.Random.Next(0,256);

        /// <summary>
        /// Creates a random integer.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int CreateInteger(int min = Constants.DefaultNumberMin, int max = Constants.DefaultNumberMax) => Faker.Random.Next(min, max);

        public object Create(string name, Type type)
        {
			object result = 0;

            name = name.ToLower().Trim();

            if(type == typeof(byte))
				result = this.CreateByte();
			else if (name == "id" || name == "identifier")
				result = this.CreateIdentifier();
            else if (name.Contains("timestamp") ||
                name.Contains("date") ||
                name.Contains("ts"))
                result = this.CreateTimestamp();
            else if (name.Contains("age"))
                result = this.CreateAge();

            else if (name.Contains("day"))
                result = this.CreateDay();

            else if (name.Contains("year"))
                result = this.CreateYear();

            else if (name.Contains("month"))
                result = this.CreateMonth();

            else if (name.Contains("percent"))
                result = this.CreatePercent();
			else
				result = this.CreateInteger();

			return Convert.ChangeType(result, type);
        }
    }
}
