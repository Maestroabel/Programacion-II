using System;

namespace Programa_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 1, B = 0;
            double C = 0;

            for (int i = 0; A > 0; i++)
            {
                try
                {
                    A = int.Parse(Console.ReadLine());
                    B = B + A;
                    C++;
                }
                catch (Exception)
                {
                    C = B / C;
                    Console.WriteLine(C);
                    break;
                }
            }
        }
    }
}
