using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Стратегия — это поведенческий паттерн проектирования, который определяет семейство схожих алгоритмов и помещает каждый из них в собственный класс, после чего алгоритмы можно взаимозаменять
// прямо во время исполнения программы.
// Аналогия из жизни. Надо добравться до жд вокзала от дома. Можно этот путь преодолеть на велосипеде, атобусе, метро, такси. В зависимости от количества времени до поезда, денег и тд мы веберем тот или
// иной подход.
// проблема. Есть приложение навигатор. В 1-й версии он может прокладывать только автомобильные маршруты. Во 2-й ещё пешеходные. В 3-й для ОТ. С каждым новым алгоритом код основного класса увеличивается
// в 2 раза.
// Решение. Паттерн Стратегия предлагает определить семейство схожих алгоритмов, которые часто изменяются или расширяются, и вынести их в собственные классы, называемые стратегиями.
// В данном примере каждая тратегия сортирует по разному.
namespace PatternStrategy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList();
            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");
            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();
            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();
            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
            // Wait for user
            Console.ReadKey();
        }
    }
    // базовый абстрактный класс
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();  // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort();  not-implemented
            var linq = list.OrderByDescending(u => u.Length);
            list = linq.ToList();
            Console.WriteLine("ShellSorted list ");
        }
    }
    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            var linq = list.OrderBy(u => u.Length);
            linq = list.OrderByDescending(u => u.Length);
            list = linq.ToList();
            Console.WriteLine("MergeSorted list ");
        }
    }
    public class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortstrategy;
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }
        public void Add(string name)
        {
            list.Add(name);
        }
        public void Sort()
        {
            sortstrategy.Sort(list);
            // Iterate over list and display results
            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}
