using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListPrp
{
    /// <summary>
    /// 实现MyList功能引用了接口InterList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyList<T> : InterList<T>
    {
        private T[] array;
        private int count;
        /// <summary>
        /// 构造函数用size来进行传参决定这个数组有多长
        /// </summary>
        /// <param name="size"></param>
        public MyList(int size)
        {
            array = new T[size];
            count = 0;
        }
        /// <summary>
        /// 默认构造参数
        /// </summary>
        public MyList():this(5)
        {
            
        }
        /// <summary>
        /// 通过属性来进行设置和读取
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return Select(index);
            }
            set
            {
                Add(value);
            }
        }
        /// <summary>
        /// 判断程序数组元素是否为空
        /// </summary>
        public  bool IsEmpty
        {
            get
            {
                return count == 0; 
            }
        }
        /// <summary>
        /// 向后追加值
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if(count==array.Length)
            {
                Console.WriteLine("容量已满！");
            }
            else
            {
                array[count] = value;
                count++;
            }
        }
        /// <summary>
        /// 清掉个数
        /// </summary>
        public void Clear()
        {
            count = 0;
        }
        /// <summary>
        /// 删除下标的对应值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public void Delete(int index)
        {
            if (this.IsEmpty || index >= count)
            {
                Console.WriteLine("无法删除索引第{0}个元素，因为目前数组的元素上限是{1}", index, count - 1);
                throw new IndexOutOfRangeException();
            }
            else if (index < 0)
            {
                Console.WriteLine("无法删除索引是{0}的元素，在任何情况下，该数组仅接受从0开始的整数（包括0）", index);
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index + 1; i < count; i++)
                {
                    array[i - 1] = array[i];
                }
                count--;
            }
        }
        /// <summary>
        /// 返回已经存在的元素个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return count;
        }
        /// <summary>
        /// 通过value的值来循环判断哪个和value相等这样就可以
        /// 返回一下哪个相等的下标，没有查到返回-1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            for(int i=0;i<count;i++)
            {
                if(array[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        ///通过下标插入一个数据
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            if (this.IsEmpty || index >= count)
            {
                Console.WriteLine("无法插入索引第{0}个元素，因为目前数组的元素上限是{1}", index, count - 1);
                throw new IndexOutOfRangeException();
            }
            else if (index < 0)
            {
                Console.WriteLine("无法插入索引是{0}的元素，在任何情况下，该数组仅接受从0开始的整数（包括0）", index);
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = count - 1; i >= index; i--)
                {
                    array[i + 1] = array[i];
                }
                array[index] = value;
                count++;
            }
        }
        /// <summary>
        /// 通过下标返回一个值，如果下标存在返回那个值
        /// 不存在返回第0个元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Select(int index)
        {
            if (this.IsEmpty||index>=count)
            {
                Console.WriteLine("无法查询索引第{0}个元素，因为目前数组的元素上限是{1}",index,count-1);
                throw new IndexOutOfRangeException();
            }
            else if(index < 0)
            {
                Console.WriteLine("无法查询索引是{0}的元素，在任何情况下，该数组仅接受从0开始的整数（包括0）", index);
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index >= 0 && index <= count - 1)
                {
                    return array[index];
                }
                else
                {
                    Console.WriteLine("下标不存在自动返回0");
                    return array[0];
                }
            }
        }
    }
}
