namespace DIContainer
{
    public class SingleBinding : ISingleBinding
    {
        public Type For { get; private set; }
        public Type Use { get; private set; }

        public object SingleObject { get; private set; }

        public SingleBinding(Type fore, Type use, object singleObject)
        {
            For = fore;
            Use = use;

            SingleObject = singleObject;
        }
    }
}