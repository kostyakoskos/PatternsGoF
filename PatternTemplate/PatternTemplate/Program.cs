using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Шаблонный метод — это поведенческий паттерн проектирования, который определяет скелет алгоритма, перекладывая ответственность за некоторые его шаги на подклассы. Паттерн позволяет подклассам
// переопределять шаги алгоритма, не меняя его общей структуры.
// Аналогия из жизни. На заводе собирают автомобили. На каждом этапе сборки можно что-то добавить, чтобы сделать автомобиль не похожим на другие. 
// Строители строят дом. Для того надо сначала залить фунумент, построить стены, крышу вставить окна. Но можно поставить на фундамент какой-то готовый дом со стенами, окнами и тд. Т.е. это не типовой дом.
namespace PatternTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataAccessor categories = new Categories();
            // В жкземпляр категория передали 5, значит цикл for до 5 будет.
            categories.Run(5);
            DataAccessor products = new Products();
            products.Run(3);
            // Wait for user
            Console.ReadKey();
        }
    }
    // Создали абстрактный класс с абстрактными методами, которые должны быть реализованы в наследниках
    public abstract class DataAccessor
    {
        public abstract void Connect();
        public abstract void Select();
        public abstract void Process(int top);
        public abstract void Disconnect();
        // The 'Template Method' 
        public void Run(int top)
        {
            Connect();
            Select();
            Process(top);
            Disconnect();
        }
    }
    // класс наследет dataAccessor, реализует абсрактные методы по своему. Го суть в том, что он должен эти методы реализовать: как строительство дома: нуен фундамент сначала, потом стены,
    // потом крыша.
    public class Categories : DataAccessor
    {
        private List<string> categories;
        public override void Connect()
        {
            categories = new List<string>();
        }
        public override void Select()
        {
            categories.Add("Red");
            categories.Add("Green");
            categories.Add("Blue");
            categories.Add("Yellow");
            categories.Add("Purple");
            categories.Add("White");
            categories.Add("Black");
        }
        public override void Process(int top)
        {
            Console.WriteLine("Categories ---- ");
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(categories[i]);
            }

            Console.WriteLine();
        }
        public override void Disconnect()
        {
            categories.Clear();
        }
    }
    public class Products : DataAccessor
    {
        private List<string> products;
        public override void Connect()
        {
            products = new List<string>();
        }
        public override void Select()
        {
            products.Add("Car");
            products.Add("Bike");
            products.Add("Boat");
            products.Add("Truck");
            products.Add("Moped");
            products.Add("Rollerskate");
            products.Add("Stroller");
        }
        public override void Process(int top)
        {
            Console.WriteLine("Products ---- ");
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.WriteLine();
        }
        public override void Disconnect()
        {
            products.Clear();
        }
    }
}
