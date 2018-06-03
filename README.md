![Faker.Portable](Documentation/logo-wide.png)

I wrote this library some time ago for helping me generating some faked data. It's a quick and ugly implementation at the moment, but it do the job pretty well for me.


## Installation

The library is available as a PCL on [NuGet](https://www.nuget.org/packages/Faker.Portable/).

To install **Faker.Portable**, run the following command in the Package Manager Console.

	PM> Install-Package Faker.Portable

## Usage

### Creation

To create a faked instance, simply call the `Create<T>` generic method, where `T` is the object type :

	var value = Faker.Default.Create<string>();

You can also add advice by adding a string : 

	var value = Faker.Default.Create<string>("name");

Faker will generate *POCO* and each of its properties and use property name as the advice for generation :

	public class MyObject
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public MyObject Child { get; set; }
	}

	var value = Faker.Default.Create<MyObject>();

**Note** : when a cycle exists (like `MyObject.Child` previous example), the faked data generation stops with a default depth of `10`. You can change this behavior by changing the `Faker.Default.MaxScope` property. 

### Customisation

You can register custom behaviors simply by calling the `Register<T>` generic methods :
	
	Faker.Default.Register<string>(() => "Faker.Portable");
	var value = Faker.Default.Create<string>();
	// value == "Faker.Portable"

You can add add a condition regarding what the given advice should be :

	Faker.Default.Register<string>("title",() => "Faker.Portable");
	var value = Faker.Default.Create<string>("Title");
	// value == "Faker.Portable"

Or a lambda expression :

	Faker.Default.Register<string>((a) => a.ToLower().Trim().Contains("title"),() => "Faker.Portable");
	var value = Faker.Default.Create<string>("MainTitle");
	// value == "Faker.Portable"

At any time you can remove your custom behaviors by calling `Faker.Default.Reset()` method.

### Supported base types

The library currently supports those base types : `string`, `Uri`, `bool`, `char`, `enum`, `int`, `long`, `byte`, `DateTime`, `IDictionary<,>`, `double`,  `float`, `IEnumerable<>`, `List<>`, `List<>`, `Stack<>`, `ObservableCollection<>`, `Task`, `Task<>`.

## Roadmap / ideas

* Cleaning code and improving architecture.
* Adding missing base types.
* Adding more advices support.

# Copyright and license

Code and documentation copyright 2014-2015 Aloïs Deniel released under the MIT license.