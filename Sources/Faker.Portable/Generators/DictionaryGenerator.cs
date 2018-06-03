namespace Faking.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// Generator for dictionaries.
    /// </summary>
    public class DictionaryGenerator : IGenerator
    {
        public Type[] MockedTypes => new Type[] 
		{ 
                typeof(IDictionary<,>), 
                typeof(Dictionary<,>)
        };

        public bool CanCreate(string name, Type type) => this.MockedTypes.Contains(type);

        public object Create(string name, Type type)
        {
           var elementTypes = type.GenericTypeArguments;

            var constructed = typeof(Dictionary<,>).MakeGenericType(elementTypes);
            var result = Activator.CreateInstance(constructed);

            var methodInfo = constructed.GetTypeInfo().GetDeclaredMethod("Add");
            var containsKeyInfo = constructed.GetTypeInfo().GetDeclaredMethod("ContainsKey");

            for (int i = 0; i < Faker.Random.Next(5, 50); i++)
            {
                var key = Faker.Default.Create(elementTypes[0], "key");

                var contains = (bool)containsKeyInfo.Invoke(result, new object[] { key });

                if(!contains)
                {
                    var value = Faker.Default.Create(elementTypes[1], "value");
                    methodInfo.Invoke(result, new object[] { key, value });
                }
                
            }
            
            return result;
        }
    }
}
