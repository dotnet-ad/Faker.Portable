namespace Faking.Generators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Generator for doubles and floats.
    /// </summary>
	public class DoubleGenerator : RouterGenerator
    {
		public DoubleGenerator()
		{
			this.AddRule<float>(() => (float)this.CreateDouble());
			this.AddRule<double>(() => CreateDouble());
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
    }
}
