namespace pz_14
{
    internal class Program
    {
        static void FileWrite(string path) // метод для прочтения файла
        {
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    Console.WriteLine("Текст в файле:");
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }

        static void Main(string[] args)
        {
            string path = @"f1.txt";  // создаем путь для f1
            string dir = @"./new";  // создаем путь для директории 


            string filePath = Path.Combine(dir, @"f2.txt"); // создаем в директории файл f2
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)) // заполняем файл f1
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine("klhfg;lsdh;ndgflkjvndzkfjnv;ldzfjvdnf");
                    writer.WriteLine("i`m superstar");
                }



            }
            Console.WriteLine("Первый файл");
            FileWrite(path);  // выводим содержимое f1

            Directory.CreateDirectory(dir); // создаем диреккторию

            File.Copy(path, filePath); // копируем данные из f1 в f2


            Console.WriteLine("Второй файл");
            FileWrite(filePath); // выводим f2





        }
    }
}
