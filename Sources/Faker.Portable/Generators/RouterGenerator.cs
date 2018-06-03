using System.Diagnostics;
namespace Faking
{
	using System;
	using Faking.Generators;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using System.Linq;

	public abstract class RouterGenerator : IGenerator
    {
		private List<IGenerator> subgenerators = new List<IGenerator>();

		public void AddRule(IGenerator generator) => this.subgenerators.Add(generator);

		public void AddRule(Func<string, Type, bool> predicat, Func<string, Type, object> createInstance) => this.AddRule(new RelayGenerator(predicat, createInstance));

		public void AddRule<T>(Func<string, bool> predicat, Func<T> createInstance) => this.AddRule((s, t) => t == typeof(T) && predicat(s), (s, t) => createInstance());

		public void AddRule<T>(Func<T> createInstance) => this.AddRule((s, t) => t == typeof(T), (s, t) => createInstance());

		#region Regex

		public void AddRegexRule<T>(string pattern, Func<T> createInstance)
		{
			var regex = new Regex(pattern);
			this.AddRule<T>((s) => regex.Match(s.ToLowerInvariant()).Success, createInstance);
		}

		public void AddRegexesRule<T>(string[] patterns, Func<T> createInstance)
		{
			var regexes = patterns.Select(x => new Regex(x));
			this.AddRule<T>((s) => regexes.All(x =>  x.Match(s.ToLowerInvariant()).Success), createInstance);
		}

		#endregion

		public bool CanCreate(string name, Type type) => this.subgenerators.Any(x => x.CanCreate(name, type));

		public object Create(string name, Type type)
		{
			return this.subgenerators.First(x => x.CanCreate(name, type)).Create(name, type);
		}
	}

	public abstract class RouterGenerator<T> : RouterGenerator
	{
		public void AddRule(Func<string, bool> predicat, Func<T> createInstance) => this.AddRule<T>(predicat,createInstance);

		public void AddRule(Func<T> createInstance) => this.AddRule<T>(createInstance);

		public void AddRegexRule(string pattern, Func<T> createInstance) => this.AddRegexRule<T>(pattern,createInstance);

		public void AddRegexesRule(string[] patterns, Func<T> createInstance) => AddRegexesRule<T>(patterns, createInstance);
	}
}
