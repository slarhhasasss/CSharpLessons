using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1CSharp
{
    class Funs
    {
        static void Main(string[] args)
        {
            PrintHello("Alina");   //"Hello, Dima, from Alina"
            PrintHello("Valera", "Katya"); //"Hello, Katya, from Valera"

            int a = 2, b = 2;
            int res = 0;
            Sum(a, b, out res);      //return 4
            Console.WriteLine(res);  //out: 4

            int a1 = 3, b1 = 5;
            ChangeNumbers(ref a1, ref b1);
            Console.WriteLine(a1);            //out: 5

            Console.WriteLine(SumAll(a, b, a1, b1));  //out: 12

            Console.WriteLine(maxSizeMemory<float>(-18.1f, 15.3f));  //out: 15.3 - просто выводит самое большое число

        }



        //Обычная функция, где "Dima" - значение по умолчанию
        public static void PrintHello(string nameFrom, string nameTo = "Dima")
        {
            Console.WriteLine($"Hello, {nameTo}, from {nameFrom}");
        }



        //Функция, в которую можно передавать непосредственно элемент из вне, чтобы изменить его:
        //Здесь у нас a и b это обычные параметры, а вот out int res - это некоторая переменная, 
        //в которую мы записываем результат, и она уже существует вне функции.
        //Причем эта функция все равно может возвращать значение
        public static int Sum(int a, int b, out int res)
        {
            res = a + b;
            return a + b;
        }

        //Аналогично можно перегрузить функцию, чтобы она принимала на вход значения float:
        public static float Sum(float a, float b, out float res)
        {
            res = a + b;
            return a + b;
        }



        //Функция, которая может принимать ссылки
        public static void ChangeNumbers(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp; 
        }



        //Функция с неизвестным количеством параметров
        public static int SumAll(params int[] arr)
        {
            int res = 0;
            foreach (int elem in arr) res += elem;
            return res;
        }


        //функция с указанием типа данных:
        //Эта функция возвращает место в массиве искомого элемента, если такого элемента нет, то возвращает -1
        public static int FindElementIdAtArray<Type>(Type[] arr, Type element) 
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(element)) return i;
            }
            return -1;
        }

        //Возвращаем элемент с максимальным хешкодом
        public static Type maxSizeMemory<Type>(Type a, Type b)
        {
            int sizeA = a.GetHashCode();
            int sizeB = b.GetHashCode();
            return sizeA >= sizeB ? a : b;
        }
    }
}
