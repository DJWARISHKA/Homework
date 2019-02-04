using System;
using System.Text;

namespace Homework
{
    internal class Program
    {
        private static int Discreminant(int a, int b, int c)
        {
            return ((b * b) - (4 * a * c));
        }

        private static double Fx1(int a, int b, int D)
        {
            return (-b + Math.Sqrt(D)) / (2 * a);
        }

        private static double Fx2(int a, int b, int D)
        {
            return (-b - Math.Sqrt(D)) / (2 * a);
        }

        private static void Answer(int a, int b, int D)
        {
            if (D == 0)
            {
                Console.WriteLine("x1 = x2 = " + Fx1(a, b, D).ToString());
            }
            if (D > 0)
            {
                Console.WriteLine("x1 = " + Fx1(a, b, D).ToString());
                Console.WriteLine("x2 = " + Fx2(a, b, D).ToString());
            }
            if (D < 0)
            {
                Console.WriteLine("Не имеет решения");
            }
        }

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("ax^2 + bx + c = 0");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c = ");
            int c = int.Parse(Console.ReadLine());
            int D = Discreminant(a, b, c);
            Console.WriteLine("D = " + D.ToString());
            Answer(a, b, D);
            Console.ReadKey();
        }
    }
}