namespace Faking.Generators
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
		public TaskGenerator(int fakeDuration = 500)
		{
			this.fakeDuration = fakeDuration;
			this.createTaskMethod = this.GetType().GetTypeInfo().GetDeclaredMethod(nameof(CreateGenericTask));
		}

		#region Fields

		private int fakeDuration;

		private MethodInfo createTaskMethod;

		#endregion

		public Type[] MockedTypes => new Type[] { typeof(Task), typeof(Task<>) };

        public bool CanCreate(string name, Type type) =>  this.MockedTypes.Contains(type);

        public object Create(string name, Type type)
        {
            if (!type.GetTypeInfo().IsGenericType)
            {
                return this.CreateTask();
            }

			var genericCreateTaskMethod = createTaskMethod.MakeGenericMethod(type.GenericTypeArguments[0]);
            return genericCreateTaskMethod.Invoke(this, null);
        }

		private Task CreateTask() => Task.Delay(this.fakeDuration);

		private async Task<T> CreateGenericTask<T>()
		{
			var result = Faker.Default.Create<T>();
			await Task.Delay(this.fakeDuration);
			return result;
		}
    }
}
