using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Декоратор — это структурный паттерн проектирования, который позволяет динамически добавлять объектам новую функциональность, оборачивая их в полезные «обёртки».
// декоратор заменяет наследование на агрегацию-декомпозиции. Это когда 1 объект содержит ссылку на другой и делегирует ему работу, вместо того, чтобы наследовать его поведение.
// Аналогия из жизни. Есть класс человек. После того, как он одел свитер, он остался человеком, при этом получил защиту от холода.
namespace PatternDecorator
{
    public interface Vehicle
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }
    public class HondaCity : Vehicle
    {
        public string Make
        {
            get { return "HondaCity"; }
        }

        public string Model
        {
            get { return "CNG"; }
        }

        public double Price
        {
            get { return 1000000; }
        }
    }
    public abstract class VehicleDecorator : Vehicle
    {
        private Vehicle _vehicle;

        public VehicleDecorator(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public string Make
        {
            get { return _vehicle.Make; }
        }

        public string Model
        {
            get { return _vehicle.Model; }
        }

        public double Price
        {
            get { return _vehicle.Price; }
        }

    }
    public class SpecialOffer : VehicleDecorator
    {
        public SpecialOffer(Vehicle vehicle) : base(vehicle) { }

        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }

        public double Price
        {
            get
            {
                double price = base.Price;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price * percentage) / 100, 2);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Basic vehicle
            HondaCity car = new HondaCity();

            Console.WriteLine("Honda City base price are : {0}", car.Price);

            // Special offer
            SpecialOffer offer = new SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";

            Console.WriteLine("{1} @ Diwali Special Offer and price are : {0} ", offer.Price, offer.Offer);

            Console.ReadKey();

        }
    }
}
