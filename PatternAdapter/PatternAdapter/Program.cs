using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Адаптер — это структурный паттерн проектирования, который позволяет объектам с несовместимыми интерфейсами работать вместе.
// В разных странах разные разетки. Чтобы зарядить телефон нужен адаптер.
// Пусть есть приложение которое скачивает и обрабатывает данные из xml. нам надо сделать так, чтобы оно работало и с json. Для этого вешаем адаптер на json и работаем так же. Сами json не переписываем

namespace PatternAdapter
{
    public class ThirdPartyBillingSystem
    {
        private ITarget employeeSource;

        public ThirdPartyBillingSystem(ITarget employeeSource)
        {
            this.employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            List<string> employee = employeeSource.GetEmployeeList();
            //To DO: Implement you business logic

            Console.WriteLine("######### Employee List ##########");
            foreach (var item in employee)
            {
                Console.Write(item);
            }

        }
    }
    public interface ITarget
    {
        List<string> GetEmployeeList();
    }
    public class HRSystem
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new string[] { "100", "Deepak", "Team Leader" };
            employees[1] = new string[] { "101", "Rohit", "Developer" };
            employees[2] = new string[] { "102", "Gautam", "Developer" };
            employees[3] = new string[] { "103", "Dev", "Tester" };

            return employees;
        }
    }
    public class EmployeeAdapter : HRSystem, ITarget
    {
        public List<string> GetEmployeeList()
        {
            List<string> employeeList = new List<string>();
            string[][] employees = GetEmployees();
            foreach (string[] employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(",");
                employeeList.Add(employee[1]);
                employeeList.Add(",");
                employeeList.Add(employee[2]);
                employeeList.Add("\n");
            }
            return employeeList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITarget Itarget = new EmployeeAdapter();
            ThirdPartyBillingSystem client = new ThirdPartyBillingSystem(Itarget);
            client.ShowEmployeeList();

            Console.ReadKey();

        }
    }
}
