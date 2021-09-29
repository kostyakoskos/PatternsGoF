using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Цепочка обязанностей — это поведенческий паттерн проектирования, который позволяет передавать запросы последовательно по цепочке обработчиков. Каждый последующий обработчик решает, может ли он
//обработать запрос сам и стоит ли передавать запрос дальше по цепи.
// Пример из жизни: звоним в мтс: сначала автоответчик предлагает выбрать 0-9 для того чтобы сделать что-то дальше. Затем трубку беретcall центр, если проблема сложная, то переводит в отдел инженеров,
// разработчиков 

namespace PatternChainResponsability
{
    public class LoanEventArgs : EventArgs
    {
        internal Loan Loan { get; set; }
    }
    abstract class Approver
    {
        // Loan event 
        public EventHandler<LoanEventArgs> Loan;

        // Loan event handler
        public abstract void LoanHandler(object sender, LoanEventArgs e);

        // Constructor
        public Approver()
        {
            Loan += LoanHandler;
        }

        public void ProcessRequest(Loan loan)
        {
            OnLoan(new LoanEventArgs { Loan = loan });
        }

        // Invoke the Loan event
        public virtual void OnLoan(LoanEventArgs e)
        {
            if (Loan != null)
            {
                Loan(this, e);
            }
        }

        // Sets or gets the next approver
        public Approver Successor { get; set; }
    }
    class Clerk : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, e.Loan.Number);
            }
            else if (Successor != null)
            {
                Successor.LoanHandler(this, e);
            }
        }
    }

    class AssistantManager : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount < 45000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, e.Loan.Number);
            }
            else if (Successor != null)
            {
                Successor.LoanHandler(this, e);
            }
        }
    }
    class Manager : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                sender.GetType().Name, e.Loan.Number);
            }
            else if (Successor != null)
            {
                Successor.LoanHandler(this, e);
            }
            else
            {
                Console.WriteLine(
                "Request# {0} requires an executive meeting!",
                e.Loan.Number);
            }
        }
    }
    class Loan
    {
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Approver rohit = new Clerk();
            Approver rahul = new AssistantManager();
            Approver manoj = new Manager();

            rohit.Successor = rahul;
            rahul.Successor = manoj;

            // Generate and process loan requests
            var loan = new Loan { Number = 2034, Amount = 24000.00, Purpose = "Laptop Loan" };
            rohit.ProcessRequest(loan);

            loan = new Loan { Number = 2035, Amount = 42000.10, Purpose = "Bike Loan" };
            rohit.ProcessRequest(loan);

            loan = new Loan { Number = 2036, Amount = 156200.00, Purpose = "House Loan" };
            rohit.ProcessRequest(loan);

            // Wait for user
            Console.ReadKey();
        }
    }
}
