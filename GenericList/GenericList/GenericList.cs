using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericList
{
  public  class GenericList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        int index;
        const int size = 0;
        static int pov = 2;
        static int currentValue = (int)Math.Pow(size, pov);

        T[] array = new T[currentValue];
        T[] massiv = new T[currentValue];

        #region Properties
        public int Count
        {
            get { return array.Length; }
        }
        public T this[int index]
        {
            get { return array[index]; }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("The specified index is out of range.");
                array[index] = value;
            }
        }

        object IList.this[int index]
        {
            get { return (IList)array[index]; }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("The specified index is out of range.");
                ((IList)array)[index] = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return array;
            }
        }

        #endregion

        #region Methods
        public void Add(T item)
        {
            int i = array.Length;
            Array.Resize(ref array, i+1);
            array[i] = item;
        }

        int IList.Add(object value)
        {
            array[index++] = (T)value;
            if (index == currentValue)
            {
                currentValue = (int)Math.Pow(size, ++pov);
                T[] temp = new T[currentValue];
                for (int i = 0; i < index; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
            return index;
        }

        public void Clear()
        {
            array = null;
        }

        public bool Contains(T item)
        {
            if (item == null)
                return false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GetType() != item.GetType())
                    return false;
            }
            return true;
        }

        public bool Contains(object item)
        {
            if (item == null)
                return false;
            for (int i = 0; i < array.Length; i++)
            {
                if (!Comparer.Equals(array[i], item))
                {
                    return false;
                }
            }
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= 0)
            {
                for (int i = arrayIndex; i < array.Length; i++)
                    for (int j = 0; j < array.Length; j++)
                        massiv[j] = array[i];
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if (array.Rank > 1)
                throw new ArgumentException("array is multidimensional.");
            if (array.Length - index < Count)
                throw new ArgumentException("Not enough elements after index in the destination array.");

            for (int i = 0; i < Count; ++i)
                array.SetValue(this[i], i + index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (item.Equals(array[i]))
                    return i;
            }
            return -1;
        }

        public int IndexOf(object val)
        {
            for (int i = 0; i < currentValue; i++)
            {
                if (val.Equals(array[i]))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((index < Count) && (index >= 0))
            {
                for (int i = Count - 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = item;
            }
        }

        public void Insert(int index, object value)
        {
            {
                if ((currentValue + 1 <= array.Length) && (index < Count) && (index >= 0))
                {
                    currentValue++;

                    for (int i = Count - 1; i > index; i--)
                    {
                        array[i] = array[i - 1];
                    }
                    array[index] = (T)value;
                }
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
                return false;
            for (int i = 0; i < Count; i++)
                if (array.Equals(item))
                {
                    array[i] = default(T);
                    return true;
                }
            return false;
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if (index >= 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (array.Equals(index))
                    {
                        array[i] = default(T);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
