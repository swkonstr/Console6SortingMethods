using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppNetCore
{
    class Sorter
    {
        int[] InputNumbers { get; set; }
        int[] SortedNumbers { get; set; }

        public Sorter (int[] numbers)
        {
            InputNumbers = numbers;
        }

        public void PrintNumbers()
        {
            Console.WriteLine();
            Console.WriteLine("Массив для сортировки:");
            Console.Write(">> " + InputNumbers[0]);
            for (int i = 1; i < InputNumbers.Length; i++)
            {
                Console.Write(", " + InputNumbers[i]);
            }
        }

        public void PrintSortedNumbers()
        {
            Console.WriteLine();
            Console.WriteLine("Отсортированный массив:");
            Console.Write(">> " + SortedNumbers[0]);
            for (int i = 1; i < SortedNumbers.Length; i++)
            {
                Console.Write(", " + SortedNumbers[i]);
            }
        }


        // Пузырьковая сортировка
        public int[] BubbleSort()
        {
            SortedNumbers = InputNumbers;

            // Сначала сравниваются первые два элемента списка. Если первый элемент больше,
            // они меняются местами. Если они уже в нужном порядке, оставляем их как есть. 
            // Затем переходим к следующей паре элементов, сравниваем их значения и меняем 
            // местами при необходимости. Этот процесс продолжается до последней пары элементов в списке.
            //
            // При достижении конца списка процесс повторяется заново для каждого элемента. 
            // Это крайне неэффективно, если в массиве нужно сделать, например, только один обмен.
            // Алгоритм повторяется n² раз, даже если список уже отсортирован.

            bool flag = true;
            while (flag == true)
            {
                flag = false;
                for (int i = 0; i < SortedNumbers.Length - 1; i++)
                {
                    if (SortedNumbers[i] > SortedNumbers[i + 1])
                    {
                        int tmp = SortedNumbers[i + 1];
                        SortedNumbers[i + 1] = SortedNumbers[i];
                        SortedNumbers[i] = tmp;
                        flag = true;
                    }
                }
            }

            return SortedNumbers;
        }


        // Сортировка выборкой
        public int[] SelectionSort()
        {
            SortedNumbers = InputNumbers;

            // Находится наименьший элемент и меняется с первым местами.
            // Теперь, когда нам известно, что первый элемент списка отсортирован,
            // находим наименьший элемент из оставшихся и меняем местами со вторым.
            // Повторяем это до тех пор, пока не останется последний элемент в списке.

            for (int i=0; i < SortedNumbers.Length-1; i++)
            {
                int lowestValueIndex = i;
                for (int j=i+1;j<SortedNumbers.Length-1; j++)
                {
                    if (SortedNumbers[j] < SortedNumbers[lowestValueIndex])
                    {
                        lowestValueIndex = j;
                    }
                }
                int tmp = SortedNumbers[lowestValueIndex];
                SortedNumbers[lowestValueIndex] = SortedNumbers[i];
                SortedNumbers[i] = tmp;
            }
            return SortedNumbers;
        }


        // Сортировка вставками
        public int[] InsertionSort()
        {
            SortedNumbers = InputNumbers;

            // Предполагается, что первый элемент списка отсортирован. Переходим к следующему элементу,
            // обозначим его х. Если х больше первого, оставляем его на своём месте. Если он меньше, 
            // копируем его на вторую позицию, а х устанавливаем как первый элемент.
            //
            // Переходя к другим элементам несортированного сегмента, перемещаем более крупные элементы
            // в отсортированном сегменте вверх по списку, пока не встретим элемент меньше x или не дойдём
            // до конца списка. В первом случае x помещается на правильную позицию.

            int tmp = SortedNumbers[0];
            for (int i = 1; i < SortedNumbers.Length - 1; i++)
            {
                int itemToInsert = SortedNumbers[i];
                int j = i - 1;
                while (j >= 0 && SortedNumbers[j] > itemToInsert)
                {
                    SortedNumbers[j + 1] = SortedNumbers[j];
                    j = j - 1;
                }
                SortedNumbers[j + 1] = itemToInsert;
            }

            return SortedNumbers;
        }


        //Cортировка кучей (пирамидальная сортировка)
        public int[] HeapSort()
        {
            SortedNumbers = InputNumbers;

            // Сначала преобразуем список в Max Heap — бинарное дерево, где самый большой элемент 
            // является вершиной дерева. Затем помещаем этот элемент в конец списка. 
            // После перестраиваем Max Heap и снова помещаем новый наибольший элемент уже перед последним элементом в списке.
            // Этот процесс построения кучи повторяется, пока все вершины дерева не будут удалены.

            int n = SortedNumbers.Length;
            for (int i=n; i==0; i--)
            {
                SortedNumbers = Heapify(SortedNumbers, n, i);
            }
            for (int i=n-1; i > 0; i--)
            {
                int tmp = SortedNumbers[0];
                SortedNumbers[0] = SortedNumbers[i];
                SortedNumbers[i] = tmp;
                SortedNumbers = Heapify(SortedNumbers, i, 0);
            }

            return SortedNumbers;
        }


        //Вспомогательная функция для сортировки кучей
        private int[] Heapify (int[] numbers, int heapSize, int rootIndex)
        {
            // Индекс наибольшего элемента считаем корневым индексом
            int largest = rootIndex;
            int leftChild = (2 * rootIndex) + 1;
            int rightChild = (2 * rootIndex) + 2;

            // Если левый потомок корня — допустимый индекс, а элемент больше,
            // чем текущий наибольший, обновляем наибольший элемент

            if (leftChild < heapSize && numbers[leftChild] > numbers[largest])
            {
                largest = leftChild;
            }

            // Аналогично поступаем с правым потомком корня

            if (rightChild < heapSize && numbers[rightChild] > numbers[largest])
            {
                largest = rightChild;
            }

            // Если наибольший элемент больше не корневой, они меняются местами
            if (largest != rootIndex)
            {
                int tmp = SortedNumbers[largest];
                SortedNumbers[largest] = SortedNumbers[rootIndex];
                SortedNumbers[rootIndex] = tmp;
                this.Heapify(numbers, heapSize, largest);
            }
            return numbers;
        }


        //Сортировка слиянием
        public int[] MergeSort()
        {
            SortedNumbers = InputNumbers;
            return SortedNumbers;
        }


        //Вспомогательная функция для сортировки слиянием


        //Быстрая сортировка (схема Хоара)
        public int[] PartitionSort()
        {
            SortedNumbers = InputNumbers;
            return SortedNumbers;
        }


        //Вспомогательная функция для быстрой сортировки
    }
}
