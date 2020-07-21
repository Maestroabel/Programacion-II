using System;
using System.IO;
using System.Text;

namespace Examen_Final_Prog_II
{
    class Decodificar
    {
        public void DecodificarSalida()
        {
            var lineas = File.ReadAllLines("Salida.csv");
            for (int i = 1; i < lineas.Length; i++)
            {
                var linea = lineas[i];
                string[] columnas = linea.Split(",");
                long[] numeroBI = { long.Parse(columnas[0]), long.Parse(columnas[1])};

                long año = numeroBI[0] >> 48;
                long mes = (numeroBI[0] >> 44) & 15;
                long dia = (numeroBI[0] >> 39) & 31;
                long Hora = (numeroBI[0] >> 34) & 31;
                long Minuto = (numeroBI[0] >> 28) & 63;
                long Segundo = (numeroBI[0] >> 22) & 63;
                long MilliSeg = (numeroBI[0] >> 12) & 1023;

                long SignoBI = (numeroBI[0] >> 11) & 1;
                Char Signo; if (SignoBI == 0) Signo = '+'; else Signo = '-';
                long ZHhora = (numeroBI[0] >> 6) & 31;

                long TempMinimo = (numeroBI[1] >> 14) & 127;
                long TempMaximo = (numeroBI[1] >> 7) & 127;
                long Precipitacion = numeroBI[1] & 127;

                Console.WriteLine("CODIFICACION {0}",i);
                Console.WriteLine($"{columnas[0]},{columnas[1]}");
                Console.WriteLine("DECODIFICACION {0}",i);
                Console.WriteLine($"{año}-{mes}-{dia}T{Hora}:{Minuto}:{Segundo}.{MilliSeg}{Signo}{ZHhora}:00,{TempMinimo},{TempMaximo},{Precipitacion}\n");
            }
        } 
    }
}
