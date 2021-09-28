using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Прототип — это порождающий паттерн проектирования, который позволяет копировать объекты, не вдаваясь в подробности их реализации.
// Пусть есть какой-то объект, который надо скопировать. Да, можно создать объект тогоже класса и поочередно скопировать все поля. А что если эти поля private?
// Паттерн Прототип поручает создание копий самим копируемым объектам. Он вводит общий интерфейс для всех объектов, поддерживающих клонирование. Это позволяет копировать объекты, не привязываясь к их
// конкретным классам. Обычно такой интерфейс имеет всего один метод clone.
// Метод создаёт новый объект текущего класса и копирует в него значения всех полей собственного объекта. Так получится скопировать даже приватные поля.
namespace PatternPrototype
{
    public interface IEmployee
    {
        IEmployee Clone();
        string GetDetails();
    }
    public class Developer : IEmployee
    {
        private const int a = 10;
        public int WordsPerMinute { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string PreferredLanguage { get; set; }

        public IEmployee Clone()
        {
            return (IEmployee)MemberwiseClone();
        }
        public string GetDetails()
        {
            return string.Format("{0} - {1} - {2}", Name, Role, PreferredLanguage);
        }
    }
    public class Typist : IEmployee
    {
        public int WordsPerMinute { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public IEmployee Clone()
        {
            return (IEmployee)MemberwiseClone();
        }

        public string GetDetails()
        {
            return string.Format("{0} - {1} - {2}wpm", Name, Role, WordsPerMinute);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new Developer();
            dev.Name = "Rahul";
            dev.Role = "Team Leader";
            dev.PreferredLanguage = "C#";

            // Тут копируем в экзмпляр devCopy всё что есть у объекта dev
            Developer devCopy = (Developer)dev.Clone();
            devCopy.Name = "Arif"; //Not mention Role and PreferredLanguage, it will copy above

            Console.WriteLine(dev.GetDetails());
            Console.WriteLine(devCopy.GetDetails());

            Typist typist = new Typist();
            typist.Name = "Monu";
            typist.Role = "Typist";
            typist.WordsPerMinute = 120;

            Typist typistCopy = (Typist)typist.Clone();
            typistCopy.Name = "Sahil";
            typistCopy.WordsPerMinute = 115;//Not mention Role, it will copy above

            Console.WriteLine(typist.GetDetails());
            Console.WriteLine(typistCopy.GetDetails());

            Console.ReadKey();

        }
    }
}
