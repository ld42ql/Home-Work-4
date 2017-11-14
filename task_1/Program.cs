using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    #region *** Балеев Владимир  * Задание № 1***
    /* Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
     * Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
     * В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.  */
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20] { 6, 2, 9, -3, 6, 254, 21, -854, 54, -57, 586, -3579, 5459, 547, 987, -900, 687, 97, -11, 9 };
            
            Console.WriteLine(String.Format($"Ответ: {task.CountCouples(array)}"));
        }

    }
    class task
    {
        /// <summary>
        /// Ввыводим количество пар элементов массива, в которых хотя бы одно число делится на 3
        /// </summary>
        /// <param name="array">одномерный массив</param>
        /// <returns>Количество пар</returns>
        static public int CountCouples(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % 3 == 0 || array[i + 1] % 3 == 0) { count++; }
            }
                return count;
        }
    }
}
