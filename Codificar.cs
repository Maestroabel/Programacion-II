using System;
using System.IO;

namespace Examen_Final_Prog_II
{
    class Codificar
    {
        public static void CodificarEntrada()
        {
            var lineas = File.ReadAllLines("Entrada.csv");
            StreamWriter Salida = File.CreateText("Salida.csv");
            Salida.WriteLine("DatoYtiempo,Clima");
            Salida.Close();

            for (int i = 1; i < lineas.Length; i ++)
            {
                var linea = lineas[i];
                string[] columnas = linea.Split(",");

                string tiempo = columnas[0];
                int Signo = tiempo.IndexOf('-', 20);
                int TempMinimo = int.Parse(columnas[1]);
                int TempMaximo = int.Parse(columnas[2]);
                int precipitacion = int.Parse(columnas[3]);
                int Clima = (((TempMinimo << 7) | TempMaximo) << 7) | precipitacion;

                FechayTiempo FyT = new FechayTiempo(tiempo, Signo);
                long fechayTiempo = FechayTiempo.FechayTiempoEntrada(FyT);

                Salida = File.AppendText("Salida.csv");
                Salida.WriteLine($"{fechayTiempo},{Clima}");
                Salida.Close();
            }
        }
    }
}
