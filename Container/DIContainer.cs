using System.Reflection;
using System.Reflection.Metadata;

namespace DIContainer
{
    public class DIContainer : IDIContainer
    {
        private List<IBinding> bindings = new List<IBinding>();

        public void Bind<For, Use>()
        {
            IBinding binding = new Binding(typeof(For), typeof(Use));
            bindings.Add(binding);
        }

        public void BindSingle<For, Use>(Use to)
        {
            ISingleBinding binding = new SingleBinding(typeof(For),typeof(Use),to);
            bindings.Add(binding);
        }

        public objectType GetInstance<objectType>()
        {
            return (objectType)GetInstance(typeof(objectType));
        }

        private object GetInstance(Type type)
        {
            return GetFromSingleBinding(type) ?? GetFromConstructor(type);
        }

        private object GetFromSingleBinding(Type type)
        {
            IBinding binding = GetBindingOfType(type);

            return (binding as ISingleBinding)?.SingleObject;
        }

        private object GetFromConstructor(Type type)
        {
            ConstructorInfo constructor = GetMinConstructor(type);

            List<object> parameters = new List<object>();

            foreach (var parameter in constructor.GetParameters())
            {
                parameters.Add(GetBindingFromParameter(parameter));
            }

            return constructor.Invoke(parameters.ToArray());
        }

        private object GetBindingFromParameter(ParameterInfo parameter)
        {
            IBinding binding = GetBindingOfType(parameter.ParameterType);

            if (binding != null)
            {
                return GetInstance(binding.For);
            }

            throw new Exception("Container has not binding of type: " + parameter.ParameterType);
        }

        private ConstructorInfo GetMinConstructor(Type type)
        {
            return type.GetConstructors().MinBy(x => x.GetParameters().Length);
        }

        private IBinding GetBindingOfType(Type type)
        {
            return bindings.Find(x => x.For == type);
        }
    }
}