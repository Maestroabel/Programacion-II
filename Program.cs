using System;
using System.Threading;

namespace HowToMurphy
{
    class Program
    {
        static float t = 0;
        static void dot() { Console.Beep(600, 250); }
        static void dash() { Console.Beep(600, 750); }

        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                ContarTiempo(item);
            }
            t = (t / 1000);
            Console.WriteLine($"El tiempo que durara este mensaje es de {t} segundos");
            Thread.Sleep(1000);
            foreach (var item in args)
            {
                CodigoMorse(item);
                Thread.Sleep(1750);
            }
        }
        static void CodigoMorse(String item)
        {
            do
            {
                foreach (char c in item.ToUpper())
                {
                    Thread.Sleep(300);
                    switch (c)
                    {
                        case 'A':
                            dot();
                            dash();
                            break;
                        case 'B':
                            dash();
                            dot();
                            dot();
                            dot();
                            break;
                        case 'C':
                            dash();
                            dot();
                            dash();
                            dot();
                            break;
                        case 'D':
                            dash();
                            dot();
                            dot();
                            break;
                        case 'E':
                            dot();
                            break;
                        case 'F':
                            dot();
                            dot();
                            dash();
                            dot();
                            break;
                        case 'G':
                            dash();
                            dash();
                            dot();
                            break;
                        case 'H':
                            dot();
                            dot();
                            dot();
                            dot();
                            break;
                        case 'I':
                            dot();
                            dot();
                            break;
                        case 'J':
                            dot();
                            dash();
                            dash();
                            dash();
                            break;
                        case 'K':
                            dash();
                            dot();
                            dash();
                            break;
                        case 'L':
                            dot();
                            dash();
                            dot();
                            dot();
                            break;
                        case 'M':
                            dash();
                            dash();
                            break;
                        case 'N':
                            dash();
                            dot();
                            break;
                        case 'O':
                            dash();
                            dash();
                            dash();
                            break;
                        case 'P':
                            dot();
                            dash();
                            dash();
                            dot();
                            break;
                        case 'Q':
                            dash();
                            dash();
                            dot();
                            dash();
                            break;
                        case 'R':
                            dot();
                            dash();
                            dot();
                            break;
                        case 'S':
                            dot();
                            dot();
                            dot();
                            break;
                        case 'T':
                            dash();
                            break;
                        case 'U':
                            dot();
                            dot();
                            dash();
                            break;
                        case 'V':
                            dot();
                            dot();
                            dot();
                            dash();
                            break;
                        case 'W':
                            dot();
                            dash();
                            dash();
                            break;
                        case 'X':
                            dash();
                            dot();
                            dot();
                            dash();
                            break;
                        case 'Y':
                            dash();
                            dot();
                            dash();
                            dash();
                            break;
                        case 'Z':
                            dash();
                            dash();
                            dot();
                            dot();
                            break;
                        case '1':
                            dot();
                            dash();
                            dash();
                            dash();
                            dash();
                            break;
                        case '2':
                            dot();
                            dot();
                            dash();
                            dash();
                            dash();
                            break;
                        case '3':
                            dot();
                            dot();
                            dot();
                            dash();
                            dash();
                            break;
                        case '4':
                            dot();
                            dot();
                            dot();
                            dot();
                            dash();
                            break;
                        case '5':
                            dot();
                            dot();
                            dot();
                            dot();
                            dot();
                            break;
                        case '6':
                            dash();
                            dot();
                            dot();
                            dot();
                            dot();
                            break;
                        case '7':
                            dash();
                            dash();
                            dot();
                            dot();
                            dot();
                            break;
                        case '8':
                            dash();
                            dash();
                            dash();
                            dot();
                            dot();
                            break;
                        case '9':
                            dash();
                            dash();
                            dash();
                            dash();
                            dot();
                            break;
                        case '0':
                            dash();
                            dash();
                            dash();
                            dash();
                            dash();
                            break;
                        default:
                            break;
                    }
                }
            } while (item == null);
        }
        static void ContarTiempo(String item)
        {
            do
            {
                foreach (char c in item.ToUpper())
                {
                    switch (c)
                    {
                        case 'A':
                            t = t + 750;
                            break;
                        case 'B':
                            t = t + 1250;
                            break;
                        case 'C':
                            t = t + 1500;
                            break;
                        case 'D':
                            t = t + 1000;
                            break;
                        case 'E':
                            t = t + 250;
                            break;
                        case 'F':
                            t = t + 1250;
                            break;
                        case 'G':
                            t = t + 1250;
                            break;
                        case 'H':
                            t = t + 1000;
                            break;
                        case 'I':
                            t = t + 500;
                            break;
                        case 'J':
                            t = t + 1750;
                            break;
                        case 'K':
                            t = t + 1250;
                            break;
                        case 'L':
                            t = t + 1250;
                            break;
                        case 'M':
                            t = t + 1000;
                            break;
                        case 'N':
                            t = t + 750;
                            break;
                        case 'O':
                            t = t + 1500;
                            break;
                        case 'P':
                            t = t + 1500;
                            break;
                        case 'Q':
                            t = t + 1750;
                            break;
                        case 'R':
                            t = t + 1000;
                            break;
                        case 'S':
                            t = t + 750;
                            break;
                        case 'T':
                            t = t + 500;
                            break;
                        case 'U':
                            t = t + 1000;
                            break;
                        case 'V':
                            t = t + 1250;
                            break;
                        case 'W':
                            t = t + 1250;
                            break;
                        case 'X':
                            t = t + 1500;
                            break;
                        case 'Y':
                            t = t + 1750;
                            break;
                        case 'Z':
                            t = t + 1500;
                            break;
                        case '1':
                            t = t + 2250;
                            break;
                        case '2':
                            t = t + 2000;
                            break;
                        case '3':
                            t = t + 1750;
                            break;
                        case '4':
                            t = t + 1500;
                            break;
                        case '5':
                            t = t + 1250;
                            break;
                        case '6':
                            t = t + 1500;
                            break;
                        case '7':
                            t = t + 1750;
                            break;
                        case '8':
                            t = t + 2000;
                            break;
                        case '9':
                            t = t + 2250;
                            break;
                        case '0':
                            t = t + 2500;
                            break;
                        default:
                            break;
                    }
                }
            } while (item == null);
        }
    }
}