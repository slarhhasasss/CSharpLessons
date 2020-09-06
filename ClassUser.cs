using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CSharp
{
    //наш подопытный класс
    class ClassUser
    {
        //Статистические переменные - те, которые принадлежат классу в целом, а не конкретному экземпляру
        static int amountOfUsers = 0;

        //Обычные переменные, которые принадлежат конкретному экземпляру
        public string name { get; private set; }
        string gender;
        public int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0) age = 0;
                else age = value;
            }
        }


        //Конструктор класса
        public ClassUser(string _name, int age = 0, string _gender = "Not important")
        {
            amountOfUsers++;
            this.name = _name;
            Age = age;
            this.gender = _gender;
        }

        //Перегружанный конструктор
        public ClassUser()
        {
            this.name = "None";
            this.age = -1;
            this.gender = "None";
            amountOfUsers++;
        }

        //статистическая функция - можно обращаться к самому классу, а не к экземпляру
        public static void printNumberOfUsers()
        {
            Console.WriteLine(amountOfUsers);
        }

        //Доступна только при обращении от экзмепляра класса.
        public void printUserInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {Age}, Gender: {gender}.");
        }
    }






    //наш тестовый класс для запуска консоли
    class Programm
    {
        public static void Main()
        {
            ClassUser user1 = new ClassUser("Dima", 18, "Male");
            ClassUser user2 = new ClassUser("Alina", -43);
            ClassUser user3 = new ClassUser();
            user1.printUserInfo();  //Name: Dima, Age: 18, Gender: Male.
            user2.printUserInfo();  //Name: Alina, Age: 0, Gender: Not important.
            user3.printUserInfo();  //Name: None, Age: -1, Gender: None.

            ClassUser.printNumberOfUsers();  //3

        }
    }
}
