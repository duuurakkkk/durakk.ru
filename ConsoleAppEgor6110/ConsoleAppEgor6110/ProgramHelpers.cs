using ConsoleAppEgor6110;

internal static class ProgramHelpers
{
    private static void Main(string[] args)
    {
        // Фибоначчи, Конвертер, Корни

        Console.WriteLine("Hello, World!");
        Console.WriteLine(asd.Fibo(5));
        Console.WriteLine(asd.Fibo2(5));
        Console.WriteLine(asd.convert(6, 4));
        Console.WriteLine(asd.korenpd(0, 4, Math.Cos));

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

        Console.ReadKey();

        Console.WriteLine("Bubble Sorting");
        int[] ab = { 4, -5, 18, 0, 8, 3, -9, -14 };
        ConsoleAppEgor6110.sort.BubbleSort<int>(ab);
        foreach (int el in ab)
        {
            Console.Write("{0} \t", el);
        }
        Console.WriteLine(" ");

        int[] bc = { 4, -5, -18, 0, 8, -9, -14 };
        Console.WriteLine("MaxSelection Sorting");
        ConsoleAppEgor6110.sort.MaxSelection<int>(bc);
        foreach (int el in bc)
        {
            Console.Write("{0} \t", el);
        }
        Console.WriteLine(" ");

        int[] cd = { 4, -5, -3, 5, 1, 0, 30, 5 };
        Console.WriteLine("Shell Sorting");
        ConsoleAppEgor6110.sort.ShellSort<int>(cd);
        foreach (int el in cd)
        {
            Console.Write("{0} \t", el);
        }
        Console.WriteLine(" ");

        int[] da = { 4, -5, -18, 2, -3, -9, 8 };
        Console.WriteLine("Insertion Sorting");
        ConsoleAppEgor6110.sort.InsertionSort<int>(da);
        foreach (int el in da)
        {
            Console.Write("{0} \t", el);
        }
        Console.WriteLine(" ");

        int[] dc = { 4, -5, 28, 5, 2, -13, -40 };
        Console.WriteLine("Quick Sorting");
        ConsoleAppEgor6110.sort.QuickSort(dc);
        foreach (int el in dc)
        {
            Console.Write("{0} \t", el);
        }
        Console.WriteLine(" ");

        int[] ba = { 7, -10, 19, 0, 5, 2, -9, -15 };
        Console.WriteLine("Merge Sorting");
        ConsoleAppEgor6110.sort.MergeSort<int>(ba);
        foreach (int el in ba)
        {
            Console.Write("{0} \t", el);
        }
        Console.WriteLine(" ");
        Console.WriteLine("");
        Console.ReadKey();
    }
}