using System;

namespace Prueba_4_BITS
{
    class Program
    {
        static void Main(string[] args)
        {
            int dato = 0, edad;
            string sexo, licencia, coche;
            Console.WriteLine(5 + 10 * 3);
            Console.Read();
            Console.WriteLine("Eres hombre o mujer:");
            sexo = Console.ReadLine();
            Console.WriteLine("Cual es su edad: ");
            edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Tiene licencia? (Si/No):");
            licencia = Console.ReadLine();
            Console.WriteLine("Tiene coche? (Si/No):");
            coche = Console.ReadLine();

            if (sexo == "Hombre".ToLower())
                dato = dato ^ 1;
            if (edad >= 18)
                dato = dato ^ 2;
            if ((licencia == "Si".ToLower()) || (licencia == "S".ToLower()))
                dato = dato ^ 4;
            if ((coche == "Si".ToLower()) || (coche == "S".ToLower()))
                dato = dato ^ 8;

            Console.Clear();
            Console.WriteLine(dato);

        }
    }
}
