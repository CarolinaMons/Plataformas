using System;


namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n;
                Console.Write("¿Cual numero de la serie Fibonacci desea conocer? --> ");
                n = Convert.ToInt32(Console.ReadLine());

                Fibonacci f = new Fibonacci(n);
                Console.WriteLine(f.imprimir());
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error genral: " + e.Message);
                Console.ReadKey();
            }
            
        }
    }
}