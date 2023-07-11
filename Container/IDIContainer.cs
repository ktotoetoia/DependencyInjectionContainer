namespace DIContainer
{
    public interface IDIContainer
    {
        public void BindSingle<Bind, To>(To to);

        public Type GetInstance<Type>();
    }
}