using System;
using System.Collections.Generic;
// Легковес — это структурный паттерн проектирования, который позволяет вместить бóльшее количество объектов в отведённую оперативную память. Легковес экономит память, разделяя общее состояние объектов
// между собой, вместо хранения одинаковых данных в каждом объекте.
// Например объект частица.Она имеет изменяемы во времени: вектор, скорость, координаты. При этом цвет, sprite у неё бует всегда одинаковый, вне зависимости от времени.
// Решение
// Создаем контект в котором эта частица используется и в контексте прописываем цвет чатицы, вес.
// Создали словарь из которого эта частица берется, и через словарь её используем
// Тут добавляем в словарь значение Rectangle и circle 1 раз. Далее смотрим, если есть в словаре есть Rectangle то просто идем дальше. 
namespace FlyWeight
{
    interface IShape
    {
        void Print();
    }
    class Rectangle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Rectangle");
        }
    }
    class Circle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Circle");
        }
    }
    class ShapeObjectFactory
    {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }

        public IShape GetShape(string ShapeName)
        {
            IShape shape = null;
            if (shapes.ContainsKey(ShapeName))
            {
                shape = shapes[ShapeName];
            }
            else
            {
                switch (ShapeName)
                {
                    case "Rectangle":
                        shape = new Rectangle();
                        shapes.Add("Rectangle", shape);
                        break;
                    case "Circle":
                        shape = new Circle();
                        shapes.Add("Circle", shape);
                        break;
                    default:
                        throw new Exception("Factory cannot create the object specified");
                }
            }
            return shape;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShapeObjectFactory sof = new ShapeObjectFactory();

            IShape shape = sof.GetShape("Rectangle");
            shape.Print();
            shape = sof.GetShape("Rectangle");
            shape.Print();
            shape = sof.GetShape("Rectangle");
            shape.Print();

            shape = sof.GetShape("Circle");
            shape.Print();
            shape = sof.GetShape("Circle");
            shape.Print();
            shape = sof.GetShape("Circle");
            shape.Print();

            int NumObjs = sof.TotalObjectsCreated;
            Console.WriteLine("\nTotal No of Objects created = {0}", NumObjs);
            Console.ReadKey();
        }
    }
}
