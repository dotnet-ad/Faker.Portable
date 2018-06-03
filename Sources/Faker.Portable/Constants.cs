using System;
using System.Collections.Generic;
using System.Linq;
namespace Faker
{
    using System.Text;

    /// <summary>
    /// Several default values for generation purpose.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Default min number.
        /// </summary>
        public const int DefaultNumberMin = 1;

        /// <summary>
        /// Default max number
        /// </summary>
        public const int DefaultNumberMax = 1024;

        /// <summary>
        /// Maximum property depth before stopping to mock data.
        /// </summary>
        public const int MaxScope = 10;

        /// <summary>
        /// Mininum default date.
        /// </summary>
        public static DateTime DefaultDateTimeMin = DateTime.Now - TimeSpan.FromDays(365);

        /// <summary>
        /// Maximum default date.
        /// </summary>
        public static DateTime DefaultDateTimeMax = DateTime.Now + TimeSpan.FromDays(365);

		/// <summary>
		/// A list of various countries.
		/// </summary>
		public static string[] Countries = { "France", "Argentina", "Democratic Republic of the Congo", "Côte d'Ivoire", "Democratic People's Republic of Korea", "Mali", "Zimbabwe", "United States of America" };

        /// <summary>
        /// Random words for generating text data.
        /// </summary>
        public static string[] AllWords = { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Etiam", "ut", "sollicitudin", "ante", "sit", "amet", "consectetur", "eros", "Suspendisse", "accumsan", "turpis", "eu", "mauris", "finibus", "condimentum", "Nunc", "ut", "enim", "sit", "amet", "elit", "imperdiet", "fringilla", "Duis", "eu", "odio", "nisi", "Donec", "quam", "urna", "mattis", "sit", "amet", "blandit", "eget", "viverra", "at", "mauris", "In", "volutpat", "metus", "ac", "tellus", "tincidunt", "condimentum", "Vestibulum", "pretium", "maximus", "lacus", "Quisque", "consequat", "dapibus", "laoreet", "Sed", "cursus", "pretium", "tellus", "ac", "volutpat", "Duis", "sit", "amet", "lectus", "tortor", "Fusce", "euismod", "libero", "eget", "ornare", "ornare", "elit", "dolor", "gravida", "lectus", "ut", "viverra", "quam", "ipsum", "et", "tortor", "Pellentesque", "a", "tempus", "felis", "Aenean", "vel", "massa", "orci", "In", "imperdiet", "blandit", "mauris", "non", "lobortis", "ligula", "facilisis", "nec", "Donec", "id", "velit", "sed", "ipsum", "pharetra", "aliquet", "Morbi", "tincidunt", "felis", "lectus", "et", "congue", "sem", "aliquam", "in", "Etiam", "pharetra", "leo", "quis", "sem", "blandit", "finibus", "Sed", "vel", "leo", "venenatis", "sagittis", "quam", "nec", "fermentum", "lorem", "Cras", "auctor", "odio", "non", "mauris", "gravida", "faucibus", "Vestibulum", "tincidunt", "tincidunt", "leo", "sit", "amet", "auctor", "In", "sit", "amet", "feugiat", "risus", "Vestibulum", "pretium", "ipsum", "ut", "eros", "sagittis", "convallis", "Vestibulum", "tincidunt", "erat", "et", "facilisis", "vestibulum", "Ut", "auctor", "sollicitudin", "mi", "non", "tempor", "metus", "tempor", "vitae", "Suspendisse", "potenti", "Aenean", "imperdiet", "efficitur", "libero", "sit", "amet", "lacinia", "Sed", "sit", "amet", "neque", "id", "ligula", "aliquet", "iaculis", "in", "non", "leo", "Aenean", "viverra", "quam", "vel", "odio", "sodales", "eget", "aliquam", "magna", "volutpat", "Aenean", "hendrerit", "blandit", "ipsum", "et", "aliquet", "lorem", "varius", "et", "Duis", "in", "turpis", "efficitur", "pellentesque", "velit", "ac", "commodo", "nunc", "Aenean", "id", "elit", "magna", "Proin", "pharetra", "arcu", "nibh", "sit", "amet", "tristique", "tellus", "tincidunt", "nec", "Aliquam", "viverra", "turpis", "ac", "nibh", "commodo", "tincidunt", "Mauris", "bibendum", "sem", "magna", "eget", "efficitur", "elit", "viverra", "molestie", "Aliquam", "eu", "enim", "eu", "erat", "imperdiet", "suscipit", "Maecenas", "bibendum" };

    }
}
