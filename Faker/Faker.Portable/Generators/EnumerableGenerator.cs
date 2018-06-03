namespace Faker.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// Generator for enumerables : lists, stacks, observable collections.
    /// </summary>
    public class EnumerableGenerator: IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { 
                typeof(IEnumerable<>), 
                typeof(List<>), 
                typeof(Stack<>), 
                typeof(ObservableCollection<>)
            }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        public object Create(string name, Type type)
        {
            var total = Faker.Random.Next(5, 50);
            
            var generic = type.GetGenericTypeDefinition();
            Type[] elementTypes = type.GenericTypeArguments;
            
            Type constructed;
            if(generic == typeof(ObservableCollection<>))
            {
                constructed = typeof(ObservableCollection<>).MakeGenericType(elementTypes);
            }
            else
            {
                constructed = typeof(List<>).MakeGenericType(elementTypes);
            }
            
            var result = Activator.CreateInstance(constructed);

            MethodInfo methodInfo = constructed.GetTypeInfo().GetDeclaredMethod("Add");
            ParameterInfo[] parameters = methodInfo.GetParameters();

            for (int i = 0; i < total; i++)
            {
                methodInfo.Invoke(result, new object[]{ Faker.Default.Create(elementTypes[0],name) });
            }

            if (generic == typeof(Stack<>))
            {
                constructed = typeof(Stack<>).MakeGenericType(elementTypes);
                return Activator.CreateInstance(constructed, new object[] { result });
            }
            
            return result;
        }
    }
}
