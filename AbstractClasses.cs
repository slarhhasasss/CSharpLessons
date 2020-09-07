using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CSharp
{
    class AbstractClasses
    {
        public static void Main()
        {
            Human dima = new Human("Dima", "male", "student", 18);
            dima.sayHello();                //Hello, world!
                                            //It is human!
            
            
            dima.printInfo();               //Race: Human, Name: Dima, Age: 18, Gender: male, prof: student


            Animal<Human> woman = new Animal<Human>("Alina", new Human("Alina", "female", "student", 19));
            woman.returnAnimal().printInfo();    //Race: Human, Name: Alina, Age: 19, Gender: female, prof: student
        }


        //Абстрактный класс, на основе которого нельзя создавать экземпляры, но можно его наследовать
        public abstract class Creature
        {
            protected int age;
            protected string gender;


            //Этот метод можно переопределить в дочерних классах
            public virtual void sayHello()
            {
                Console.WriteLine("Hello, world!");
            }

            public virtual void printInfo()
            {
                Console.WriteLine($"Age: {age}\nGender: {gender}");
            }

            //А это те функции, которые надо реализовать в каждом классе наследнике обязательно!
            //ПРи этом мы не можем определить тело этих функций здесь
            public abstract int getAge();
            public abstract string getGender();
        }


        public class Human : Creature
        {
            private string name;
            private string prof;

            public Human(string name, string gender,  string prof = "unemployed", int age = 0)
            {
                this.name = name;
                this.gender = gender;
                this.prof = prof;
                this.age = age;         //В этом конструкторе можно обращаться непосредвтсвенно к переменным
                //из родительского абстрактного класса и устанавливать их
            }

            //Реализованные абстрактные функции:
            public override int getAge()
            {
                return age;
            }

            public override string getGender()
            {
                return gender;
            }

            //Это переопределенный метод из класса родителя
            public override void sayHello()
            {
                //мы сначала вызываем то, что есть в классе родителе, а потом добавляем свое
                base.sayHello();
                //свой код:
                Console.WriteLine("It is human!");
            }

            //А можно полность переписать виртуальную функцию, без вызова ее родительского тела
            public override void printInfo()
            {
                Console.WriteLine($"Race: Human, Name: {name}, Age: {age}, Gender: {gender}, prof: {prof}");
            }
        }


        //Можно создать шаблонный класс:
        public class Animal<Type>
        {
            Type animal;
            string name;

            public Animal(string name, Type animal)
            {
                this.name = name;
                this.animal = animal;
            }
            public Type returnAnimal()
            {
                return animal;
            }
        } 
    }
}
