using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaytternProxy2
{
    class MainApp
    {
        static void Main()
        {
            IMath p = new MathProxy();

            Console.WriteLine("4 + 2 = " + p.Add(4, 2));
            Console.WriteLine("4 - 2 = " + p.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + p.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + p.Div(4, 2));
            Console.Read();
        }
    }
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }
    class Math : IMath
    {
        public Math()
        {
            Console.WriteLine("Create object Math. Wait...");
            Thread.Sleep(1000);
        }

        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

   
    class MathProxy : IMath
    {
        Math math;

        public MathProxy()
        {
            math = null;
        }
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mul(double x, double y)
        {
            if (math == null)
                math = new Math();
            return math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            if (math == null)
                math = new Math();
            return math.Div(x, y);
        }
    }
}
