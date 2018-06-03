using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Faker.Generators
{
    public class EnumGenerator : IGenerator
    {
        public bool CanCreate(string name, Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }

        public object Create(string name, Type type)
        {
            var enumValues = System.Enum.GetValues(type);
            return enumValues.GetValue(Faker.Random.Next(enumValues.Length));
        }
    }
}
