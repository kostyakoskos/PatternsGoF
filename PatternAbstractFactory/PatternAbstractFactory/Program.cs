using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Абстрактная фабрика — это порождающий паттерн проектирования, который позволяет создавать семейства связанных объектов, не привязываясь к конкретным классам создаваемых объектов.
// абстрактная фабрика - создать приложение для любой фабрики
namespace PatternAbstractFactory
{
    // это интерфейс общий для всех фабрик. В нем 2 Метода GetBike, GetScooter
    interface VehicleFactory
    {
        Bike GetBike(string Bike);
        Scooter GetScooter(string Scooter);
    }
    // Это класс для конкретной фабрики, которая наследует интерфейс общей фабрики. И возвращает объект который надо
    // Фаьрика производит Bike, Scooter
    class HondaFactory : VehicleFactory
    {
        public Bike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }

        }

        public Scooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
            }

        }
    }
    // Класс 2-й фабрики, тоже реализует интерфейс с 2-мя методами. И тоже возвращает 2 типа объектов
    // это главный класс
    class HeroFactory : VehicleFactory
    {
        public Bike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }

        }

        public Scooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
            }

        }
    }

    interface Bike
    {
        string Name();
    }

    interface Scooter
    {
        string Name();
    }

    class RegularBike : Bike
    {
        public string Name()
        {
            return "Regular Bike- Name";
        }
    }

    class SportsBike : Bike
    {
        public string Name()
        {
            return "Sports Bike- Name";
        }
    }

    class RegularScooter : Scooter
    {
        public string Name()
        {
            return "Regular Scooter- Name";
        }
    }

    class Scooty : Scooter
    {
        public string Name()
        {
            return "Scooty- Name";
        }
    }

    class VehicleClient
    {
        Bike bike;
        Scooter scooter;

        public VehicleClient(VehicleFactory factory, string type)
        {
            bike = factory.GetBike(type);
            scooter = factory.GetScooter(type);
        }

        public string GetBikeName()
        {
            return bike.Name();
        }

        public string GetScooterName()
        {
            return scooter.Name();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory honda = new HondaFactory();
            VehicleClient hondaclient = new VehicleClient(honda, "Regular");

            Console.WriteLine("******* Honda **********");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            hondaclient = new VehicleClient(honda, "Sports");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            VehicleFactory hero = new HeroFactory();
            VehicleClient heroclient = new VehicleClient(hero, "Regular");

            Console.WriteLine("******* Hero **********");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            heroclient = new VehicleClient(hero, "Sports");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            Console.ReadKey();
        }
    }
}
