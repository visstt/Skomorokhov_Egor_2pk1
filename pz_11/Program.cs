namespace pz_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int y = int.Parse(Console.ReadLine());
            Quarter(x, y);

        }

        static void Quarter(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                Console.WriteLine("Первая четверть");
            }
            if (x < 0 && y > 0)
            {
                Console.WriteLine("Вторая четверть");
            }
            if (x < 0 && y < 0)
            {
                Console.WriteLine("Третья четверть");
            }
            if (x > 0 && y < 0)
            {
                Console.WriteLine("Четвертая четверть");
            }
        }
    }
}
