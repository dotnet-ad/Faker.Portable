namespace Faker.Generators
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A generator for asynchronous tasks.
    /// </summary>
    public class TaskGenerator : IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(Task), typeof(Task<>) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        public object Create(string name, Type type)
        {
            if (!type.GetTypeInfo().IsGenericType)
            {
                return Task.Factory.StartNew(() => { });
            }
            
            var task = InstanciateCompletionSource(type);
            return task;
        }

        private object InstanciateCompletionSource(Type type)
        {
            Type[] typeParameters = type.GenericTypeArguments;

            type = typeParameters[0];

            Type constructed = typeof(TaskCompletionSource<>).MakeGenericType(type);

            var tcs = Activator.CreateInstance(constructed);

            constructed.GetTypeInfo().GetDeclaredMethod("SetResult").Invoke(tcs, new object[] { Faker.Default.Create(type) });

            return tcs.GetType().GetTypeInfo().GetDeclaredProperty("Task").GetValue(tcs, null);
        }
    }
}
