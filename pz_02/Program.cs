using System.Collections.Concurrent;

namespace pz_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)  // делаем цикл бесконечным
            {

                double d, p, q, r;   // вводим все переменные
                Console.Write("Введите переменную b: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Введите переменную d: ");
                d = double.Parse(Console.ReadLine());

                if (b > 2)

                    p = b * Math.Cos(d) / Math.Sqrt(Math.Pow(d, 2) - b);

                else
                    p = 2 - Math.Exp(Math.Abs(b)) * Math.Sin(b);

                if (Math.Cos(b * p) == 0) // проверяем чтобы знаменатель не был равен нулю
                    Console.WriteLine("Ошибка в вычислениях. Введите корректные данные b и p!");


                if (p <= 0)
                    q = Math.Pow(Math.Sin(b * p), 2) - Math.Pow(Math.Cos(b * p), 2);

                else
                    q = Math.Pow(Math.Sin(b * p), 2) - 1 / Math.Pow(Math.Cos(b * p), 2);

                r = 23 * b + 1.2 * p * Math.Pow(q, 2) + d / 2;


                Console.WriteLine($"Значение р ={Math.Round(p, 2)}");  //  выводим все значения и округляем до второй цифры после запятой
                Console.WriteLine($"Значение q ={Math.Round(q, 2)}");
                Console.WriteLine($"Значение r ={Math.Round(r, 2)}");
                

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}