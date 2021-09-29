using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Наблюдатель — это поведенческий паттерн проектирования, который создаёт механизм подписки, позволяющий одним объектам следить и реагировать на события, происходящие в других объектах.
// Аналог из жизни. Вы подписались на газету. Ездить узнавать в магазин, узнавать вышел ли новый номер газеты не надо. Вместо этого издательство ведет список подписчиков и знает кому какой
// журнал высылать. Вы можете в любой момент отказаться от подписки и журнал перестанет к вам приходить.
// проблема. Есть покупатель который хочет купить ноутбук определнной марки. Он может ходить каждый день в магазин и узнавать не появился ли этот ноутбук. Магазин может разослать спам что такой ноутбук
// появился всем, но не всем это будет интересно.
// Создатель предоставляет общий интерфейс для подписки. Плписчики сами подписываются на то или иное событие.
namespace PatterObserver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create IBM stock and attach investors
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Price = 130.00;
            ibm.Attach(new Investor("Berkshire"));
            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
            // Wait for user
            Console.ReadKey();
        }
    }
    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();
        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }
        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }
        public string Symbol
        {
            get { return symbol; }
        }
    }
    public class IBM : Stock
    {
        public IBM(string symbol, double price) : base(symbol, price)
        {
        }
    }
    public interface IInvestor
    {
        void Update(Stock stock);
    }
    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;
        public Investor(string name)
        {
            this.name = name;
        }
        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", name, stock.Symbol, stock.Price);
        }
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
