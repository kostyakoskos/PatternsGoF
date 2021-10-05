using System;
using System.Collections.Generic;
// в программе при добавлении чего-то нового в list, придется дописывать ещё 1 case. Так плохо. 
// Как надо сделать? Сделать базовый абстрактный класс с виртуальным методом. А в классах наследниках этот метод переопределить. И у каждого экземплра вызывать этот метод.
namespace OpenClosed
{
    public  abstract class CarPrice
    {
        public virtual void getPrice() { }
    }

    public class Tesla : CarPrice
    {
        public override void getPrice()
        {
            Console.WriteLine("This is Tesla");
        }
    }

    public class Audi : CarPrice
    {
        public override void getPrice()
        {
            Console.WriteLine("This is Audi");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // так не правильно делать, тяжело расширять
            //List<string> list = new List<string>();
            //list.Add("Vw");
            //list.Add("Audi");
            //list.Add("BMW");
            //foreach (var c in list)
            //{
            //    switch (c)
            //    {
            //        case "Vw":
            //            Console.WriteLine("Vw");
            //            break;
            //        case "Audi":
            //            Console.WriteLine("This is Audi");
            //            break;
            //    }
            //}
            List<CarPrice> listCarPrice = new List<CarPrice>();
            Audi a = new Audi();
            a.getPrice();

            Tesla t = new Tesla();
            listCarPrice.Add(a);
            listCarPrice.Add(t);
            foreach (var temp in listCarPrice)
            {
                temp.getPrice();
            }
        }
    }

    class Auto
    {

    }
}
