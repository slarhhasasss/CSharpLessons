using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CSharp
{
    class Loops
    {
        static void Main(string[] args)
        {
            //Обычные циклы for, while, do-while  -  как в си или си++
            //Но есть foreach(), с помощью которого можно перебрать элементы списка какого-либо:
            string[] arr = { "str1", "str2", "str3" };
            foreach (string elem in arr) Console.Write($"{elem} ");   //str1 str2 str3
            
            //Операторы if/else if/else и switch/case/default как в си или си++
        }
    }
}
