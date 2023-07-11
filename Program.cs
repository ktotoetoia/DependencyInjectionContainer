namespace DIContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DIContainer container = new DIContainer();
            
            container.Bind<TestClassUltra, TestClassUltra>();

            Console.WriteLine(container.GetInstance<TestClass>().a);
        }
    }

    public class TestClass
    {
        public int a = 3;
        public TestClass(TestClassUltra t)
        {
        }
    }

    public class TestClassUltra
    {
    
    }
}