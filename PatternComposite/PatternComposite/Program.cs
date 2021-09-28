using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Компоновщик — это структурный паттерн проектирования, который позволяет сгруппировать множество объектов в древовидную структуру, а затем работать с ней так, как будто это единичный объект.
// Пусть есть класс продукт и коробка. В коробке может лежать продукт или коробка поменьше. В коробке поменьше тоже может лежать продукт и т.д. Нужно расчитать стоимость всего заказа: продукты,коробки
// Если решать прямо - надо посмотреть в каждую коробку, узнать стоимость её продукта и проссумировать. уровень вложенности неизвестен, простой икл не сработает.
// Компоновщик предлагае рассматривать продукт и коробку через 1 интерфейс с общим методом получения стоимости.
// В жтом подходе создаем дерево, проходим каждому узлу дерева, прибавляя стоимость. т.е. делаем обычный обход дерева.

namespace PatternComposite
{
    public interface IEmployed
    {
        int EmpID { get; set; }
        string Name { get; set; }
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>
    public class Employee : IEmployed, IEnumerable<IEmployed>
    {
        private List<IEmployed> _subordinates = new List<IEmployed>();

        public int EmpID { get; set; }
        public string Name { get; set; }

        public void AddSubordinate(IEmployed subordinate)
        {
            _subordinates.Add(subordinate);
        }

        public void RemoveSubordinate(IEmployed subordinate)
        {
            _subordinates.Remove(subordinate);
        }

        public IEmployed GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IEmployed> GetEnumerator()
        {
            foreach (IEmployed subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    public class Contractor : IEmployed
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee Rahul = new Employee { EmpID = 1, Name = "Rahul" };

            Employee Amit = new Employee { EmpID = 2, Name = "Amit" };
            Employee Mohan = new Employee { EmpID = 3, Name = "Mohan" };

            Rahul.AddSubordinate(Amit);
            Rahul.AddSubordinate(Mohan);

            Employee Rita = new Employee { EmpID = 4, Name = "Rita" };
            Employee Hari = new Employee { EmpID = 5, Name = "Hari" };

            Amit.AddSubordinate(Rita);
            Amit.AddSubordinate(Hari);

            Employee Kamal = new Employee { EmpID = 6, Name = "Kamal" };
            Employee Raj = new Employee { EmpID = 7, Name = "Raj" };

            Contractor Sam = new Contractor { EmpID = 8, Name = "Sam" };
            Contractor tim = new Contractor { EmpID = 9, Name = "Tim" };

            Mohan.AddSubordinate(Kamal);
            Mohan.AddSubordinate(Raj);
            Mohan.AddSubordinate(Sam);
            Mohan.AddSubordinate(tim);

            Console.WriteLine("EmpID={0}, Name={1}", Rahul.EmpID, Rahul.Name);

            foreach (Employee manager in Rahul)
            {
                Console.WriteLine("\n EmpID={0}, Name={1}", manager.EmpID, manager.Name);

                foreach (var employee in manager)
                {
                    Console.WriteLine(" \t EmpID={0}, Name={1}", employee.EmpID, employee.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
