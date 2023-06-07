using System;
namespace ConsoleAppEgor6110
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Фибоначчи
            Console.WriteLine(Fibo(5));
            Console.WriteLine(Fibo2(5));

            // Конвертер
            Console.WriteLine(convert(6, 4));

            // Корни
            Console.WriteLine(korenpd(0, 4, Math.Cos));

            // Сет(множества)
            Set<int> mySet = new Set<int>(5);
            mySet.Add(1);
            mySet.Add(2);
            mySet.Add(3);
            mySet.Add(4);
            mySet.Add(5);

            Console.WriteLine("MySet: " + mySet.ToString());
            mySet.RemoveByIndex(3);
            Console.WriteLine("MySet после удаление элемента с индексом 3: " + mySet.ToString());

            Set<int> anotherSet = new Set<int>(new int[] { 4, 5, 6 });
            Console.WriteLine("Another Set: " + anotherSet.ToString());

            Set<int> unionSet = mySet.Union(anotherSet);
            Console.WriteLine("Union Set: " + unionSet.ToString());

            Set<int> intersectionSet = mySet.Intersection(anotherSet);
            Console.WriteLine("Intersection Set: " + intersectionSet.ToString());

            // Хэш-Таблицы на основе массива и списков
            Console.WriteLine("HashTable:");
            HashTable<int> hashTable = new HashTable<int>(5);
            hashTable.Add(1, 11);
            hashTable.Add(6, 22);
            hashTable.Add(3, 33);
            hashTable.Add(8, 44);
            hashTable.View();

            Console.WriteLine("HashTable после удаления:");
            hashTable.DelByKey(3);
            hashTable.View();

            Console.WriteLine("\nHashList:");
            HashList<int> hashList = new HashList<int>(5);
            hashList.Add(1, 11);
            hashList.Add(6, 22);
            hashList.Add(3, 33);
            hashList.Add(8, 44);
            hashList.View();

            Console.WriteLine("HashList после удаления:");
            hashList.DelByKey(3);
            hashList.View();

            // Сортировки
            int[] ab = { 4, -5, 18, 0, 8, 3, -9, -14 };
            Console.WriteLine("Bubble Sorting");
            sort.BubbleSort<int>(ab);
            foreach (int el in ab)
            {
                Console.Write("{0} \t", el);
            }
            Console.WriteLine(" ");

            int[] bc = { 4, -5, -18, 0, 8, -9, -14 };
            Console.WriteLine("MaxSelection Sorting");
            sort.MaxSelection<int>(bc);
            foreach (int el in bc)
            {
                Console.Write("{0} \t", el);
            }
            Console.WriteLine(" ");

            int[] cd = { 4, -5, -3, 5, 1, 0, 30, 5 };
            Console.WriteLine("Shell Sorting");
            sort.ShellSort<int>(cd);
            foreach (int el in cd)
            {
                Console.Write("{0} \t", el);
            }
            Console.WriteLine(" ");

            int[] da = { 4, -5, -18, 2, -3, -9, 8 };
            Console.WriteLine("Insertion Sorting");
            sort.InsertionSort<int>(da);
            foreach (int el in da)
            {
                Console.Write("{0} \t", el);
            }
            Console.WriteLine(" ");

            int[] dc = { 4, -5, 28, 5, 2, -13, -40 };
            Console.WriteLine("Quick Sorting");
            sort.QuickSort(dc);
            foreach (int el in dc)
            {
                Console.Write("{0} \t", el);
            }
            Console.WriteLine(" ");

            int[] ba = { 7, -10, 19, 0, 5, 2, -9, -15 };
            Console.WriteLine("Merge Sorting");
            sort.MergeSort<int>(ba);
            foreach (int el in ba)
            {
                Console.Write("{0} \t", el);
            }
            Console.WriteLine(" ");

            Console.ReadKey();
        }

        // Функции из библиотеки asd
        static int Fibo(int n)
        {
            if (n == 0 || n == 1)
                return n;

            return Fibo(n - 1) + Fibo(n - 2);
        }

        static int Fibo2(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        static string convert(int number, int toBase)
        {
            string result = "";
            while (number > 0)
            {
                int remainder = number % toBase;
                result = remainder + result;
                number /= toBase;
            }
            return result;
        }

        static double korenpd(double a, double b, Func<double, double> f)
        {
            double eps = 1E-10;
            double c = (a + b) / 2;
            while (Math.Abs(f(c)) > eps)
            {
                if (f(a) * f(c) < 0)
                    b = c;
                else
                    a = c;
                c = (a + b) / 2;
            }
            return c;
        }
    }
}