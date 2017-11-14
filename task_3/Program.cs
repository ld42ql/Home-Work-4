using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace task_3
{
    #region *** Балеев Владимир  * Задание № 3***
    /*  Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.*/
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            task.Authentication();

            Console.ReadKey();
        }
    }

    static class task
    {
       
        static string[,] baseData = new string[2, 2];

        /// <summary>
        /// Проверка логина и пароля
        /// </summary>
        /// <returns>Верный пароль или нет</returns>
        static public bool Authentication()
        {

            string login = "";
            string password = "";

            bool access = false;
            int i = 3;
            OpenFile();
            do
            {
                Console.Write(String.Format("Введите логин: "));
                login = Console.ReadLine().ToLower();

                Console.Write(String.Format("Введите пароль: "));
                password = Console.ReadLine();

                for (int j = 0; j < baseData.GetLength(0); j++)
                {

                    if (login == baseData[j, 0] && password == baseData[j, 1]) { access = true; }

                }

                i--;
                Console.Clear();
                if (access) { Console.WriteLine(String.Format($"Добро пожаловать в систему, пользователь: {login}")); i = 0; }
                else { Console.WriteLine(String.Format($"Доступ запрещен!\nОсталось {i} попыток.\n")); }
            } while (i != 0);

            return access;
        }

        /// <summary>
        /// Загрузить двухмерный массив с логином и паролем
        /// </summary>
        static void OpenFile()
        {
            try
            {
                StreamReader sr = File.OpenText(@"data.txt");
                for (int i = 0; i < 2; i++)
                {
                    string line = sr.ReadLine();
                    string[] fields = line.Split(' ');
                    baseData[i, 0] = fields[0];
                    baseData[i, 1] = fields[1];
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}