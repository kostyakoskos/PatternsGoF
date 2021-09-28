using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Фасад — это структурный паттерн проектирования, который предоставляет простой интерфейс к сложной системе классов, библиотеке или фреймворку.
// Когда есть много объектов некоторой сторонней библиотеки или фреймворка. Нужно самостоятельно правильно инициализировать эти объекты, что сложно.
// Решение
// Фасад хорошо когда мы исопльзуем большую библиотеку, но нам нужна только часть её возможностей
// Аналогия из жизни: Делаем заказ по телефону. Сотрудник магазина является фасадом, предоставляющим упрощенный доступ ко всем службам и отделам магазина(создание, оплата, доставка заказа).
// У нас есть какие-то классы: CarModel, CarEnjine, ... Есть класс CarFacade в котором есть экзмпляры других классов. И есть метод, создающий машинку, готовую, используя экзмпляры класса.
// Можно исопльзовать не все экземпляры класса.
namespace PatternFasade
{
    class CarModel
    {
        public void SetModel()
        {
            Console.WriteLine(" CarModel - SetModel");
        }
    }
    class CarEngine
    {
        public void SetEngine()
        {
            Console.WriteLine(" CarEngine - SetEngine");
        }
    }
    class CarBody
    {
        public void SetBody()
        {
            Console.WriteLine(" CarBody - SetBody");
        }
    }
    class CarAccessories
    {
        public void SetAccessories()
        {
            Console.WriteLine(" CarAccessories - SetAccessories");
        }
    }
    public class CarFacade
    {
        CarModel model;
        CarEngine engine;
        CarBody body;
        CarAccessories accessories;

        public CarFacade()
        {
            model = new CarModel();
            engine = new CarEngine();
            body = new CarBody();
            accessories = new CarAccessories();
        }

        public void CreateCompleteCar()
        {
            Console.WriteLine("******** Creating a Car **********\n");
            model.SetModel();
            engine.SetEngine();
            body.SetBody();
            accessories.SetAccessories();

            Console.WriteLine("\n******** Car creation complete **********");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarFacade facade = new CarFacade();

            facade.CreateCompleteCar();

            Console.ReadKey();

        }
    }
}
