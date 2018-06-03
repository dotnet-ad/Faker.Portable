namespace Faker.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for doubles and floats.
    /// </summary>
    public class DoubleGenerator : IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(double), typeof(float) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        /// <summary>
        /// Creates a random double.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double CreateDouble(double min = Constants.DefaultNumberMin, double max = Constants.DefaultNumberMax)
        {
            return min + Faker.Random.NextDouble() * (max - min);
        }

        public object Create(string name, Type type)
        {
            if (type == typeof(float))
                return (float)this.CreateDouble();

            return this.CreateDouble();
        }
    }
}
