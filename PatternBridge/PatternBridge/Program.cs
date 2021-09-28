using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Мост — это структурный паттерн проектирования, который разделяет один или несколько классов на две отдельные иерархии — абстракцию и реализацию, позволяя изменять их независимо друг от друга.
// Пусть есть класс фигура. В ней есть квадрат, треугольник, круг. Также есть цвет красный синий. Цвет нужно вынести в отдельный класс  и работать в класе фигура только с объектом цвет.
// Мост позволяет вынести разные типы в отдельную иерархию, не связано друг с другом. Например класс завод vw. Его могул унаследовать skoda, audi, volkswagen. Тип трансмисии - отдельная иерархия. Цвет - отдельная
// иерархия
namespace PatternBridge
{
    public abstract class Vw
    {
        protected readonly int id;
    }
    public class Audi : Vw
    {
        public string ModelAudi1 { get; set; }
        public string ModelAudi2 { get; set; }
    }
    public class Skoda : Vw
    {
        public string ModelSkoda1 { get; set; }
        public string ModelSkoda2 { get; set; }
    }
    abstract class Color
    {
        public string Yellow { get; set; }
        public string Green { get; set; }
    }
    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public abstract void Send();
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }
    public class UserMessage : Message
    {
        public string UserComments { get; set; }

        public override void Send()
        {
            string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
            MessageSender.SendMessage(Subject, fullBody);
        }
    }
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
        }
    }
    public class MSMQSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("MSMQ\n{0}\n{1}\n", subject, body);
        }
    }
    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IMessageSender email = new EmailSender();
            IMessageSender queue = new MSMQSender();
            IMessageSender web = new WebServiceSender();

            Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "Hi, This is a Test Message";

            message.MessageSender = email;
            message.Send();

            message.MessageSender = queue;
            message.Send();

            message.MessageSender = web;
            message.Send();

            UserMessage usermsg = new UserMessage();
            usermsg.Subject = "Test Message";
            usermsg.Body = "Hi, This is a Test Message";
            usermsg.UserComments = "I hope you are well";

            usermsg.MessageSender = email;
            usermsg.Send();

            Console.ReadKey();
        }
    }
}
