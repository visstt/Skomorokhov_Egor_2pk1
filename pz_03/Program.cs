namespace pz_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random ran = new Random(); // рандомно задаем число

                int day = ran.Next(1, 32);

                Console.WriteLine($"Ваша дата {day}"); // выводим данное число в консоль
                int dekada = 0;
                if (day <= 10)
                {
                    dekada += 1;
                }
                if (day > 10 && day < 21)
                {
                    dekada += 2;
                }
                if (day >= 21)
                {
                    dekada += 3;
                }

                switch (dekada)  // сравнимваем каждую дату использую проваливающиеся ветви
                {
                    case 1:

                        Console.WriteLine("Это первая декада месяца"); //  выводим декаду согласно выпавшему числу
                        break;
                    case 2:

                        Console.WriteLine("Это вторая декада месяца");
                        break;
                    case 3:

                        Console.WriteLine("Это третья декада месяца");
                        break;




                }
                Console.WriteLine();
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}