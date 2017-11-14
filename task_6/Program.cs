using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    #region *** Балеев Владимир  * Задание № 6***
    /* ***Написать игру “Верю. Не верю”. В файле хранятся некоторые данные и правда это или нет. Например: “Шариковую ручку изобрели в древнем Египте”, “Да”.
     * Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задает их игроку.
     * Игрок пытается ответить правда или нет, то что ему загадали и набирает баллы. Список вопросов ищите во вложении или можно воспользоваться Интернетом.*/
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Secret game = new Secret();
            game.OpenFile();
            int point = 0;

            for (int i = 1; i < 6; i++)
            {
                int number = game.RandomValue();
                Console.WriteLine($"{i} - вопрос: {game.Question[number, 0]}");
                Console.WriteLine($"Напишете ответ: Да или Нет");
                string answer = Console.ReadLine();
                if (answer == game.Question[number, 1])
                {
                    Console.WriteLine($"Вы ответили верно!");
                    point++;
                }
                else
                {
                    Console.WriteLine($"Не верный ответ. Правильный ответ: {game.Question[number, 2]}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine($"Правильных ответов: {point}");
            Console.ReadKey();
        }
    }

    class Secret
    {
        public string[,] Question = new string[20, 3];
        

        /// <summary>
        /// Загрузить двухмерный массив с логином и паролем
        /// </summary>
        public void OpenFile()
        {
            try
            {
                StreamReader sr = File.OpenText(@"Victorina.txt");
                for (int i = 0; i < 20; i++)
                {
                    string line = sr.ReadLine();
                    string[] fields = line.Split('=');
                    for (int j = 0; j < 3; j++)
                    {
                        Question[i, j] = fields[j];
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public int RandomValue()
        {
            Random random = new Random();
            return random.Next(0, 19);
        }
    }
}
