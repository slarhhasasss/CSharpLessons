using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ConsoleApp1CSharp
{
    class Surrialization
    {

        
        public static void Main()
        {
            Animal cat = new Animal(4, "Tom");
            Animal dog = new Animal(5, "Beta");

            Animal[] animals = { cat, dog };

            string file_name = @"C:\Users\dimik\VisualStudioPojects\repos\ConsoleApp1CSharp\ConsoleApp1CSharp\animals.dat";

            //Аналогично можно использовать XmlSerializer fromatter = new XmlSerializer(typeof(Animal[]));
            //Тогда везде вместо bf пишем formatter, а сам класс Aimal должен иметь конструктор по умолчанию
            //и вообще серриализации будут подвержены только те переменные, которые имеют модификатор доступа
            //Public, но еще Animals.xml, а не animals.dat
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, animals); //Сохраняем целый массив, Создается файл animals.dat
            }

            using (FileStream fs = new FileStream(file_name, FileMode.OpenOrCreate))
            {
                Animal[] newAnimals = (Animal[])bf.Deserialize(fs);  //Извлекаем данные

                foreach (Animal elem in newAnimals) Console.Write($"{elem.name} "); //Tom Beta
            }
        }
    }

    [Serializable]  //Значит, что все переменные класса могут быть сохранены
    public class Animal
    {
        public int age;
        public string name;

        [NonSerialized]  //Эту переменную не надо серриализировать
        public string category;

        public Animal(int age, string name, string category = "lol")
        {
            this.age = age;
            this.name = name;
            this.category = category;
        }
    }
}
