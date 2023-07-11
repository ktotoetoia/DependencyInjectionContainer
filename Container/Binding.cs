namespace DIContainer
{
    public class Binding : IBinding
    {
        public Type For { get; private set; }
        public Type Use { get; private set; }

        public Binding(Type fore, Type use)
        {
            For = fore;
            Use = use;
        }
    }
}