using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Одиночка — это порождающий паттерн проектирования, который гарантирует, что у класса есть только один экземпляр, и предоставляет к нему глобальную точку доступа.
// Например строка подключения к ьд. Если мы пропишем подключение к бд в конструкторе, то каждый раз при создании объекта будет срабатывать это подключение.
// А вот если мы этот конструктор сделаем static, то вне зависимости от того, сколько объектов создадим, static конструктор вызовется 1 раз.
namespace PatternSingleton
{
    public class Singleton
    {
        // .NET guarantees thread safety for static initialization
        // Создали статическую переменную.
        private static Singleton instance = null;
        private string Name { get; set; }
        private string IP { get; set; }
        private Singleton()
        {
            //To DO: Remove below line
            Console.WriteLine("Singleton Intance");

            Name = "Server1";
            IP = "192.168.1.23";
        }
        // Lock synchronization object
        private static object syncLock = new object();
        // это метод static. Контролирует жизненный цикл объекта-одиночки
        public static Singleton Instance
        {
            get
            {
                // Support multithreaded applications through
                // 'Double checked locking' pattern which (once
                // the instance exists) avoids locking each
                // time the method is invoked
                lock (syncLock)
                {
                    if (Singleton.instance == null)
                        Singleton.instance = new Singleton();

                    return Singleton.instance;
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("Server Information is : Name={0} & IP={1}", IP, Name);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.Show();
            Singleton.Instance.Show();

            Console.ReadKey();
        }
    }
}
