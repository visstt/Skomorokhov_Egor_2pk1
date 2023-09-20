namespace pz_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //задание 1
            Console.WriteLine("Задание №1");
            for (int i = 20; i <= 80; i += 3)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            //задание 2
            Console.WriteLine("Задание №2");
            int count1;
            char c;
            for (c = 'з', count1 = 0; count1 < 6; count1++, c++)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //задание 3
            Console.Write("Задание №3");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 6; j++)
                {
                    Console.Write('#');
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            //задание 4
            Console.Write("Задание №4");
            int count = 0;
            Console.WriteLine();
            for (int i = -200; i <= 200; i++)
            {

                if (i % 19 == 0)
                {
                    Console.Write(i + " ");
                    count++;
                }

            }
            Console.WriteLine();
            Console.WriteLine($"Количество чисел кратных 19: {count}");

            Console.WriteLine();

            //задание 5
            Console.WriteLine("Задание №5");
            int a, b;

            for (a = 0, b = 99; b - a > 21; a++, b--)
            {
                Console.WriteLine(a + " " + b);
            }

            Console.WriteLine(a + " " + b);

        }
    }
}