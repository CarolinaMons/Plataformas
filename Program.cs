using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntrePalabras
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string start = "", end = "", interm = "";
                Console.Write("Ingrese la palabra inicial: ");
                start = Console.ReadLine();
                Console.Write("Ingrese la palabra final: ");
                end = Console.ReadLine();
                Console.Write("Ingrese la palabra: ");
                interm = Console.ReadLine();
                EntrePalabra ePalabra = new EntrePalabra(start, end);
                bool i = ePalabra.comprobarPalabra(interm);
                if (i) Console.WriteLine("La cadena esta entre inicio y final: " + start + " -- " + interm + " -- " + end);
                else Console.WriteLine("La cadena no esta entre inicio y final: " + start + " -- " + interm + " -- " + end);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }

        public class EntrePalabra
        {
            private string start;
            private string end;

            public EntrePalabra(string start, string end)
            {
                this.start = start ?? throw new ArgumentNullException(nameof(start));
                this.end = end ?? throw new ArgumentNullException(nameof(end));
            }

            public string Start { get => start; set => start = value; }
            public string End { get => end; set => end = value; }

            public bool comprobarPalabra(string palabra)
            {
                char[] cadenaStart = start.ToLower().ToCharArray();
                char[] cadenaEnd = end.ToLower().ToCharArray();
                char[] cadenaInterm = palabra.ToLower().ToCharArray();

                int length = (cadenaStart.Length < cadenaEnd.Length) ? cadenaStart.Length : cadenaEnd.Length;
                for(int i = 0; i < length; i++)
                {
                    if (i == cadenaEnd.Length || i == cadenaStart.Length || i == cadenaInterm.Length) return false;
                    if (cadenaStart[i] == cadenaInterm[i] && cadenaInterm[i] == cadenaInterm[i]) continue;
                    else if (cadenaInterm[i] < cadenaEnd[i] && cadenaInterm[i] > cadenaStart[i]) return true;
                    else if (cadenaInterm[i] < cadenaEnd[i] && cadenaEnd[i] < cadenaStart[i]) return true;
                    else if (cadenaInterm[i] > cadenaStart[i] && cadenaEnd[i] < cadenaStart[i]) return true;
                    else return false;

                }
                return false;

            }
        }
    }
}