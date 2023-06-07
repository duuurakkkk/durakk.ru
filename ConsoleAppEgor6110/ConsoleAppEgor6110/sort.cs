using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEgor6110
{
    class sort
    {
        // Бабл сорт
        public static void BubbleSort<T>(T[] list) where T : IComparable
        {
            int N = list.Length; //В переменную записываем длину
            bool swappedElements = true;
            while (swappedElements)
            {
                N--;
                swappedElements = false;
                for (int i = 0; i < N; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)
                    {
                        T tmp;
                        tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;
                        swappedElements = true;
                    }
                }
            }
        }
        // MAX SELECTION
        public static void MaxSelection<T>(T[] list) where T : IComparable
        {
            int N = list.Length; //В переменную записываем длину
            for (int i = 0; i < N - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (list[j].CompareTo(list[maxIndex]) < 0)
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    T tmp = list[i];
                    list[i] = list[maxIndex];
                    list[maxIndex] = tmp;
                }
            }
        }
        // Шелл сорт
        public static void ShellSort<T>(T[] list) where T : IComparable
        {
            int N = list.Length; //В переменную записываем длину
            int ser = N / 2; //Устанавливаем шаг на половину длины списка
            while (ser > 0) //Пока шаг больше нуля
            {
                for (int i = ser; i < N; i++) //Перебираем элементы с шагом ser, начиная с i = ser
                {
                    T tmp = list[i]; //Сохраняем значение текущего элемента во временной переменной
                    int j = i; //Устанавливаем переменную i в j
                    while (j >= ser && list[j - ser].CompareTo(tmp) > 0) //Пока j больше или равно ser и значение элемента на расстоянии ser меньше значения временной переменной tmp
                    {
                        list[j] = list[j - ser]; //Значение элемента на позиции j - ser сохраняем в элемент на позиции j
                        j -= ser; //Уменьшаем j на шаг ser
                    }
                    list[j] = tmp; //Записываем значение временной переменной в элемент на позиции j
                }
                ser /= 2; //Уменьшаем шаг вдвое
            }
        }
        //Insertion Sort
        public static void InsertionSort<T>(T[] list) where T : IComparable
        {
            int N = list.Length; //В переменную записываем длину
            for (int i = 1; i < N; i++) //Идем по массиву до конца, начиная со второго элемента
            {
                T key = list[i]; //Заполняем текущий элемент
                int j = i - 1; //Запоминаем предыдуший индекс элемента
                while (j >= 0 && list[j].CompareTo(key) > 0) // Идем по уже отсортированной части массива
                {                                            // и сдвигаем элементы, большие текущего, вправо
                    list[j + 1] = list[j]; //Сдвигаем элемент вправо
                    j--; //Уменьшаем индекс на один 
                }
                list[j + 1] = key; //Вставляем текущий элемент на свое место
            }
        }

        // Мердж сорт
        public static void MergeSort<T>(T[] list) where T : IComparable
        {
            int N = list.Length;
            if (N == 1)
            {
                return;
            }
            int mid = N / 2;
            T[] left = new T[mid];
            T[] right = new T[N - mid];
            for (int i = 0; i < mid; i++)
            {
                left[i] = list[i];
            }
            for (int i = mid; i < N; i++)
            {
                right[i - mid] = list[i];
            }
            MergeSort(left);
            MergeSort(right);
            Merge(list, left, right);

        }
        public static void Merge<T>(T[] list, T[] left, T[] right) where T : IComparable
        {
            int MinOneList = 0, MinTwoList = 0, MinList = 0;
            while (MinOneList < left.Length && MinTwoList < right.Length)
            {
                if (left[MinOneList].CompareTo(right[MinTwoList]) < 0)
                {
                    list[MinList] = left[MinOneList];
                    MinOneList++;
                }
                else
                {
                    list[MinList] = right[MinTwoList];
                    MinTwoList++;
                }
                MinList++;

            }
            while (MinOneList < left.Length)
            {
                list[MinList] = left[MinOneList];
                MinOneList++;
                MinList++;
            }
            while (MinTwoList < right.Length)
            {
                list[MinList] = right[MinTwoList];
                MinTwoList++;
                MinList++;
            }
        }

        // Квик сорт
        public static void QuickSort<T>(T[] arr) where T : IComparable
        {
            if (arr == null)
            {
                return;
            }
            Quick(arr, 0, arr.Length - 1);
        }
        public static void Quick<T>(T[] arr, int MinIndex, int MaxIndex) where T : IComparable
        {
            if (MinIndex < MaxIndex)
            {
                int pivotIndex = FindPivot(arr, MinIndex, MaxIndex);
                Quick(arr, MinIndex, pivotIndex - 1);
                Quick(arr, pivotIndex + 1, MaxIndex);
            }
        }
        public static int FindPivot<T>(T[] arr, int MinIndex, int MaxIndex) where T : IComparable
        {
            T pivot = arr[MinIndex];
            int leftIndex = MinIndex + 1;
            int rightIndex = MaxIndex;
            while (leftIndex <= rightIndex)
            {
                if (arr[leftIndex].CompareTo(pivot) <= 0)
                {
                    leftIndex++;
                }
                else if (arr[rightIndex].CompareTo(pivot) >= 0)
                {
                    rightIndex--;
                }
                else
                {
                    T tmp = arr[leftIndex];
                    arr[leftIndex] = arr[rightIndex];
                    arr[rightIndex] = tmp;
                    leftIndex++;
                    rightIndex--;
                }
            }
            int pivotIndex = MinIndex;
            T p = arr[rightIndex];
            arr[rightIndex] = arr[pivotIndex];
            arr[pivotIndex] = p;
            return rightIndex;
        }

        // Сортировка перестановкой
        private static void Main(string[] args)
        {
            int[] array = { 5, 2, 7, 1, 3 };

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Выполним сортировку путем перестановки элементов
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }   
                }
            }

            Console.WriteLine("Отсортированный массив:");
            PrintArray(array);
        }

        static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}