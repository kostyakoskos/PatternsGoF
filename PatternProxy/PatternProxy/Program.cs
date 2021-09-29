using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Заместитель — это структурный паттерн проектирования, который позволяет подставлять вместо реальных объектов специальные объекты-заменители. Эти объекты перехватывают вызовы к оригинальному
// объекту, позволяя сделать что-то до или после передачи вызова оригиналу.
// Платёжная карточка — это заместитель пачки наличных. И карточка, и наличные имеют общий интерфейс — ими можно оплачивать товары. Для покупателя польза в том, что не надо таскать с собой тонны
// наличных, а владелец магазина рад, что ему не нужно делать дорогостоящую инкассацию наличности в банк — деньги поступают к нему на счёт напрямую.
// Создали ещё 1 прокси-класс с таким же функционалом как у RealClient. Теперь клиент работает с нашим классом прокси, а класс прокси вызывает методы из RealClient.
// Нужно это для того чтобы создавать объект класса, который наследует базовый, при этом имеет ещё какую-то функциональность и контроль доступа.
namespace PatternProxy
{
    public interface IClient
    {
        string GetData();
    }
    public class RealClient : IClient
    {
        string Data;
        public RealClient()
        {
            Console.WriteLine("Real Client: Initialized");
            Data = "Dot Net Tricks";
        }

        public string GetData()
        {
            return Data;
        }
    }

    public class ProxyClient : IClient
    {
        RealClient client = new RealClient();
        public ProxyClient()
        {
            Console.WriteLine("ProxyClient: Initialized");
        }

        public string GetData()
        {
            return client.GetData();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProxyClient proxy = new ProxyClient();
            Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());

            Console.ReadKey();
        }
    }
}
