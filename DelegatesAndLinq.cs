using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ConsoleApp1CSharp
{
    class DelegatesAndLinq
    {
        delegate void ShowMessage();
        delegate int Math(int a, int b);
        delegate float SquareNum(float num);

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Sub(int a, int b)
        {
            return a - b;
        }

        private static void goodMorning()
        {
            Console.WriteLine("Good morning");
        }
        private static void goodNight()
        {
            Console.WriteLine("Good night");
        }
        public static void Main()
        {
            //Узнаем который час
            int curTime = DateTime.Now.Hour;

            ShowMessage sm;
            if (curTime < 12) sm = goodMorning;
            else sm = goodNight;

            sm();  //если сейчас меньше 12 чаосв, то возвращает Good night, иначе Good morning

            Math operation = Add;
            Console.WriteLine(operation(1, 5)); //6

            operation = Sub;
            Console.WriteLine(operation(5, 2));  //3

            //Лямбда-функция
            SquareNum square = number => number * number;

            Console.WriteLine($"4^2 = {square(4)}");   //4^2 = 16

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 6, 12};
            //переменная, в которую мы можем поместить любой тип данных  (c помощью linq)
            //в переменную list поместим список из чисел из numbers, которые кратны 3м
            var list = numbers.Where(elem => (elem % 3 == 0) && (elem < 15)).ToList();
            foreach (var el in list) Console.Write($"{el} ");     //out: 3 6 12
            
            Console.WriteLine();

            //Возвращаем список квадратов элементов из numbers
            var list2 = numbers.Select(elem => elem * elem);
            foreach (var el in list2) Console.Write($"{el} "); //1 4 9 16 36 144

            Console.WriteLine();

            int sum = list2.Aggregate((x, y) => x + y);
            Console.WriteLine($"Сумма квадратов: {sum}");   //Сумма квадратов: 210


            //Умножаем квадрат числа на само число, то естьь возводим в третью степень, используя два массива
            var groupAndMult = numbers.Zip(list2, (x, y) => x * y);
            foreach (var el in groupAndMult) Console.Write($"{el} "); //1 8 27 64 216 1728

            Console.WriteLine();

            //найдем неповторяющиеся элементы
            List<int> numbers2 = new List<int>() { 1, 5, 3, 2, 3, 1, 4, 7, 3 };
            string result = string.Join(", ", numbers2.Distinct());   //Distinct() - удаляет повторяющиеся элементы
            Console.WriteLine(result);  //out: 1, 5, 3, 2, 4, 7
        }
    }
}
