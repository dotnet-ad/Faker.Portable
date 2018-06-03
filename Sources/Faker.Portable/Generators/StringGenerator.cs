using System.Linq;
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
			this.AddRegexRule(@"^firstname\Z", CreateFirstname);
			this.AddRegexRule(@"^lastname\Z", CreateLastname);
			this.AddRegexRule(@"^fullname\Z", CreateFullname);
			this.AddRegexRule(@"^.*(ean8).*\Z", CreateEan8);
			this.AddRegexRule(@"^.*(ean13|barcode).*\Z", CreateEan13);
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
		public string CreateWord() => Constants.AllWords[Faker.Random.Next(0, Constants.AllWords.Length)].ToLower();

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

		public string CreateFirstname() => Constants.Firstnames[Faker.Random.Next(0, Constants.Firstnames.Length)].ToLower();

		public string CreateLastname() => Constants.Lastnames[Faker.Random.Next(0, Constants.Lastnames.Length)].ToLower();

		public string CreateFullname() => $"{CreateFirstname()} {CreateLastname()}";

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
		public string CreateEmail() => $"{this.CreateName().ToLower()}.{this.CreateName().ToLower()}@{this.CreateName().ToLower()}.com";

		public string CreateLink() => $"http://www.bing.com/search?q={this.CreateName()}";

		public string CreateImageLink() => "https://unsplash.it/200/200/";

		public string CreateHexColor()
		{
			var bytes = new byte[3];
			Faker.Random.NextBytes(bytes);
			return "#" + BitConverter.ToString(bytes).Replace("-", string.Empty);
		}

		#region Barcode

		private string CreateEan(int length)
		{
			var code = Enumerable.Range(0, length - 1).Select(x => Faker.Random.Next(0,10)).ToList();
			              
			int[] weights = null;

			if (length != 8 && length != 13)
					throw new Exception("length can only be 8 or 13");

			if (length == 8)
				weights = new int[] { 3, 1, 3, 1, 3, 1, 3 };

			if (length == 13)
				weights = new int[] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
			
			var weighted_sum = code.Zip(weights, (x, y) => x * y).Sum();
			var check_digit = (10 - weighted_sum % 10) % 10;

			code.Add(check_digit);

			return string.Join("", code);
		}

		public string CreateEan8() => this.CreateEan(8);

		public string CreateEan13() => this.CreateEan(13);

		#endregion

	}
}
