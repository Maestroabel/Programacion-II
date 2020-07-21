using System;

namespace Programa_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B = 0;

            do
            {
                try
                {
                    A = int.Parse(Console.ReadLine());
                    B = B + A;
                }
                catch (Exception)
                {
                    Console.WriteLine(B);
                    break;
                }
            } while (A > -1);
        }
    }
}
