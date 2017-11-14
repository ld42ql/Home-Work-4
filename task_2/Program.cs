using System;
using System.IO;
using System.Linq;


namespace task_2
{
    #region *** Балеев Владимир  * Задание № 2***
    /*  а) Дописать класс для работы с одномерным массивом. 
     *  Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
     *  Создать свойство Sum, которые возвращают сумму элементов массива, 
     *  метод Inverse, меняющий знаки у всех элементов массива,
     *  Метод Multi, умножающий каждый элемент массива на определенное число, 
     *  свойство MaxCount, возвращающее количество максимальных элементов.
     *  В Main продемонстрировать работу класса.
     *  б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.  */
    #endregion
    class Program
    {
        static void Main(string[] args)
        {

            task arr_1 = new task(5, 1, 2);
            
            foreach (var item in arr_1.Array)
            {
                Console.WriteLine(String.Format($"{item}"));
            }

            Console.WriteLine(String.Format($"Сумма: {arr_1.Sum}"));

            Console.WriteLine();

            arr_1.Inverse();

            foreach (var item in arr_1.Array)
            {
                Console.WriteLine(String.Format($"{item}"));
            }

            Console.WriteLine();

            task arr_2 = new task(6, 4, 2);

            foreach (var item in arr_2.Array)
            {
                Console.WriteLine(String.Format($"{item}"));
            }

            Console.WriteLine();

            arr_2.Multi(3);

            foreach (var item in arr_2.Array)
            {
                Console.WriteLine(String.Format($"{item}"));
            }

            Console.WriteLine();

            task arr_3 = new task();

            arr_3.Array = new int[] { 1, 2, 3, 3, 10, 10, 10, 10, 10 };

            Console.WriteLine(String.Format($"Количество максимальных элементов: {arr_3.MaxCount}"));

            Console.WriteLine();

            operFile arr_4 = new operFile(arr_3.Array);

            arr_4.SaveFile();
            
            string[] myArray = arr_4.OpenFile();

            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
        }
    }

    class task
    {
        private int[] array;
        public int[] Array { get => array; set => array = value; }

        /// <summary>
        /// Конструктор, создающий массив
        /// </summary>
        public task() { }

        /// <summary>
        /// Конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
        /// </summary>
        /// <param name="index">Размер массива</param>
        /// <param name="start">Начальное значение</param>
        /// <param name="step">Шаг</param>
        public task(int index, int start, int step)
        {
            int[] array = new int[index];

            for (int i = 0; i < index; i++)
            {
                array[i] = start + (step * i);
            }
            this.array = array;
        }

        /// <summary>
        /// свойство которое возвращают сумму элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (var i in array)
                {
                    sum += i;
                };
                return sum;
            }
        }

        /// <summary>
        /// Меняет знаки у всех элементов массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -array[i];
            }
        }

        /// <summary>
        /// Умножение каждого элемента массива на определенное число
        /// </summary>
        /// <param name="mlt"></param>
        /// <returns></returns>
        public void Multi(int mlt)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = mlt * array[i];
            }
        }

        /// <summary>
        /// Kоличество максимальных элементов в массиве
        /// </summary>
        public int MaxCount {
            get
            {
                int max = array.Max();
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == max)
                        count += 1;
                }
                return count;
            }
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
