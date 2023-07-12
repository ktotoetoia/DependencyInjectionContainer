using DIContainer.Bindings;

namespace DIContainer
{
    public interface IDIContainer
    {
        public IBinding Bind<ForUse>();
        public IBinding Bind<For,Use>();
        public Type GetInstance<Type>();
    }
}