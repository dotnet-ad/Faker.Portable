namespace Faking.Generators
{
	using System;
	using System.Reflection;

    public class EnumGenerator : IGenerator
    {
        public bool CanCreate(string name, Type type) => type.GetTypeInfo().IsEnum;

        public object Create(string name, Type type)
        {
            var enumValues = Enum.GetValues(type);
            return enumValues.GetValue(Faker.Random.Next(enumValues.Length));
        }
    }
}
