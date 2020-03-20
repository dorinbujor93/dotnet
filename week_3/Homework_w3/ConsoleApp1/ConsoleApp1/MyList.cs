using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    public class MyList<T> : IList<T>
    {
        private int _len;
        private T[] _container;
        static T[] _emptyArray = new T[2];
        public T this[int index]
        {
            get
            {
                return _container[index];
            }
            set
            {
                _container[index] = value;
            }
        }
        public int Capacity
        {
            get { return _container.Length; }
            set
            {
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    if (_len > 0)
                    {
                        Array.Copy(_container, 0, newItems, 0, _len);
                    }
                }
                else
                {
                    _container = _emptyArray;
                }
            }
        }

        private void RiseCapacity(int minLength)
        {
            if (_container.Length < minLength)
            {
                Capacity = _container.Length * 2;
            }
        }

        public MyList()
        {
            _container = _emptyArray;
        }

        public MyList(int capacity)
        {

            if (capacity == 0)
            {
                _container = _emptyArray;
                _len = 0;
            }
            else if (capacity > 0)
            {
                _container = new T[capacity];
                _len = capacity;
            }
        }

    
        public int Count
        {
            get { return _len; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            if (_len == _container.Length)
            {
                RiseCapacity(_len + 1);
            }
            _container[_len++] = item;
        }

     
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index > 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }


      
        public void RemoveAt(int index)
        {
            if (index < _len)
            {
                var sourceIndex = index + 1;
                Array.Copy(_container, sourceIndex, _container, index, _len - index);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in  this._container)
            {
                yield return item;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _container.GetEnumerator();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }


    }
}
