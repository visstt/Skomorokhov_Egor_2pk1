using System;
using System.Threading.Channels;

namespace PZ_16
{
    internal class Program
    {
        static bool move = true;
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize]; //карта
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static int enemiesKill = 4;
        static byte enemies = 4; //количество врагов
        static byte buffs = 5; //количество усилений
        static int health = 5;  // количество аптечек   
        static int countMove = 0;// шаги игрока

        // Параметры консоли
        static int winHeight = 40;
        static int winWidth = 100;
        // Параметры игрока 
        static int playerHP = 50;
        static int playerStrong = 10;

        // Параметры врагов
        static int eHp = 30;
        static sbyte eStrong = 5;



        static string console = "Здесь будут выводиться ваши последние действия";
        static int count = 0;
        static int newCount = 0;

        static void StartGame()
        {
            move = true;
            enemies = 4;
            health = 5;
            buffs = 5;
            playerX = mapSize / 2;
            playerY = mapSize / 2;

            Console.Clear();
            string newGameText = ("N - начать новую игру");
            string loadGameText = ("L - загрузить последнее сохранение");

            int text1X = (winWidth / 2) - (winHeight / 2);
            int text1Y = (winHeight / 2) - 1;
            Console.SetCursorPosition(text1X, text1Y);

            Console.Write(newGameText);
            int text2X = (winWidth / 2) - (newGameText.Length / 2) - 10;
            int text2Y = (winHeight / 2);
            Console.SetCursorPosition(text2X, text2Y);
            Console.Write(loadGameText);



            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    GenerationMap();
                    Move();
                    break;
                case ConsoleKey.L:
                    LoadGame();
                    Move();
                    break;


            }

        }
        static string SaveGame()
        {
            string path = @"save.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {                                                    //передаем все необходимые значения
                writer.WriteLine($"playerX={playerX}");
                writer.WriteLine($"playerY={playerY}");
                writer.WriteLine($"playerHP={playerHP}");
                writer.WriteLine($"playerStrong={playerStrong}");
                writer.WriteLine($"countMove={countMove}");
                writer.WriteLine($"eHp={eHp}");


                for (int i = 0; i < mapSize; i++)        // заменяем букву р на _
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (map[i, j] == 'P')
                        {
                            map[i, j] = '_';
                        }
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }

            }
            return path;
        }
        static void LoadGame()
        {
            string path = "save.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                if (lines.Length >= mapSize)
                {
                    if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                        int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                        int.TryParse(lines[2].Split('=')[1], out int loadedPlayerHP) &&
                        int.TryParse(lines[3].Split('=')[1], out int loadedPlayerStrong) &&
                        int.TryParse(lines[4].Split('=')[1], out int loadedPlayerStepCount) &&
                        int.TryParse(lines[5].Split('=')[1], out int loadedEnemyHP) &&
                        int.TryParse(lines[5].Split('=')[1], out int loadedEnemiesKill))
                    {
                        playerX = loadedPlayerX;
                        playerY = loadedPlayerY;
                        playerHP = loadedPlayerHP;
                        playerStrong = loadedPlayerStrong;
                        countMove = loadedPlayerStepCount;
                        eHp = loadedEnemyHP;
                        enemiesKill = loadedEnemiesKill - 27;


                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                            }
                        }

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = lines[i + 6][j];
                            }
                        }
                        map[playerX, playerY] = 'P';

                        Console.Clear();
                        UpdateMap();
                    }



                }
                else
                {

                    Console.WriteLine("Ошибка чтения файла сохранения.");
                }
            }
            else
            {

                Console.WriteLine("Файл сохранения не найден.");
            }
        }


        static void Main(string[] args)
        {
            Console.SetWindowSize(winWidth, winHeight);
            StartGame();


        }


        /// <summary>
        /// генерация карты с расставлением врагов, аптечек, баффов
        /// </summary>
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize - 1; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P'; // в cередину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли
        }
        static void Health()
        {


            playerHP = 50;

        }
        static void BuffUp()
        {


            if (map[playerX, playerY] == 'B')
            {
                playerStrong *= 2;

                newCount = count;
                map[playerX, playerY] = '-';
                console = "Вы подобрали бафф, ваш урон увеличен в 2 раза на 20 шагов";
            }

            if (newCount == count - 20)
            {
                playerStrong = 10;
            }
        }

        static void Fight()
        {
            while (eHp > 0 && playerHP > 0)
            {
                eHp -= playerStrong;
                playerHP -= eStrong;
                Console.SetCursorPosition(0, 29);
                Console.Write($"Здоровье игрока: {playerHP} ");
                if (playerHP == 0)
                {
                    GameOver();

                }
                else if (eHp == 0)
                {


                    map[playerX, playerY] = '_';

                }

            }

            eHp = 30;

        }
        static void GameOver()
        {
            move = false;
            Console.Clear();
            int text1X = (winWidth / 2) - (winHeight / 2) + 10;
            int text1Y = (winHeight / 2);
            Console.SetCursorPosition(text1X, text1Y);
            string over = "ВЫ ПРОИГРАЛИ";

            Console.Write(over);
            Console.ReadLine();
            Console.Clear();

            StartGame();

            Move();
        }
        static void WinGame()
        {


            move = false;
            Console.Clear();
            int text1X = (winWidth / 2) - (winHeight / 2) + 10;
            int text1Y = (winHeight / 2);
            Console.SetCursorPosition(text1X, text1Y);
            string over = "ВЫ ПОБЕДИЛИ";

            Console.Write(over);
            Console.ReadLine();
            Console.Clear();
            StartGame();

            Move();

        }

        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            Console.SetCursorPosition(30, 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Буквой B на карте обозначены баффы");
            Console.SetCursorPosition(30, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Буквой P на карте обозначен игрок");
            Console.SetCursorPosition(30, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Буквой Н на карте обозначены аптечки");
            Console.SetCursorPosition(30, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Буквой Е на карте обозначены враги");
            Console.ForegroundColor = ConsoleColor.White;


            while (move)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                Console.SetCursorPosition(30, 10);
                Console.Write(console);

                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerX--;
                        if (playerX < 0)
                        {
                            playerX = 0;
                        }
                        else countMove++;
                        break;
                    case ConsoleKey.DownArrow:
                        playerX++;
                        if (playerX >= mapSize) playerX = mapSize - 1;
                        else countMove++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerY--;
                        if (playerY < 0) playerY = 0;
                        else countMove++;
                        break;
                    case ConsoleKey.RightArrow:
                        playerY++;
                        if (playerY >= mapSize) playerY = mapSize - 1;
                        else countMove++;
                        break;
                    case ConsoleKey.Escape:
                        SaveGame();
                        Console.Clear();
                        int text1X = (winWidth / 2) - (winHeight / 2) + 10;
                        int text1Y = (winHeight / 2);
                        Console.SetCursorPosition(text1X, text1Y);
                        Console.Write("Игра сохранена");
                        int text2X = (winWidth / 2) - (winHeight / 2) + 10;
                        int text2Y = (winHeight / 2) + 1;
                        Console.SetCursorPosition(text2X, text2Y);
                        Console.WriteLine("Нажмите Enter для выхода из игры");
                        Console.ReadLine();
                        return;
                }


                if (map[playerX, playerY] == 'H')
                {
                    Health();

                    console = "Вы подобрали аптечку, ваше здоровье востановленно               ";

                }
                if (playerX != playerOldX || playerY != playerOldY)
                {
                    count++;
                }
                BuffUp();

                if (map[playerX, playerY] == 'E')
                {
                    Fight();
                    console = "Вы вступили в бой                                               ";
                    enemiesKill--;
                }

                if (enemiesKill <= 0)
                {
                    WinGame();
                }




                Console.CursorVisible = false; //скрытный курсор

                Console.SetCursorPosition(0, 28);
                Console.Write($"Шагов сделано: {countMove} ");
                Console.SetCursorPosition(0, 29);
                Console.Write($"Здоровье игрока: {playerHP} ");

                Console.SetCursorPosition(0, 30);
                Console.Write($"Сила удара игрока: {playerStrong} ");
                Console.SetCursorPosition(0, 31);



                //предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');
                //обновленное положение игрока
                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('P');


            }
        }

        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (map[i, j] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(map[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine(map[i, 0]);

            }
        }
    }
}
