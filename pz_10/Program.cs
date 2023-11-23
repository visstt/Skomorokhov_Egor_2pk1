namespace pz_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите почты:");
            string mails = Console.ReadLine();

            string[] mailArray = mails.Split();
            foreach (string mail in mailArray)
            {
                int atIndex = mail.IndexOf('@');
                if (atIndex != -1)
                {
                    string name = mail.Substring(0, atIndex);
                    Console.WriteLine("Привет, " + name);
                }
            }
        }
    }
}