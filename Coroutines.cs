using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ConsoleApp1CSharp
{
    class Coroutines
    {
        public static void Main()
        {
            //главный поток
            Thread threadMain = Thread.CurrentThread;
            threadMain.Name = "Main thread";
            Console.WriteLine($"Priority: {threadMain.Priority}, Status: " +
                $"{threadMain.ThreadState}, Is alive: {threadMain.IsAlive}, Project name: " +
                $"{Thread.GetDomain().FriendlyName}");
            //Priority: Normal, Status: Running, Is alive: True, Project name: ConsoleApp1CSharp


            //Создадим свой поток: Если хотим передавать в функцию printSome() параметр, 
            //то делаем так и передаем в myTh.Start(6) параметр функции. если без параметра, то просто 
            //ThreadStart(printSome)
            Thread myTh = new Thread(new ParameterizedThreadStart(printSome));
            myTh.Start(6);

            //выводится "Main thread" "Support thread" поочередно
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread");
                Thread.Sleep(200);
            }

            //Создадим поток и передадим в него экземпляр класса Point:
            Point point = new Point(4, 7);
            Thread myTh2 = new Thread(new ParameterizedThreadStart(printPoint));
            myTh2.Start(point);    //В самом конце запустится поток и напишется x=4, y=7 спустя секунда


            //Запускаем функцию непосредственно экземпляра класса, и тогда все параметры уже переданы.
            Thread myTh3 = new Thread(new ThreadStart(point.printDistance));
            myTh3.Start();   //Расстояние до центра от точки (4, 7) = 8,06225774829855, причем это выведется перед предыдущим x=4, y=7 



        }



        private static void printPoint(object obj)
        {
            Point point = (Point) obj;
            Thread.Sleep(1000);
            Console.WriteLine($"x={point.x}, y={point.y}");   //x=4, y=7  
        }

        private static void printSome(object obj)
        {
            int x = (int) obj;
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Support thread - " + x);
                Thread.Sleep(200);
            }
        }

        public class Point
        {
            public int x, y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void printDistance()
            {
                Console.WriteLine($"Расстояние до центра от точки ({x}, {y}) = {Math.Sqrt(x * x + y * y)}");
            }
        }
    }
}
