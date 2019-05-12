using System;

namespace ConsoleAppNetCore
{
    class Program
    {

        static void Main(string[] args)
        {

            int[] numbers = new int[] { 5, 2, 1, 3, 4 };
            
            Sorter sorter = new Sorter(numbers);
            sorter.PrintNumbers();
            int[] numberss = sorter.HeapSort();
            sorter.PrintSortedNumbers();

            Console.WriteLine();
            Console.WriteLine("Вывод 2 Отсортированный массив:");
            Console.Write(">> " + numberss[0]);
            for (int i = 1; i < numberss.Length; i++)
            {
                Console.Write(", " + numberss[i]);
            }

            Console.Read();
        }
    }
}
