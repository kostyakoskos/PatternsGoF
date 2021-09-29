using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// interpeter - специфический, используется при разработке софта для программистов.
// этот шаблон может интерпертировать и записывать выражения языка
namespace PatternInterpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Context context = new Context();

            List<AbstractExpression> list = new List<AbstractExpression>();

            // В лист добавляем новые экземпляры классов
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());
            // Интерпретируем экземпляры классов. Для каждого класса свой интрпретатор, т.к. метод интерпретировать переопределили
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
            Console.ReadKey();
        }
    }
    // Класс Context- задает какой-то контекст для интепретирования. 
    public class Context
    {
    }
    // абстрактный класс
    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
    // от AbstractExpression наследуется новый класс с 1 переопределяющим мтеодом, который принимает Context и выводит что-то на коннсоль
    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }
    // Класс, унаследованный от AbstractExpression, переопредеялет его абстрактный метод
    public class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}
