namespace Faking.Generators
{
	using System;
	using System.Linq;

	/// <summary>
	/// A generator for integers.
	/// </summary>
	public class LongGenerator : RouterGenerator<long>
	{
		public LongGenerator()
		{
			this.AddRegexRule(@"^ts\Z", CreateTimestamp);
			this.AddRegexRule(@"^.*(timestamp|date).*\Z", CreateTimestamp);
			this.AddRule(CreateTimestamp);
		}

		private IntegerGenerator integers = new IntegerGenerator();

		public static int LastGeneratedIdentifier = 1;

		/// <summary>
		/// Creates a random timestamp.
		/// </summary>
		/// <returns></returns>
		public long CreateTimestamp() => ((long)Faker.Random.Next(0, 100000)) * 100000 + (long)Faker.Random.Next(0, 1000);
	}
}