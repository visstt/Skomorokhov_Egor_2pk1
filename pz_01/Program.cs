namespace pz_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Вводим переменные а b с
            Console.WriteLine("Введите переменную a");
            double a = double.Parse(Console.ReadLine());
            if (a == 0) // проверка на недопустимые значения a
            {
                Console.WriteLine("Недопустимое значение, введите снова корректное число");
                a = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите переменную b");
            double b = double.Parse(Console.ReadLine());
            if (b < 0) // проверка на недопустимые значения b
            {
                Console.WriteLine("Недопустимое значение, введите снова корректное число");
                b = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите переменную c");
            double c = double.Parse(Console.ReadLine());

            // разбиваем пример на части и решаем по отдельности 
            double num1 = 1 / 9; 
            double num2 = Math.Sqrt((Math.Pow(a, 2) + b) / (0.4 * a));
            double num3 = Math.Pow(10, 4) * Math.Exp(a * c);
            double num4 = Math.Cos(Math.Sqrt(Math.Pow(a, 2) + b));
            double num5 = Math.Sin(3) / (5 * (Math.Pow(a, 2) + b));
            double result = num1 + num2 - num3 + num4 + num5;
            
            Console.WriteLine("Ваш результат: " + result); // выводим результат

        }
    }
}