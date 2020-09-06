using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1CSharp
{
    class FilesAndExceptions
    {
        public static void Main()
        {
            string file_name = @"C:\Users\dimik\VisualStudioPojects\repos\ConsoleApp1CSharp\ConsoleApp1CSharp\test1.txt";
            string file_name2 = @"C:\Users\dimik\VisualStudioPojects\repos\ConsoleApp1CSharp\ConsoleApp1CSharp\test2.txt";

            File.WriteAllText(file_name, "Hello world"); //Создает файл file_name 
            //и записывает в него "Hello world"

            //считываем по строкам файл test2.txt
            foreach (string line in File.ReadAllLines(file_name2)) Console.WriteLine(line); //out: Hello!
            //\n 1 \n 2 \n 3 \n 4 \n 5 \n End of file! без "\n", просто с новой строки

            //Но лучше все делать челез потоки записи и чтения:
            FileStream fs = File.Open(file_name2, FileMode.Append);
            string strForAppend = "Not yet!";
            byte[] byteArrForAppend = Encoding.Default.GetBytes(strForAppend);
            fs.Write(byteArrForAppend, 0, byteArrForAppend.Length);    //дописываем в файл строку в конец
            fs.Close();

            //Считываем получившийся файл:
            FileStream fs2 = File.Open(file_name2, FileMode.Open);
            byte[] byteArrFromFile = new byte[10000];
            fs2.Read(byteArrFromFile, 0, 10000);    
            Console.WriteLine(Encoding.Default.GetString(byteArrFromFile));

            fs2.Close();

            Console.WriteLine();




            ///////////////////////////StreamWriter/////////////////////////////////////
            string file_name3 = @"C:\Users\dimik\VisualStudioPojects\repos\ConsoleApp1CSharp\ConsoleApp1CSharp\test3.txt";
            StreamWriter sw = File.AppendText(file_name3);    //Добавляем в файл кажждый раз новые строки 
            sw.WriteLine($"pwd: {file_name3}"); //Печатает эту строку в файл
            sw.WriteLine("End!");                //Аналогично
            sw.Close();

            //Считаем данные из нашего файла:
            StreamReader sr = File.OpenText(file_name3);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
    }
}
