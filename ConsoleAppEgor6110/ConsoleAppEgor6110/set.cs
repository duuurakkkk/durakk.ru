using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEgor6110
{
    class Set<T> where T : IComparable
    {
        int size, count;
        T[] data;
        public int Size { get { return size; } } // Размер множества
        public int Count { get { return count; } } // Количество элементов в множестве
                                                   // Конструктор
        public Set(int size)
        {
            this.size = size;
            this.count = 0;
            data = new T[this.size];

        }
        // Проверка на наличие элемента
        public bool IsContains(T el)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].CompareTo(el) == 0) return true;
            }
            return false;
        }
        //Получение данных из множества по индексу
        public T GetElByIndex(int index)
        {
            if (index < 0 || index >= count) return default(T);
            return data[index];
        }

        //Изменение данных из множества по индексу
        public T SetElByIndex(int index, T newEl)
        {
            if (index < 0 || index >= count) return default(T);
            data[index] = newEl;
            return data[index];
        }
        // Получение индекса элемента
        public int GetIndex(T el)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].CompareTo(el) == 0) return i;
            }
            return -1;
        }
        // Копирование 
        public Set<T> Copy()
        {
            Set<T> copy = new Set<T>(this.Size);
            for (int i = 0; i < this.Count; i++)
            {
                copy.Add(data[i]);
            }
            return copy;
        }
        //Конструктор
        public Set(T[] mas)
        {
            this.size = mas.Length;
            this.count = 0;
            data = new T[this.size];
            for (int i = 0; i < size; i++)
            {
                if (!IsContains(mas[i])) { data[count] = mas[i]; count++; }
            }
        }
        // Дабавление нового элемента
        public void Add(T el)
        {
            if (IsContains(el)) return;
            if (count < size) // Проверка на наличие места
            {
                data[count] = el;
                count++;
                return;
            }
            T[] temp = new T[this.size];
            for (int i = 0; i < size; i++) temp[i] = data[i];
            this.size *= 2;
            data = new T[this.size];
            for (int i = 0; i < count; i++) data[i] = temp[i];
            data[count] = el;
            count++;
        }
        //Удаление по индексу
        public bool RemoveByIndex(int index)
        {
            if (index < 0 || index >= count) return false; // Проверка на наличие индекса 

            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            count--;
            return true;
        }

        //Удаление элемента 
        public bool RemoveByEl(T el)
        {
            if (!IsContains(el)) return false; // Возвращаем false, если не удаляли 
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(el)) // Сравниваем элементы множества с тем, который хотим удалить 
                {
                    for (int j = i; j < count; j++)
                    {
                        data[j] = data[j + 1]; // Сдвигаем элементы 
                    }
                }
            }
            count -= 1;
            return true;
        }

        //Поиск по индексу
        public int Search(T el)
        {

            for (int i = 0; i < Count; i++)
            {
                if (data[i].Equals(el))
                {
                    return i;
                }
            }
            return -1;
        }
        public override string ToString()
        {

            return "{" + string.Join(";", data) + "}";
        }

        // объедение множеств
        public Set<T> Union(Set<T> s2)
        {
            Set<T> su = new Set<T>(size + s2.Size);
            for (int i = 0; i < count; i++) su.Add(data[i]);
            for (int i = 0; i < s2.Count; i++) su.Add(s2.data[i]);
            return su;
        }
        //Пересечение множеств
        public Set<T> Intersection(Set<T> set2)
        {
            Set<T> su = new Set<T>(size);
            for (int i = 0; i < count; i++) if (set2.IsContains(data[i])) su.Add(data[i]);
            return su;
        }
        public void Resize(int nSize)
        {
            T[] nArray = new T[Count];
            for (int i = 0; i < count; i++)
            {
                nArray[i] = data[i];
            }
            size = nSize;
            data = new T[size];
            for (int i = 0; i < count; i++)
            {
                data[i] = nArray[i];
            }
        }


        //Дополнение множеств (разность) 
        public Set<T> Difference(Set<T> set)
        {
            Set<T> res = new Set<T>(size);
            for (int i = 0; i < count; i++)
                if (!set.IsContains(data[i])) res.Add(data[i]);
            return res;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return data[i];
            }
        }



        // Получение набора множеств из последовательности элементов множества
        public List<Set<T>> GetList()
        {
            List<Set<T>> lsets = new List<Set<T>>();
            for (int i = 0; i < count; i++)
            {
                Set<T> tmpset = new Set<T>(i + 1);
                for (int j = 0; j <= i; j++) tmpset.Add(data[j]);
                lsets.Add(tmpset);
            }
            return lsets;
        }


        public static Set<T> operator *(Set<T> s1, Set<T> s2) => s1.Intersection(s2);

        //Дополнение (разность)
        public int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
        //сочетание
        public List<Set<T>> Combination(int k)
        {
            int[] place = new int[k];
            for (int i = 0; i < k; i++) place[i] = i;
            List<Set<T>> lsets = new List<Set<T>>();
            int num;
            num = Factorial(count) / (Factorial(k) * (Factorial(count - k)));
            for (int i = 0; i < num; i++)
            {
                Set<T> tmp = new Set<T>(k);
                for (int j = 0; j < k; j++)
                    tmp.Add(data[place[j]]);
                lsets.Add(tmp);
                place[k - 1] += 1;
                for (int t = 0; t < k; t++)
                {
                    for (int j = 1; j < k; j++)
                    {
                        if (place[j] >= count)
                        {
                            place[j - 1] += 1;
                            for (int a = j; a < k; a++)
                            {
                                place[a] = place[a - 1] + 1;
                            }
                        }
                    }
                }
            }
            return lsets;
        }

    }
}