using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    #region *** Балеев Владимир  * Задание № 5***
    /* **Существует алгоритмическая игра “Удвоитель”. В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”, 
     * достичь этого числа за минимальное число шагов. Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1. 
     * Начальное значение удвоителя равно 1.
     * Реализовать класс “Удвоитель”. Класс хранит в себе поле current - текущее значение, finish - число, которого нужно достичь, 
     * конструктор, в котором задается конечное число. 
     * Методы: увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current, которое возвращает текущее значение,
     * свойство Finish,которое возвращает конечное значение.
     * Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек. выбирая из меню на экране, отдает команды удвоителю
     * и старается получить это число за наименьшее число ходов. 
     * Если человек получает число больше положенного, игра прекращается.*/
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Doubler user = new Doubler(2, 3);
            int count;
            int choice;

            Console.WriteLine($"В этой игре Вам необходимо управляя роботом \"Удвоитель\" достичь числа {user.Finish} за минимальное число шагов." +
                $"\nВы начинаете с {user.Current}.\n Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1.");
            Console.WriteLine("Для начала игры нажмите любую кнопку...");
            Console.ReadKey();
            for (count = 0; user.Current < user.Finish; count++)
            {
                bool flag = false;
                do
                {
                    Console.WriteLine($"Ваше число: {user.Current}.\n Загаданое число: {user.Finish}.\nСделано шагов: {count}.");
                    Console.WriteLine($"Меню выбора:\n Нажмите \"1\" - для увеличения числа на один." +
                        $"\n Нажмите \"2\" - для умножения числа на два.\n Нажмите \"0\" - для сброса числа до единицы.");
                    Console.Write("\nВаше действие(введите число из меню.):");

                    if (!Int32.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Нет такой операции.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1: user.IncreaseValue(); break;
                        case 2: user.MultValue(); break;
                        case 0: user.ResetValue(); break;
                        default:
                            Console.WriteLine("Я не знаю такой команды :("); flag = true;
                            break;
                    }
                    Console.WriteLine($"Ваше число: {user.Current}.\n Загаданое число: {user.Finish}.\nСделано шагов: {count}.");
                    Console.WriteLine("Для продолжения нажмите любую кнопку...");
                    Console.ReadKey();
                    Console.Clear();
                }
                while (flag);
            }
            Console.Clear();
            if (user.Current == user.Finish)
            {
                
                Console.WriteLine($"Поздравляю!!!\nВы достигли числа {user.Finish} за {count} шагов.");
            } else
            {
                Console.WriteLine($"Вы проиграли :(\nПревысили число {user.Finish} на {user.Current - user.Finish} за {count} шагов");
            }
        }
    }

    class Doubler
    {
        int current = 1;
        public int Current { get => current; }
        int finish;
        public int Finish { get => finish; }

        /// <summary>
        /// Конструктор, в котором задается конечное число.
        /// </summary>
        /// <param name="min">Генерация от</param>
        /// <param name="max">Генерация до</param>
        public Doubler(int min, int max)
        {
            Random rnd = new Random();
            this.finish = rnd.Next(min, max);
        }

        /// <summary>
        /// увеличить число на 1
        /// </summary>
        public void IncreaseValue()
        {
            current++;
        }

        /// <summary>
        /// увеличить число в два раза
        /// </summary>
        public void MultValue()
        {
            current *= 2;
        }

        /// <summary>
        /// сброс текущего до 1
        /// </summary>
        public void ResetValue()
        {
            current = 1;
        }
    }
}
