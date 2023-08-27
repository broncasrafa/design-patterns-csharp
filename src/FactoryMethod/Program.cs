using FactoryMethod.Implementations;

namespace FactoryMethod;

public class Program
{
    
    static void Main(string[] args)
    {
        Console.Title = "Factory Method";

        //FactoryMethodClass1.ExecutarTeste();
        //FactoryMethodClass2.ExecutarTeste();
        //FactoryMethodClass3.ExecutarTeste();
        FactoryMethodClass4.ExecutarTeste();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}