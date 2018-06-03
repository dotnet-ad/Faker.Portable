namespace Faking.Generators
{
	using System;
	using System.Linq;

	/// <summary>
	/// A generator for integers.
	/// </summary>
	public class LongGenerator : IGenerator
	{
		public Type[] MockedTypes => new[] { typeof(long) };
	
		private IntegerGenerator integers = new IntegerGenerator();

		public static int LastGeneratedIdentifier = 1;

		public bool CanCreate(string name, Type type) => this.MockedTypes.Contains(type);

		/// <summary>
		/// Creates a random timestamp.
		/// </summary>
		/// <returns></returns>
		public long CreateTimestamp() => ((long)Faker.Random.Next(0, 100000)) * 100000 + (long)Faker.Random.Next(0, 1000);

		public object Create(string name, Type type)
		{
			name = name.ToLower().Trim();

			if (name.Contains("timestamp") ||name.Contains("date") || name == "ts")
				return this.CreateTimestamp();

			return Convert.ChangeType(integers.Create(name, typeof(int)), type);
		}
	}
}