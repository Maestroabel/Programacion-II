using System;

namespace Programa_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Int32 A;
                A = Convert.ToInt32(args[0]);

                if (A < 0)
                {
                    Console.Error.WriteLine("Error. Solo se aceptan numeros positivos.");
                }
                else
                {
                    for (int i = 1; i < A + 1; i++)
                    {
                        Console.WriteLine(i);
                    }
                }
            }catch (Exception)
            {
                Char[] abecedario = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

                for (int i = 0; i < abecedario.Length; i++)
                {
                    if (args[0].Contains(abecedario[i]))
                    {
                        Console.Error.WriteLine("Error. Solo se acepta un numero.");
                        break;
                    }
                }
            }
        }
    }
}
