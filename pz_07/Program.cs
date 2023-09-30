namespace pz_07
{
    internal class Program
    {
        static void Main(string[] args)
        {   // Создаем матрицу
            int[,] matrix = {
            { 5, 2, 9 },
            { 1, 8, 4 },
            { 7, 3, 6 }
        };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Сортировка столбцов по убыванию значений элементов в первой строке
            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - i - 1; j++)
                {
                    if (matrix[0, j] < matrix[0, j + 1])
                    {
                        // Обмен значений столбцов
                        for (int k = 0; k < rows; k++)
                        {
                            int temp = matrix[k, j];
                            matrix[k, j] = matrix[k, j + 1];
                            matrix[k, j + 1] = temp;
                        }
                    }
                }
            }

            // Вывод отсортированной матрицы
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}