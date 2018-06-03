namespace Faking.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for dates.
    /// </summary>
    public class DateTimeGenerator : IGenerator
    {
        public Type[] MockedTypes => new Type[] { typeof(DateTime) };

        public bool CanCreate(string name, Type type) => this.MockedTypes.Contains(type);

        public DateTime CreateBirthday() =>  DateTime.Now - TimeSpan.FromDays(365 * Faker.Random.Next(10, 70));

        /// <summary>
        /// Creates a random datetime
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DateTime CreateDateTime() => this.CreateDateTime(Constants.DefaultDateTimeMin, Constants.DefaultDateTimeMax);

        /// <summary>
        /// Creates a random datetime
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DateTime CreateDateTime(DateTime min, DateTime max) =>  min.AddSeconds(Faker.Random.NextDouble() * (max - min).TotalSeconds);

        public object Create(string name, Type type)
        {
            if (name.ToLower().Contains("birth"))
                return this.CreateBirthday();

            return this.CreateDateTime();
        }
    }
}
