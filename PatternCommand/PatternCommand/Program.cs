using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Команда — это поведенческий паттерн проектирования, который превращает запросы в объекты, позволяя передавать их как аргументы при вызове методов, ставить запросы в очередь, логировать их,
// а также поддерживать отмену операций.
// Пример из жизни. Идем в ресторан, там официант записывает наш заказ. Далее официант идет на кухню, вырывает лист из блокнота и отдает его повару. Повар берет лист и готовит заказ. При
// этом повар не знает кто конкретно заказал а вы, "отправитель" не знаете кто конкретно будет готовить
// паттерн позволяет преобразовать запрос в отдельный объект-команду. Такая инкапсуляция позволяет передавать другим функциям в качестве параметра команду как объект(например официант передает лист с заказом). 
// storeAndExecute ф-ция как официант. Принимает объект интерфейса Icomand.
namespace PatternCommand
{
    public interface ICommand
    {
        void Execute();
    }
    public class Switch
    {
        // создали List интерфейсов ICommand. В этом дисте команды ON/OFF
        private List<ICommand> _commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command)
        {
            _commands.Add(command);
        }
    }
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is off");
        }
    }
    public class FlipUpCommand : ICommand
    {
        private Light _light;

        public FlipUpCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }
    public class FlipDownCommand : ICommand
    {
        private Light _light;

        public FlipDownCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Commands (ON/OFF) : ");
            string cmd = Console.ReadLine();

            Light lamp = new Light();
            FlipUpCommand switchUp = new FlipUpCommand(lamp);
            FlipDownCommand switchDown = new FlipDownCommand(lamp);

            Switch s = new Switch();

            if (cmd == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (cmd == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
            }

            Console.ReadKey();
        }
    }
}
