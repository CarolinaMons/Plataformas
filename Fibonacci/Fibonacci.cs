using System;
using System.Collections.Generic;
using System.Text;

namespace Fibonacci
{
    class Fibonacci
    {
        private long numSerie;
        private long numSerieAnt;
        private long n;
        private long iterador;

        public Fibonacci()
        {
        }

        public Fibonacci(int n)
        {
            this.numSerieAnt= 0;
            this.n = n;
            calculaFibonacci();

        }

        public long NumSerie { get => numSerie; set => numSerie = value; }
        public long N { get => n; set => n = value; }

        private void calculaFibonacci()
        {
            long aux;
            numSerie = 0;
            numSerieAnt=1;
            for (long i= 0; i < n; i++)
            {
                aux = numSerie;
                numSerie = numSerieAnt;
                numSerieAnt = aux + numSerie;
            }
            
        }
        private long[] calculaFibonacciD()
        {
            long[] result = new long[n];
            long aux;
            numSerie = 0;
            numSerieAnt = 1;
            for (int i = 0; i < n; i++)
            {
                aux = numSerie;
                numSerie = numSerieAnterior;
                numSerieAnterior = aux + numSerie;
                result[i] = numSerie;
            }
            long[] desc=new long[n];
            for (int i = 0; i < n; i++) { desc[i] = result[n - i - 1]; }
            return desc;
        }
        public string imprimir()
        {
            string result = "Estos son los " + n + " numeros de Fibonacci organizados descendentemente\n";
            foreach (long i in this.calculaFibonacciD())
            {
                result += " | " + i;
            }

            return result;
        }
    }
}