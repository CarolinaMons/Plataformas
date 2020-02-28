using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMaya
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader arcHAAB = new StreamReader(@"..\..\..\HAAB.txt"); //El archivo debe estar en la misma carpeta de la solucion
            StreamWriter arcTzolkin = new StreamWriter(@"..\..\..\Tzolkin.txt");
            string LineaHAAB;
            string[] split=new string[3];
            //Leer
            LineaHAAB = arcHAAB.ReadLine(); //Leer la primera linea para obtener el total de fechas HAAB
            int N = Convert.ToInt32(LineaHAAB);
            HAAB[] FechasHAAB = new HAAB[N]; //Crear un vector de HAAB del tamaño total de las fechas
            for(int i = 0; i < N; i++)
            {
                if ((LineaHAAB = arcHAAB.ReadLine()) != null)//Leo las lineas del archivo HAAB
                {
                    split = LineaHAAB.Split(' ');
                    FechasHAAB[i] = new HAAB(Convert.ToInt32(split[0].Replace('.', ' ')), split[1], Convert.ToInt32(split[2])); //Creo y guardo el objeto HAAB
                }
            }
            arcHAAB.Close();
            //Escribir
            arcTzolkin.WriteLine(N.ToString()); //Escribir el numero total de fechas
            for (int i = 0; i < N; i++)
            {
                Tzolkin tmp = FechasHAAB[i].converToTzolkin(); //Convertir cada elemento del vector en fechas Tzolkin
                arcTzolkin.WriteLine(tmp.NroDia + " " + tmp.NomDia + " " + tmp.Año);
            }
            arcTzolkin.Close();
        }

        class HAAB
        {
            public string Mes { get; set; }
            public int Año { get; set; }
            public int NroDia { get; set; }
            //Vector con todos los meses
            public static string[] Meses = { "pop", "no", "zip", "zotz", "tzec", "xul", "yoxkin", "mol", "chen", "yax", "zac", "ceh", "mac", "kankin", "muan", "pax", "koyab", "cumhu" };
            public HAAB(int nroDia, string mes, int año)
            {
                if (año < 5000) //Validar el año
                    Año = año;
                if (Meses.Contains<string>(mes)) //Validar el mes
                {
                    Mes = mes;
                    if (mes.Equals(Meses[17]) && nroDia < 5)//Validar si es el ultimo mes debe ser menor a 5
                        NroDia = nroDia;
                    else if (nroDia < 20) //Validar el numero del dia para el resto de los meses
                        NroDia = nroDia;
                }
            }

            public Tzolkin converToTzolkin() //Convertir a un calentario Tzolkin
            {
                int dia = 0; //El dia inicia en 0
                int año = 0; //Año inicia en 0
                int nromes = 0; //Halla el numero del mes en el que esta HAAB
                for (int i = 0; i < Meses.Length; i++)
                {
                    if (Meses[i].Equals(Mes))
                    {
                        nromes = i;
                        break;
                    }
                }
                int total = Año * 365 + nromes * 20 + NroDia; //Obtener el numero total de dias que van en el HAAB
                string nom = Tzolkin.NomDias[NroDia]; //El nombre del dia en Tzolkin corresponde al numero del dia en HABB
                for (int i = 0; i <= total; i++)
                {
                    dia++;
                    if (dia > 13) //Si el dia ya pasa de 13, se reinicia el conteo
                    {
                        dia = 1;
                    }
                    if (i>0 && i % 260 == 0) //Se empieza a aumentar los años despues del dia 0 y cada 260 dias van un año en Tzolkin
                    {
                        año++;
                    }  
                }
                return new Tzolkin(dia, nom, año);
            }
        }
        class Tzolkin
        {
            public string NomDia { get; set; }
            public int Año { get; set; }
            public int NroDia { get; set; }
            //Nombres de los dias
            public static string[] NomDias = { "imix", "ik", "akbal", "kan", "chicchan", "cimi", "manik", "lamat", "muluk", "ok", "chuen", "eb", "ben", "ix", "mem", "cib", "caban", "eznab", "canac", "ahau" };
            
        public Tzolkin(int nroDia, string nomDia, int año)
        {
            Año = año; //No hay restriccion de años
            if (NomDias.Contains<string>(nomDia)) //El nombre del dia este en el vector
                NomDia = nomDia;
            if (nroDia < 14) //El numero de dia debe ser menor a 14
                NroDia = nroDia;
        }
    }
}
}
