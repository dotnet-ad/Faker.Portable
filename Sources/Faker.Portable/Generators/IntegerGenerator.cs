namespace Faking.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// A generator for integers.
    /// </summary>
    public class IntegerGenerator : RouterGenerator<int>
    {
		public IntegerGenerator()
		{
			this.AddRegexRule(@"^(id|key|identifier)\Z", CreateIdentifier);
			this.AddRegexRule(@"^.*age.*\Z", CreateAge);
			this.AddRegexRule(@"^.*day.*\Z", CreateDay);
			this.AddRegexRule(@"^.*year.*\Z", CreateYear);
			this.AddRegexRule(@"^.*month.*\Z", CreateMonth);
			this.AddRegexRule(@"^.*(percent|amount).*\Z", CreatePercent);
			this.AddRule<byte>(CreateByte);
			this.AddRule(() => CreateInteger());
		}

		public static int LastGeneratedIdentifier = 1;

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

    }
}
