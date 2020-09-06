using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

/// <summary>
/// Рассмотрим как создавать массивы данных 
/// </summary>

namespace ConsoleApp1CSharp
{
    class Arrays
    {
        static void Main(string[] args)
        {
            //Динамический массив List из класса System.Collections.Generic размера 1 элемента
            List<int> arr4 = new List<int>(1) { 1 };   //И присваеваем первому элементу значение 1
            //Добавляем элемент в массив:
            arr4.Add(5);
            Console.WriteLine(arr4[1]); //out: 5
            Console.WriteLine(arr4.Count);  //Длина массива - 2, хоть мы и зарезервировали память под 1 элемент

            //Вставить на место какого-то элемента, но не удалить этот элемент, а подвинуть его:
            arr4.Insert(0, 7);
            Console.WriteLine(arr4.Count);  // 3
            Console.WriteLine($"{arr4[0]} {arr4[1]} {arr4[2]}");   // 7 1 5

            //Удаляем элемент "7", Если хотим удалить по индексу, то RemoveAt()
            arr4.Remove(7);
            foreach (int elem in arr4) Console.Write($"{elem} ");   //1 5
            
        }

        //Создание простого одномерного массива размером 5 (типы данных любые)
        static int[] arr = new Int32[5];

        //Создание двумерного массива размером 4 на 5
        static int[,] arr2 = new Int32[4, 5];
        //или можно сразу его инициализировать
        static int[,] arr3 =
        {
            {1, 2, 3},
            {3, 4, 6},
            {7, 8, 9}
        };

        //обращаться к элементу массива можно так:
        static int a1 = arr[0];        //ничего, так как не инициализирован массив arr
        static int a3 = arr3[1, 2];    //a3 := 6           

        
        
    }
}
