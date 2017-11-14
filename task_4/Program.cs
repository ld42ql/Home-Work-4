using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    #region *** Балеев Владимир  * Задание № 4***
    /* *а) Реализовать класс для работы с двумерным массивом. 
     * Реализовать конструктор, заполняющий массив случайными числами. 
     * Создать методы, которые возвращают сумму всех элементов массива, 
     * сумму всех элементов массива больше заданного, 
     * свойство, возвращающее минимальный элемент массива,
     * свойство, возвращающее максимальный элемент массива, 
     * метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
       **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.*/
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            TaskArray arr = new TaskArray(2, 3, -5, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($" {arr.Array[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма элементов массива: {arr.Sum()}");

            int t = 1;
            Console.WriteLine($"Сумма элементов массива с больше числа {t}: {arr.SumMoreVakue(t)}");

            Console.WriteLine($"Минимальный элемент массива: {arr.MinValue}");

            Console.WriteLine($"Максимальный элемент массива: {arr.MaxValue}");

            Console.WriteLine($"Индекс наибольшего элемент массива: {arr.IndexMaxValue()}");

            Console.ReadKey();
        }
    }

    class TaskArray
    {
        private int[,] array;
        public int[,] Array { get => array; set => array = value; }

        /// <summary>
        /// конструктор, заполняющий массив случайными числами
        /// </summary>
        /// <param name="col">колонки</param>
        /// <param name="row">ряды</param>
        /// <param name="min">от</param>
        /// <param name="max">до</param>
        public TaskArray(int col, int row, int min, int max)
        {
            array = new int[row, col];
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = rnd.Next(min, max);
                }
        }

        /// <summary>
        /// Возврат суммы элементов массива
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int sum = 0;
            foreach (var i in array)
            {
                sum += i;
            };
            return sum;
        }

        /// <summary>
        /// Возврат суммы элементов массива больше заданного
        /// </summary>
        /// <param name="n">Задать размер</param>
        /// <returns></returns>
        public int SumMoreVakue(int n)
        {
            int sum = 0;
            foreach (var i in array)
            {
                if (i > n) { sum += i; }
            };
            return sum;
        }

        /// <summary>
        /// минимальный элемент массива
        /// </summary>
        public int MinValue
        {
            get
            {
                int min = int.MaxValue;
                foreach (var item in array)
                {
                    if (item < min) { min = item; }
                }
                return min;
            }
        }

        /// <summary>
        /// максимальный элемент массива
        /// </summary>
        public int MaxValue
        {
            get
            {
                int min = int.MinValue;
                foreach (var item in array)
                {
                    if (item > min) { min = item; }
                }
                return min;
            }
        }

        /// <summary>
        /// Индекс заданого элемента в массиве
        /// </summary>
        /// <param name="MaxValue"></param>
        /// <returns></returns>
        public string IndexMaxValue()
        {
            int max = MaxValue;
            string index = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] >= max)
                    {
                        max = array[i, j];
                        index = $"{i} and {j}";
                    }
                }
                
            }
            return index;
        }
        
    }

    class operFile
    {
        string[] list;

        /// <summary>
        /// Конструктор для записи массива в файл
        /// </summary>
        /// <param name="list">Массив</param>
        public operFile(int[] list)
        {
            int count = list.Length;
            string[] newList = new string[count];
            for (int i = 0; i < count; i++)
            {
                newList[i] = Convert.ToString(list[i]);
            }
            this.list = newList;
        }

        /// <summary>
        /// Открыть файл array.txt
        /// </summary>
        public string[] OpenFile()
        {
            return File.ReadAllLines(@"array.txt");
        }

        /// <summary>
        /// Запись массива в файл array.txt
        /// </summary>
        public void SaveFile()
        {
            File.WriteAllLines(@"array.txt", list);
        }
    }
}
