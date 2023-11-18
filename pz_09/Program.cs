namespace pz_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Введите адрес электронной почты
            Console.WriteLine("Введите адрес электронной почты:");
            string email = Console.ReadLine();

            // Проверяем, содержит ли адрес символы, не являющиеся латинскими буквами, цифрами или разрешенными спецсимволами
            bool validCharacters = true;
            foreach (char с in email)
            {
                if (Char.IsLetterOrDigit(с) && с != '!' && с != '-' && с != '_' && с != '.')
                {
                    validCharacters = true;
                    break;
                }
            }

            // Проверяем наличие символа @
            bool hasAtSymbol = email.Contains("@");

            // Проверяем домен
            bool validDomain = email.EndsWith("gmail.com") || email.EndsWith("yandex.ru") || email.EndsWith("mail.ru");

            // Выводим результаты проверки
            if (validCharacters && hasAtSymbol && validDomain)
            {
                Console.WriteLine("Адрес электронной почты корректен.");
            }
            else
            {
                Console.WriteLine("Адрес электронной почты некорректен.");
            }
        }
    }
}