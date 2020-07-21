using System;

namespace Programa_3
{
    class Program
    {
        static void Main(string[] args)
        {
            float A = 1;
            float[] B = new float[999999];

            for (int i = 0; A > 0; i++)
            {
                try
                {
                    A = int.Parse(Console.ReadLine());
                    B[i] = A * A;
                }
                catch (Exception)
                {
                    for (int f = 0; f < B.Length; f++)
                    {
                        if (B[f] == 0)
                        {
                            break;
                        }
                        Console.WriteLine(B[f]);
                    }                  
                    break;
                }              
            }
            Console.ReadLine();
        }
    }
}
