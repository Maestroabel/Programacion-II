using System;
using System.IO;

namespace Examen_Final_Prog_II
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("Entrada.csv"))
            {
                Codificar Codificar = new Codificar();
                Decodificar decodificar = new Decodificar();
                Codificar.CodificarEntrada();
                decodificar.DecodificarSalida();           
            }
            else
            {
                StreamWriter Entrada = File.CreateText("Entrada.csv");
                Entrada.WriteLine("FechayTiempo,TempMinima,TempMaxima,Precipitacion");
                Entrada.WriteLine("2020-07-13T19:30:25.525-04:00,25,34,30");
                Entrada.WriteLine("2015-08-25T10:24:45.620-02:00,19,24,56");
                Entrada.WriteLine("1995-12-15T15:23:35.248+03:00,45,56,85");
                Entrada.WriteLine("2005-05-05T09:10:47.152+07:00,14,28,65");
                Entrada.WriteLine("2001-12-26T12:00:19.884-04:00,30,38,75");
                Entrada.Close();
            }
        }      
    }
}
