using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Строитель — это порождающий паттерн проектирования, который позволяет создавать сложные объекты пошагово.
// Строитель даёт возможность использовать один и тот же код строительства для получения разных представлений объектов.
// Допустим нам надо создать дом. Класс дом должен иметь сколько стен, оккон, какая крыша, какой бассейн и тд. Если это сделать передать это через конструктор, то будет не очень. Т.к. не все дома имеют
// бассейн и тд. 
// Паттерн предлагает разбить строительство дома на отельные части, которые выполняются только если они нужны. Т.е. в доме где нет бассейна, бассейн не будет создаваться, в отличие от того, если бы мы передавли через конструктор это все
// Дом можно создать из кирпича и дерева. Для этого нудны 2 класса строителей. При вызове шагов строительства получим разные результаты
namespace PatternBuilder
{
    public interface IVehicleBuilder
    {
        void SetModel();
        void SetEngine();
        void SetTransmission();
        void SetBody();
        void SetAccessories();

        Vehicle GetVehicle();
    }

    public class HeroBuilder : IVehicleBuilder
    {
        Vehicle objVehicle = new Vehicle();
        public void SetModel()
        {
            objVehicle.Model = "Hero";
        }

        public void SetEngine()
        {
            objVehicle.Engine = "4 Stroke";
        }

        public void SetTransmission()
        {
            objVehicle.Transmission = "120 km/hr";
        }

        public void SetBody()
        {
            objVehicle.Body = "Plastic";
        }

        public void SetAccessories()
        {
            objVehicle.Accessories.Add("Seat Cover");
            objVehicle.Accessories.Add("Rear Mirror");
        }

        public Vehicle GetVehicle()
        {
            return objVehicle;
        }
    }

    public class HondaBuilder : IVehicleBuilder
    {
        Vehicle objVehicle = new Vehicle();
        public void SetModel()
        {
            objVehicle.Model = "Honda";
        }

        public void SetEngine()
        {
            objVehicle.Engine = "4 Stroke";
        }

        public void SetTransmission()
        {
            objVehicle.Transmission = "125 Km/hr";
        }

        public void SetBody()
        {
            objVehicle.Body = "Plastic";
        }

        public void SetAccessories()
        {
            objVehicle.Accessories.Add("Seat Cover");
            objVehicle.Accessories.Add("Rear Mirror");
            objVehicle.Accessories.Add("Helmet");
        }

        public Vehicle GetVehicle()
        {
            return objVehicle;
        }
    }

    public class Vehicle
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Body { get; set; }
        public List<string> Accessories { get; set; }

        public Vehicle()
        {
            Accessories = new List<string>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Engine: {0}", Engine);
            Console.WriteLine("Body: {0}", Body);
            Console.WriteLine("Transmission: {0}", Transmission);
            Console.WriteLine("Accessories:");
            foreach (var accessory in Accessories)
            {
                Console.WriteLine("\t{0}", accessory);
            }
        }
    }

    public class VehicleCreator
    {
        private readonly IVehicleBuilder objBuilder;

        public VehicleCreator(IVehicleBuilder builder)
        {
            objBuilder = builder;
        }

        public void CreateVehicle()
        {
            objBuilder.SetModel();
            objBuilder.SetEngine();
            objBuilder.SetBody();
            objBuilder.SetTransmission();
            objBuilder.SetAccessories();
        }

        public Vehicle GetVehicle()
        {
            return objBuilder.GetVehicle();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleCreator = new VehicleCreator(new HeroBuilder());
            vehicleCreator.CreateVehicle();
            var vehicle = vehicleCreator.GetVehicle();
            vehicle.ShowInfo();

            Console.WriteLine("---------------------------------------------");

            vehicleCreator = new VehicleCreator(new HondaBuilder());
            vehicleCreator.CreateVehicle();
            vehicle = vehicleCreator.GetVehicle();
            vehicle.ShowInfo();

            Console.ReadKey();
        }
    }
}
