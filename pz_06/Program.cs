namespace pz_06;
class Program
{
    static void Main(string[] args)
    {
        int[] array1 = new int[10];
        int[] array2 = new int[10];
        Random random = new Random();

        // Заполнение первого массива рандомными числами в диапазоне [0, 100]
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = random.Next(0, 101);
        }

        // Заполнение второго массива индексами четных элементов первого массива
        int index2 = 0;
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] % 2 == 0)
            {
                array2[index2] = i;
                index2++;
            }
        }

        // Вывод значений первого массива
        Console.WriteLine("Первый массив:");
        foreach (int num in array1)
        {
            Console.Write(num + " ");
        }

        // Вывод значений второго массива
        Console.WriteLine("\n\nВторой массив:");
        foreach (int num in array2)
        {
            Console.Write(num + " ");
        }

        Console.ReadLine();
    }
}
