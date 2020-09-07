using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CSharp
{
    class ProgramMain
    {
        public static void Main()
        {
            Car porshe = new Car(200, 200000, "porshe");
            Vehicle bycicle = new Vehicle(50, 7000);
            porshe.changeSpeed(150);
            porshe.printStatus();  /*out:
                                    * Top speed: 200
                                    * Cost: 200000
                                    * Current speed: 150
                                    * Is riding: True
                                    * Name: porshe 
                                    */

            Console.WriteLine();

            porshe.changeSpeed(-100);
            porshe.printStatus();   /* out:
                                     * Top speed: 200
                                     * Cost: 200000
                                     * Current speed: 0
                                     * Is riding: False
                                     * Name: porshe
                                     */

            Console.WriteLine();

            porshe.printName();    //out: Name: posrshe  - этот метод только для класса Car.

            Console.WriteLine();

            bycicle.printStatus();  /*out:
                                     * Top speed: 50
                                     * Cost: 7000
                                     * Current speed: 0
                                     * Is riding: False
                                     * Без имени, так как это не машина!!! Саой метод printStatus()!!!
                                     */
        }
    }



    class Vehicle
    {
        protected int topSpeed;
        protected int cost;
        protected bool isRiding = false;
        protected int curSpeed = 0;
        public int CurSpeed
        {
            get
            {
                return curSpeed;
            }
            private set
            {
                if (value >= 0 && value <= topSpeed) curSpeed = value;
                else if (value < 0) curSpeed = 0;
                else curSpeed = topSpeed;
                isRiding = curSpeed != 0 ? true : false;
            }
        }


        public Vehicle(int _topSpeed, int _cost)
        {
            topSpeed = _topSpeed;
            cost = _cost;
        }

        public void changeSpeed(int _speed)
        {
            CurSpeed = _speed;
        }

        public void printStatus()
        {
            Console.WriteLine($"Top speed: {topSpeed}\nCost: {cost}\n" +
                $"Current speed: {CurSpeed}\nIs riding: {isRiding}");
        }

    }



    class Car : Vehicle
    {
        string name;
        public Car(int _topSpeed, int _cost, string _name) : base(_topSpeed, _cost)
        {
            name = _name;
        }

        public void printName()
        {
            Console.WriteLine($"Name: {name}");
        }

        public new void printStatus()
        {
            //Выводим то же самое, что и в классе Vehicle, но в конце добавляем еще имя 
            Console.WriteLine($"Top speed: {topSpeed}\nCost: {cost}\n" +
                $"Current speed: {CurSpeed}\nIs riding: {isRiding}\nName: {name}");
        }
    }







}
