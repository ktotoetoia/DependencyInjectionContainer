﻿namespace DIContainer.Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDIContainer container = new DIContainer();

            container.Bind<TestClass1>();
            container.Bind<TestClass2>().FromInstance(new TestClass2());

            Console.WriteLine(container.GetInstance<TestClass0>());
        }
    }

    public class TestClass0
    {
        public TestClass0(TestClass1 t)
        {

        }
    }

    public class TestClass1
    {
        public TestClass1(TestClass2 t)
        {

        }
    }

    public class TestClass2
    {

    }
}