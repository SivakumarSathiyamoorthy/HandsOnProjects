using System.Configuration;
using static class1;


MyInterface obj = FactoryToCreateObj();
obj.SayHello();

MyInterface FactoryToCreateObj()
{

    MyInterface obj;
    switch (ConfigurationManager.AppSettings.Get("ObjType"))
    {
        case "class1":
            obj = new class1();
            return obj;
        case "class2":
            obj = new class2();
            return obj;
        default:
            return null;

    }

 }

public interface MyInterface
{
    void SayHello();
}

public class class1() : MyInterface
{
    public void SayHello()
    {
        Console.WriteLine("I am from Class 1");
    }
}
    public class class2() : MyInterface
    {
        public void SayHello()
        {
            Console.WriteLine("I am from Class 2");
         }
    }
