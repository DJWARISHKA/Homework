using System;

namespace Pifagor
{    
    class Pifagor
    {
        ///<summary>Считывает положительное число</summary>
        static int ReadInt(string Name) 
        {
            string tmp;
            int x;
            do
            {
                Console.Write($"Введите {Name} = ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out x) && x > 0);
            return x;
        }
        ///<summary>Преобразует в другую с/с</summary>
        static string FromDec(int Num, int Razr)
        {
            if (Razr < 2) return "0";
            string str = "";
            for (; Num != 0; Num /= Razr) {
                int x = Num % Razr;
                str = (char)(x > 10 ? x + 'A' - 10 : x + '0') + str;
                    }
            return str;
        }
        ///<summary>Выводит границы таблицы</summary>
        static void Baunds(int n, int size, int pos)
        {
            string str = "";
            for (int i = 0; i < size; i++)//string.Join("═", size) не помог, выводило size 
                str += "═";
            string[] sign = { "╔╠╚", "╦╬╩", "╗╣╝", str };
            str = sign[0][pos].ToString();
            for (int i = 0; i < n; i++)
            {
                str += sign[3];
                str += sign[1][pos].ToString();
            }
            str += sign[3];
            str += sign[2][pos].ToString(); 
            Console.WriteLine(str);
        }
        ///<summary>Преобразует в другую с/с</summary>
        static void Show(int m, int n, int razr, int size)
        {
            Baunds(n, size, 0);
            for (int i = 0; i <= m; i++) {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write("║");
                    if (i == 0)
                        Console.Write(j.ToString().PadLeft(size));
                    if (j == 0 && i > 0)
                        Console.Write(i.ToString().PadLeft(size));
                    if (i > 0 && j > 0)
                        Console.Write(FromDec(i * j, razr).PadLeft(size));//Вывод числа
                }
                Console.WriteLine("║");
                if (i < m)
                    Baunds(n, size, 1);
                else
                    Baunds(n, size, 2);
            }
        }
        static void Main(string[] args)
        {
            int m, n, razr = 1, size;
            m = ReadInt("m");
            n = ReadInt("n");
            while (razr < 2)
                razr = ReadInt("разрядность");
            string tmp = FromDec(m * n, razr);
            size = tmp.Length;
            Show(m, n, razr, size);
        }
    }
}
