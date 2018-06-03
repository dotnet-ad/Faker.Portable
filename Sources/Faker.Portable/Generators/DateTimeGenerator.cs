namespace Faking.Generators
{
    using System;

    /// <summary>
    /// Generator for dates.
    /// </summary>
	public class DateTimeGenerator : RouterGenerator<DateTime>
    {
		public DateTimeGenerator()
		{
			this.AddRegexRule(@"^.*(birth).*\Z", CreateBirthday);
			this.AddRule(CreateDateTime);
		}

        public DateTime CreateBirthday() =>  DateTime.Now - TimeSpan.FromDays(365 * Faker.Random.Next(10, 70));

        /// <summary>
        /// Creates a random datetime
        /// </summary>
        /// <returns></returns>
        public DateTime CreateDateTime() => this.CreateDateTime(Constants.DefaultDateTimeMin, Constants.DefaultDateTimeMax);

		/// <summary>
		/// Creates a random datetime
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public DateTime CreateDateTime(DateTime min, DateTime max) =>  min.AddSeconds(Faker.Random.NextDouble() * (max - min).TotalSeconds);
    }
}
