namespace DIContainer.Bindings
{
    public class Binding : IBinding
    {
        public Type For { get; private set; }
        public Type Use { get; private set; }

        public bool IsUsingInstance { get { return Instance != null; } }
        public object Instance { get; set; }

        public Binding(Type fore, Type use)
        {
            For = fore;
            Use = use;
        }

        public void FromInstance(object instance)
        {
            Instance = instance;
        }
    }
}