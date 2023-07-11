namespace DIContainer
{
    public interface ISingleBinding : IBinding
    {
        public object SingleObject { get; }
    }

    public interface IBinding
    {
        public Type For { get; }
        public Type Use { get; }
    }
}