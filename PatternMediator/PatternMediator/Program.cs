using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Посредник — это поведенческий паттерн проектирования, который позволяет уменьшить связанность множества классов между собой, благодаря перемещению этих связей в один класс-посредник.
// Аналогия из жизни. Пилоты садящихся и улетающих самолетов не связываются друг с другом. Они связываются с диспетчером, который координирует их действия. Диспетчер не нужен пилотам во время всего полета,
// только во время взлета и посадки.
// Так например, у пользователя есть 5 кнопок, которые должны взаимодейстовать между собой. Так, например, чекбокс «у меня есть собака» открывает скрытое поле для ввода имени домашнего любимца, а клик
// по кнопке отправки запускает проверку значений всех полей формы. Если пропишем эту логику в коде элементов упраления, их плохо будет использовать в других местах приложения.
// Паттерн посредник заствляет объекты не напрямую общаться друг с другом, а через отдельный объект-посредник, который знает кому нужно перенаправить запрос.
// Т.е. если есть 3 чекбокс(с галочками) и при установке галочки на другой чекбокс, не надо прописывать к чекбокс_клик взаимодействие с другими. Вместо этого создать отедный класс, который будет изменять
// значения checkbox.checked . Т.е. просто сообщаем классу что пользователь кликнул.

namespace PatternMediator
{
    public abstract class Colleague
    {
        protected IMediator _mediator;

        public Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(IMediator mediator) : base(mediator) { }

        public void Send(string msg)
        {
            Console.WriteLine("A send message:" + msg);
            _mediator.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("A receive message:" + msg);
        }
    }

    public class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(IMediator mediator) : base(mediator) { }

        public void Send(string msg)
        {
            Console.WriteLine("B send message:" + msg);
            _mediator.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("B receive message:" + msg);
        }
    }

    public interface IMediator
    {
        void SendMessage(Colleague caller, string msg);
    }

    public class ConcreteMediator : IMediator
    {
        public ConcreteColleagueA Colleague1 { get; set; }

        public ConcreteColleagueB Colleague2 { get; set; }

        public void SendMessage(Colleague caller, string msg)
        {
            if (caller == Colleague1)
                Colleague2.Receive(msg);
            else
                Colleague1.Receive(msg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
