using System.Reflection;
using DIContainer.Bindings;

namespace DIContainer
{
    public class DIContainer : IDIContainer
    {
        private List<IBinding> bindings = new List<IBinding>();

        public IBinding Bind<ForUse>()
        {
            return Bind<ForUse, ForUse>();
        }

        public IBinding Bind<For, Use>()
        {
            IBinding binding = new Binding(typeof(For), typeof(Use));
            bindings.Add(binding);
            return binding;
        }

        public objectType GetInstance<objectType>()
        {
            return (objectType)GetInstance(typeof(objectType));
        }

        private object GetInstance(Type type)
        {
            return GetFromInstance(type) ?? GetFromConstructor(type);
        }

        private object GetFromInstance(Type type)
        {
            IBinding binding = GetBindingOfType(type);

            return binding?.Instance;
        }

        private object GetFromConstructor(Type type)
        {
            ConstructorInfo constructor = GetMinConstructor(type);

            List<object> parameters = new List<object>();

            foreach (var parameter in constructor.GetParameters())
            {
                parameters.Add(GetInstance(GetBindingOfType(parameter.ParameterType).Use));
            }

            return constructor.Invoke(parameters.ToArray());
        }

        private ConstructorInfo GetMinConstructor(Type type)
        {
            ConstructorInfo[] constructors = type
                .GetConstructors()
                .Where(para=> para.GetParameters().All(x => GetBindingOfType(x.ParameterType) != null))
                .OrderBy( x=> x.GetParameters().Count())
                .ToArray();

            if (constructors.Length == 0)
            {
                throw new Exception("have not bindings for type: " + type.Name);
            }   
            
            return constructors.First();
        }

        private IBinding GetBindingOfType(Type type)
        {
            return bindings.Find(x => x.For == type);
        }
    }
}