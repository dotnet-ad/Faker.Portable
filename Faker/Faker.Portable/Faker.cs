namespace Faker
{
    using Generators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Faker
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Faker()
        {
            this.generators = new List<IGenerator>();

            this.MaxScope = Constants.MaxScope;

            // Types
            this.Register(new BooleanGenerator());
            this.Register(new CharacterGenerator());
            this.Register(new IntegerGenerator());
            this.Register(new DoubleGenerator());
            this.Register(new DateTimeGenerator());
            this.Register(new StringGenerator());
            this.Register(new TaskGenerator());
            this.Register(new EnumerableGenerator());
            this.Register(new DictionaryGenerator());
            this.Register(new UriGenerator());
            this.Register(new EnumGenerator());
        }

        #region Singleton

        private static volatile Faker instance;

        private static object syncRoot = new Faker();

        /// <summary>
        /// Default mocker instance.
        /// </summary>
        public static Faker Default
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new Faker();
                    }
                }

                return instance;
            }
        }

        #endregion

        private static Random random = new Random();

        /// <summary>
        /// Unique random instance.
        /// </summary>
        public static Random Random
        {
            get
            {
                return random;
            }
        }

        public int MaxScope { get; set; }

        #region Sub generators

        public List<IGenerator> generators;
        
        /// <summary>
        /// Registering a generator.
        /// </summary>
        /// <param name="mocker">The generator to register.</param>
        public void Register(IGenerator mocker)
        {
            this.generators.Insert(0,mocker);
        }

        public void Register(Func<string, Type, bool> predicat, Func<string, Type, object> createInstance)
        {
            this.generators.Insert(0, new RelayGenerator(predicat,createInstance));
        }

        public void Register<Type>(Func<object> createInstance)
        {
            this.Register((s,t) => t == typeof(Type), (s,t) => createInstance());
        }

        public void Register<Type>(string name, Func<object> createInstance)
        {
            this.Register((s, t) => t == typeof(Type) && s.Trim().ToLower() == name.Trim().ToLower(), (s, t) => createInstance());
        }

        public void Register<Type>(Func<string,bool> predicat, Func<object> createInstance)
        {
            this.Register((s, t) => t == typeof(Type) && predicat(s), (s, t) => createInstance());
        }

        public void Reset()
        {
            this.generators.RemoveAll((g) => g.GetType() == typeof(RelayGenerator));
        }

        public IGenerator GetGenerator(Type type, string name)
        {
            return this.generators.FirstOrDefault((g) => g.CanCreate(name, type));
        }
        
        #endregion

        #region Main public functions

        /// <summary>
        /// Creates a mocked instance for the given type.
        /// </summary>
        /// <typeparam name="T">Type of the generated instance.</typeparam>
        /// <returns>The created fake instance.</returns>
        public T Create<T>()
        {
            return (T) this.Create(typeof(T));
        }

        /// <summary>
        /// Creates a mocked instance for the given type, and an advice name.
        /// </summary>
        /// <typeparam name="T">Type of the generated instance.</typeparam>
        /// <param name="name">Name that will help generating a realistic instance.</param>
        /// <returns>The created fake instance.</returns>
        public T Create<T>(string name)
        {
            return (T) this.Create(typeof(T), name);
        }

        /// <summary>
        /// Creates a mocked instance for the given type.
        /// </summary>
        /// <param name="type">Type of the generated instance.</param>
        /// <returns>The created fake instance.</returns>
        public object Create(Type type)
        {
            return this.Create(type, String.Empty);
        }

        /// <summary>
        /// Creates a mocked instance for the given type, and an advice name.
        /// </summary>
        /// <param name="type">Type of the generated instance.</param>
        /// <param name="name">Name that will help generating a realistic instance.</param>
        /// <returns>The created fake instance.</returns>
        public object Create(Type type, String name)
        {
            return this.Create(name, type);
        }

        #endregion

        /// <summary>
        /// Try to create a ranfom object from the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object Create(String name, Type type, int scope = 0)
        {
            if (type.IsArray)
            {
                return this.CreateArray(type, name);
            }

            var generator = this.GetGenerator(type, name);

            if(generator != null)
            {
                return generator.Create(name,type);
            }

            if (type.GetTypeInfo().IsGenericType)
            {
                generator = this.GetGenerator(type.GetGenericTypeDefinition(), name);

                if(generator != null)
                    return generator.Create(name, type);
            }

            if (scope > this.MaxScope)
            {
                return type.GetTypeInfo().IsValueType ? Activator.CreateInstance(type) : null;
            }

            var mock = this.Instanciate(type);

            foreach (var prop in type.GetRuntimeProperties())
            {
                if(prop.CanWrite)
                    prop.SetValue(mock, this.Create(prop.Name, prop.PropertyType,scope+1), null);
            }

            return mock;
        }

        /// <summary>
        /// Creating a fake array instance.
        /// </summary>
        /// <param name="type">type of elements</param>
        /// <param name="name"></param>
        /// <returns></returns>
        private Array CreateArray(Type type, string name)
        {
            //TODO improve multi dimentionnal data.

            var dimensions = type.GetArrayRank();
            var elementType = type.GetElementType();
            var totals = new object[dimensions];

            for (int i = 0; i < dimensions; i++)
            {
                totals[i] = Faker.Random.Next(5, 50);
            }

            var array = (Array)Activator.CreateInstance(type, totals);

            var indices = new int[dimensions];
            for (int i = 0; i < (int)totals[0]; i++)
            {
                array.SetValue(Faker.Default.Create(elementType,name),indices);
                indices[0]++;
            }

            return array;
        }

        /// <summary>
        /// Instanciate a default object for a given type.
        /// </summary>
        /// <param name="type">Type of the instanciated object.</param>
        /// <returns>The created object.</returns>
        private object Instanciate(Type type)
        {
            var ctors = type.GetTypeInfo().DeclaredConstructors;
            ParameterInfo[] p = null;

            foreach (var ctor in ctors)
            {
                var op = ctor.GetParameters();
                if(p == null || op.Length < p.Length)
                {
                    p = op;
                }
            }
            
            var args = new object[p.Length];
            for (int i = 0; i < p.Length; i++)
			{
                var param = p[i];
                args[i] = Create(param.Name, param.ParameterType);
			}

            var mock = Activator.CreateInstance(type,args);

            return mock;
        }
    }
}
