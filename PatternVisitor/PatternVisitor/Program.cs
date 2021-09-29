using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Посетитель — это поведенческий паттерн проектирования, который позволяет добавлять в программу новые операции, не изменяя классы объектов, над которыми эти операции могут выполняться.
// Аналогия из жизни. Страховой агент прихолит на завод, банк, в дом с разными предложениями. Для завода он предлагает страховку от пожара и наводнения. Для банка он предлагает страховку от грабежа.
// Для дома он предлагает медицинскую страховку для всей семьи
// Проблема. Есть граф, в котором известны длинны дуг. Каждый узел представляет отдельный класс. Чтобы поместить этот граф в XML надо в каждом узле прописать метод toXML. Это плохо.
// Хорошо. Новое поведение размещаем в отдельном классе вместо того чтобы добавлять метод toXML в каждом из классов.
namespace PatternVisitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup employee collection
            Employees employee = new Employees();
            employee.Attach(new Clerk());
            employee.Attach(new Director());
            employee.Attach(new President());
            // Employees are 'visited'
            employee.Accept(new IncomeVisitor());
            employee.Accept(new VacationVisitor());
            // Wait for user
            Console.ReadKey();
        }
    }
    public interface IVisitor
    {
        void Visit(Element element);
    }
    public class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;
            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}",
                employee.GetType().Name, employee.Name,
                employee.Income);
        }
    }
    public class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;
            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                employee.GetType().Name, employee.Name,
                employee.VacationDays);
        }
    }
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
    public class Employee : Element
    {
        private string name;
        private double income;
        private int vacationDays;
        // Constructor
        public Employee(string name, double income,
            int vacationDays)
        {
            this.name = name;
            this.income = income;
            this.vacationDays = vacationDays;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Income
        {
            get { return income; }
            set { income = value; }
        }
        public int VacationDays
        {
            get { return vacationDays; }
            set { vacationDays = value; }
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Employees
    {
        private List<Employee> employees = new List<Employee>();
        public void Attach(Employee employee)
        {
            employees.Add(employee);
        }
        public void Detach(Employee employee)
        {
            employees.Remove(employee);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (Employee employee in employees)
            {
                employee.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
    // Three employee types
    public class Clerk : Employee
    {
        // Constructor
        public Clerk()
            : base("Kevin", 25000.0, 14)
        {
        }
    }
    public class Director : Employee
    {
        // Constructor
        public Director()
            : base("Elly", 35000.0, 16)
        {
        }
    }
    public class President : Employee
    {
        // Constructor
        public President()
            : base("Eric", 45000.0, 21)
        {
        }
    }
}
