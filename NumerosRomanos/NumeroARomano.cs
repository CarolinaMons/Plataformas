using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroARomano
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Ingrese un numero del 1 al 100");
            n = Convert.ToInt32(Console.ReadLine());
            Numero numero = new Numero(n);
            Console.WriteLine(numero.ToRoman());
            Console.ReadKey();
        }
    }

    class Numero
    {

        int num;
        public Numero(int n)
        {
            if (n > 0 && n <= 100)
            {
                num = n;
            }
        }
        public string ToRoman()
        {
            // 1 - I, 5 - V, 10 - X, 50 - L, 100 - C
            string[] romans = { "I", "V", "X", "L", "C" };
            string total = "", rom;
            int ind = 0; //para manejar el vector de romanos
            int aux = num % 10; //obtener el primero numero
            for (int j = 0; j < 2; j++)//el numero maximo es 99, se debe descomponer el numero en el, ## -> # # y se pasa cada uno a romano
            {
                rom = "";
                for (int i = 1; i <= aux; i++) //Para el primer numero puede ser I - V - X, el segundo X - L - C
                {
                    if (i < 4) //Mientras es menor de 4 se agrega a la base el primero I (para el primer numero) o X (para el segundo numero)
                    {
                        rom += romans[ind];
                    }
                    else if (i == 4) //si llega a ser 4 la base debe ser el actual (I o X) mas el siguiente (V o L) -> IX (primero) o VL (segundo)
                    {
                        rom = romans[ind] + romans[ind + 1];
                    } 
                    else if (i == 5) //si llega a ser 5 la base debe ser X (primero) o L (segundo)
                    {
                        rom = romans[ind + 1];
                    }
                    else if (i < 9) //si es mayor de 5 y menor de 9 se le agrega a la base actual el primero  I (para el primer numero) o X (para el segundo numero)
                    {
                        rom += romans[ind];
                    }
                    else if (i == 9) //si llega a ser 9 la base debe ser IX (primero) o XC (segundo)
                    {
                        rom = romans[ind];
                        ind++;
                        rom +=romans[ind + 1];
                    }
                    else //si llega a ser mayor la base es el ultimo X (primero) o C (segundo)
                    {
                        rom = romans[ind + 1];
                    }
                }
                total = rom + total; //Se agrega el numero ya en romanos al total
                aux = num / 10; //Obtener el segundo numero
                ind = 2;//Donde inicia mi indice para el vector de romanos
            }
            return total;
        }
    }
}
