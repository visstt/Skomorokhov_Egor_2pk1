namespace pz_12
{
    internal class Program
    {
        static void Main()
        {
            string[] inputArray = { "hello", "test", "string" }; // задаем массив слов
            string[] result = MaxLengthArray(inputArray); // Вызываем метод MaxLengthArray, передавая ему массив inputArray
            foreach (var item in result) // Перебираем все строки в массиве result
            {
                Console.WriteLine(item);
            }
        }

        static string[] MaxLengthArray(string[] arr) // Определяем метод MaxLengthArray
        {
            int maxLength = arr.Max(item => item.Length); // Ищем максимальную длину строки в массиве arr
            return arr.Select(item => item.PadRight(maxLength, '#')).ToArray(); // Возвращаем массив, содержащий все преобразованные строки
        }
    }
}