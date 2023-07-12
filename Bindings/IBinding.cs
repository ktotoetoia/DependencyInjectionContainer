namespace DIContainer.Bindings
{
    public interface IBinding
    {
        public Type For { get; }
        public Type Use { get; }
        public object Instance { get; set; }
        public bool IsUsingInstance { get; }

        void FromInstance(object instance);
    }
}