using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CSharp
{
    class StructsAndOperatoAsrs
    {
        public static void Main()
        {
            work dimasJob = new work(200, "Programmist");
            User dima = new User("dima", dimasJob, 18);

            dima.userWork.printJobInfo();   //Job: Programmist, zp: 200

            Console.WriteLine(isUser(6));  //False
            Console.WriteLine(isUser(dima)); //True

            User proAlina = new User("Alina", dimasJob, 19, "frmale");
            Console.WriteLine(isUser(proAlina)); //True, так как ПроЮзер - это дочерний класс Юзера
            //proAlina.printStatus();               //Alina is ProUser!!!

            ProUser alina = proAlina as ProUser;
            Console.WriteLine(isUser(alina)); //False
            Console.WriteLine(alina == null);  //True - Почему-то обнуляет данные

            



        }

        //Возвращает тру, если obj - объект класса User
        public static bool isUser(object obj)
        {
            //is - Определяет принадлежит ли элемент выбранному классу или его дочернему родительскому классу
            return obj is User ? true : false;
        }
    }


    //РОДИТЕЛЬСКИЙ класс
    public class User
    {
        protected string name, gender;
        protected int age;
        public work userWork;

        public User(string name, work userWork, int age = 0, string gender = "Not stated")
        {
            this.age = age;
            this.name = name;
            this.gender = gender;
            this.userWork = userWork;
        }
    }

    //Дочерний класс
    public class ProUser : User
    {
        bool isProUser = true;
        public ProUser(string name, work userWork, int age = 0, string gender = "Not stated")
            : base(name, userWork, age, gender) 
        {
        }

        public void printStatus()
        {
            Console.WriteLine($"{name} is ProUser!!!");
        }
    }

    //Структура данных в C#
    public struct work
    {
        //переменные структуры
        private int zp;
        private string job;

        //Конструктор структуры, но есть по умолчанию пустой конструктор
        public work(int zp, string job)
        {
            this.zp = zp;
            this.job = job;
        }

        //какие-то фнкции структуры
        public void printJobInfo()
        {
            Console.WriteLine($"Job: {job}, zp: {zp}");
        }
    }
}
