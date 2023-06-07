using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEgor6110
{
    public class Hash<T>
    {
        public int key { get; }
        public T value;

        public Hash(int k, T v)
        {
            key = k;
            value = v;
        }
        public override string ToString()
        {
            return String.Format("({0},{1}) ", key, value);
        }
    }
}