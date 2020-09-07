using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CSharp
{
    class Interface
    {
        public static void Main()
        {
            User dima = new User("Dima", 18);

            dima.printInfo();          //Age: 18, Name: Dima

            dima.type = TypeOfUsers.ProUser;
            Console.WriteLine(dima.type);   //ProUser
        }


        public interface IUser
        {
            int age { get; set; }
            string name { get; set; }

            void printInfo();
            void setAge(int age);
            int getAge();
        }

        //В отличае от классов, можно наслеовать больше, чем один интерфейс
        public class User : IUser
        {
            //Переменная для перечисления:
            public TypeOfUsers type { get; set; }

            public User(string name, int age)
            {
                this.age = age;
                this.name = name;
            }


            public int age { get ; set; }
            public string name { get; set; }

            public int getAge()
            {
                return age;
            }

            public void printInfo()
            {
                Console.WriteLine($"Age: {age}, Name: {name}");
            }

            public void setAge(int age)
            {
                this.age = age;
            }
        }


        //Перечисления:
        public enum TypeOfUsers
        {
            Admin, UsualUser, ProUser, Donator
        }
    }
}
