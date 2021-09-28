using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Тут есть класс, производящий продукты. Сами экзмепляры продуктов не создаем.
// Есть класс скутер и велосипед которые реализуют интерфейс Drive. Каждый класс реализовавает интерфейс по разному.
// Суть в том, что не создаем напрямую эекзмляры класса скутер, велосипед.
// Мы делаем абстрактный класс(не может быть экземпляров c 1 абстрактным методом) VichleFactory у которого есть класс-наследник, имеющйи метод GetVichle.
// Теперь, чтобы расширить, добавить пароход, нужно сделать класс параход, унаследовать интерфейс IFactory и в классе Concrevichlefactory добавить обработку на случай ship

namespace PatternFactory
{
    public interface IFactory
    {
        void Drive(int miles);
    }
    
    public class Scooter : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }
    
    public class Bike : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }
    public class Ship : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Ship : " + miles.ToString() + "km");
        }
    }

    /// The Creator Abstract Class
    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string Vehicle);
    }

     
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                case "Ship":
                    return new Ship();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            IFactory bike = factory.GetVehicle("Bike");
            bike.Drive(20);

            IFactory ship = factory.GetVehicle("Ship");
            ship.Drive(30);

            Console.ReadKey();

        }
    }
}
