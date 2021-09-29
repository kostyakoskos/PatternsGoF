using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Снимок — это поведенческий паттерн проектирования, который позволяет сохранять и восстанавливать прошлые состояния объектов, не раскрывая подробностей их реализации.
// Пусть пишем программу текстового редактора. Есть операция отмены. ДЛя этого, нужно раз в какое-то время сохранять состояние файла. Плохо: создать ещё 1 класс, сохраняющий все public поля исходного класс.
// Но что делать с private полями? Хорошо - сам класс редактор делает копию всех полей. А ему доступны даже private поля.
// НАпример, класс Editor(поля id, text, cursor. методы makeSnapsoh, restore ...) Метод shapshot делает копию только состояние нужных полей. методы, св-ва хранить не надо.
// И хранин ддату кгда он был сделан.
namespace PatternMemberTo
{
    public class Originator
    {
        private string state;

        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        public void SetMemento(Memento memento)
        {
            this.state = memento.GetState();
        }
    }

    public class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }
    }

    public class Caretaker
    {
        public Memento Memento { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Memento m = new Memento("abc");
            Caretaker c = new Caretaker();
            Console.WriteLine(c.Memento.GetState());
            Console.ReadKey();
        }
    }
}
