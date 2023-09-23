namespace pz_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            int n = int.Parse(Console.ReadLine()); // вводим число
            if (n < 0) // делаем проверку
            {
                Console.WriteLine("Вы ввели отрицательное число!");
            }
            else
            {
                int sum = 0;
                int i = 0;
                while (i <= n) // считаем сумму
                {
                    sum += i;
                    i++;
                }
                Console.WriteLine($"Сумма чисел от 0 до {n}: {sum}"); // выводим значения
            }

        }
    }
}