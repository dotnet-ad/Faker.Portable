namespace Faking.Generators
{
    using System;
    using System.Text;

    /// <summary>
    /// A generator for text data.
    /// </summary>
	public class StringGenerator : RouterGenerator<string>
    {
		public StringGenerator()
		{
			this.AddRegexRule(@"^(id|key|identifier)\Z", CreateIdentifier);
			this.AddRegexRule(@"^.*country.*\Z", CreateCountry);
			this.AddRegexRule(@"^.*email.*\Z", CreateEmail);
			this.AddRegexRule(@"^.*color.*\Z", CreateHexColor);
			this.AddRegexRule(@"^.*(name|city).*\Z", CreateName);
			this.AddRegexRule(@"^.*title.*\Z", () => this.CreateTitle());
			this.AddRegexesRule(new[] { @"^.*(link|uri|url).*\Z", @"^.*(image|photo|icon|avatar|screenshot|illustration).*\Z" }, CreateImageLink);
			this.AddRegexRule(@"^.*(link|uri|url).*\Z", CreateLink);
			this.AddRule(() => this.CreateSentence());
		}
        
		public static int LastGeneratedIdentifier = 1;

		/// <summary>
		/// Creates a unique identifier.
		/// </summary>
		/// <returns>The identifier.</returns>
		public string CreateIdentifier() => $"_{LastGeneratedIdentifier++}";

        /// <summary>
        /// Creates a random word.
        /// </summary>
        /// <returns></returns>
        public string CreateWord() =>  Constants.AllWords[Faker.Random.Next(0, Constants.AllWords.Length)].ToLower();

		/// <summary>
		/// Creates a random country.
		/// </summary>
		/// <returns></returns>
		public string CreateCountry() => Constants.Countries[Faker.Random.Next(0, Constants.Countries.Length)].ToLower();

        /// <summary>
        /// Creates a random name.
        /// </summary>
        /// <returns></returns>
        public string CreateName()
        {
            var word = this.CreateWord();
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        /// <summary>
        /// Creates a random title sentence.
        /// </summary>
        /// <returns></returns>
        public string CreateTitle(int words = 0)
        {
            if (words <= 0)
                words = Faker.Random.Next(5, 20);
            
            var result = new StringBuilder(this.CreateName());

            for (int i = 1; i < words; i++)
            {
                result.Append(" " + this.CreateWord());
            }

            return result.ToString();
        }

  		/// <summary>
		/// Creates a random sentence.
		/// </summary>
		/// <returns></returns>
		public string CreateSentence(int words = 0) => this.CreateTitle(words) + ".";

        /// <summary>
        /// Creates a random paragraph.
        /// </summary>
        /// <returns></returns>
        public string CreateParagraph(int sentences = 0)
        {
            if (sentences <= 0)
                sentences = Faker.Random.Next(2, 8);


            var result = new StringBuilder(this.CreateSentence());

            for (int i = 1; i < sentences; i++)
            {
                result.Append(" " + this.CreateSentence());
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates a random email address.
        /// </summary>
        /// <returns></returns>
        public string CreateEmail() =>  $"{this.CreateName().ToLower()}.{this.CreateName().ToLower()}@{this.CreateName().ToLower()}.com";

        public string CreateLink() => $"http://www.bing.com/search?q={this.CreateName()}";

        public string CreateHexColor()
        {
            var bytes = new byte[3];
            Faker.Random.NextBytes(bytes);
            return "#" + BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public string CreateImageLink() => "https://unsplash.it/200/200/";

    }
}
