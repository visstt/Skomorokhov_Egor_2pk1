using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите путь к каталогу: ");
            string directoryPath = Console.ReadLine();

            if (Directory.Exists(directoryPath))
            {
                string tempDirectoryPath = Path.Combine(directoryPath, "TEMP");

                // Создаем подкаталог "TEMP"
                Directory.CreateDirectory(tempDirectoryPath);
                Console.WriteLine($"Подкаталог {tempDirectoryPath} успешно создан.");

                // Получаем файлы из каталога
                string[] files = Directory.GetFiles(directoryPath);

                // Переносим файлы в подкаталог "TEMP"
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFilePath = Path.Combine(tempDirectoryPath, fileName);

                    File.Move(file, destinationFilePath);
                }

                Console.WriteLine("Содержимое каталога успешно перенесено в подкаталог \"TEMP\".");
            }
            else
            {
                Console.WriteLine("Указанный каталог не существует.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }
}
