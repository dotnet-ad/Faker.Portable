namespace Faker.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for dates.
    /// </summary>
    public class DateTimeGenerator : IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(DateTime) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        public DateTime CreateBirthday()
        {
            return DateTime.Now - TimeSpan.FromDays(365 * Faker.Random.Next(10, 70));
        }

        /// <summary>
        /// Creates a random datetime
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DateTime CreateDateTime()
        {
            return this.CreateDateTime(Constants.DefaultDateTimeMin, Constants.DefaultDateTimeMax);
        }

        /// <summary>
        /// Creates a random datetime
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DateTime CreateDateTime(DateTime min, DateTime max)
        {
            return min.AddSeconds(Faker.Random.NextDouble() * (max - min).TotalSeconds);
        }

        public object Create(string name, Type type)
        {
            if (name.ToLower().Contains("birth"))
                return this.CreateBirthday();

            return this.CreateDateTime();
        }
    }
}
