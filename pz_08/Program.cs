﻿using System;
using System.Net.WebSockets;

namespace PZ_08
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1 и 2");
            Console.WriteLine();
            Random random = new Random();
            string[][] arr = new string[10][]; // создаем двумерный массив строк размером 10

            for (int i = 0; i < arr.Length; i++) // генерируем массив
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[j] = new string[random.Next(9, 41)]; // задаем случайный размер для каждого элемента массива
                }
            }

            Console.WriteLine();
            string rndStr = "qwertyuiopasdfghjklzxcvbnm"; // задаем строку из которой будем формировать значения элементов массива

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    string a = Convert.ToString(rndStr[random.Next(rndStr.Length)]); // генерируем случайный символ из строки rndStr
                    arr[i][j] = a + a + a + a; // присваиваем элементу массива 4 одинаковых символа
                    Console.Write(arr[i][j] + " "); 
                }
            }
            Console.WriteLine();
            Console.WriteLine("Задание 3");
            Console.WriteLine();

            string[] lastSimvol = new string[10]; // создаем массив для хранения последнего символа каждого элемента массива arr


            for (int i = 0; i < lastSimvol.Length; i++)
            {
                lastSimvol[i] = arr[i][^1]; // присваиваем последний символ каждого элемента массива arr соответствующему элементу массива lastSimvol
                Console.Write(lastSimvol[i] + " "); 
            }

            Console.WriteLine();
            Console.WriteLine("Задание 4");
            Console.WriteLine();

            for (int i = 0; i < lastSimvol.Length; i++)
            {
                lastSimvol[i] = arr[i].Max(); // присваиваем элементу массива lastSimvol максимальное значение из элементов каждого элемента массива arr
                Console.Write(lastSimvol[i] + " "); 
            }
            Console.WriteLine();
            Console.WriteLine("Задание 5");
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                string b = arr[i][0]; // сохраняем первый элемент каждого элемента массива arr в переменную b
                string c = arr[i].Max(); // находим максимальное значение в каждом элементе массива arr и сохраняем его в переменную c
                int n = Array.IndexOf(arr[i], c); // находим индекс максимального значения в каждом элементе массива arr и сохраняем его в переменную n
                arr[i][0] = c; // присваиваем первому элементу каждого элемента массива arr значение c
                arr[i][n] = b; // присваиваем элементу массива arr по индексу n значение b
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " "); // выводим элемент массива arr на консоль
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Задание 6");
            Console.WriteLine();
            
            for (int i = 0; i < arr.Length; i++) // Реверс каждой строки массива
            {
                Array.Reverse(arr[i]); 
            }

            
            for (int i = 0; i < arr.Length; i++) // Вывод массива после реверса
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " "); 
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Задание 7");

            int[] symbolCount = new int[arr.Length]; // Создаем массив symbolCount длины arr.Length для хранения количества символов в каждом элементе arr

            for (int i = 0; i < arr.Length; i++)
            {
                symbolCount[i] = 0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    symbolCount[i] += arr[i][j].Length;
                }
            }

            for (int i = 0; i < arr.Length; i++) // Выводим каждый элемент arr, его элементы и количество символов в нем
            {
                for (int j = 0; j < arr[i].Length; j++) // Выводим каждый элемент внутреннего массива arr[i] с пробелом после него
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.Write("Количество символов: " + symbolCount[i]);
                Console.WriteLine();
            }


        }
    }
}