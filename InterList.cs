using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListPrp
{
    interface InterList<T>
    {
        int GetLength();
        void Add(T value);
        void Clear();
        void Insert(int index,T value);
        void Delete(int index);
        T this[int index] { get; set; }
        T Select(int index);
        int IndexOf(T value);
    }
}