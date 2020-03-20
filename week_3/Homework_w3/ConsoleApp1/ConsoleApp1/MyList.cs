using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    public class MyList<T> : IList<T>
    {
        private int _size;
        private T[] _container;

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

        static T[] _emptyArray = new T[2];

        public int Capacity
        {
            get { return _container.Length; }
            set
            {
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    if (_size > 0)
                    {
                        Array.Copy(_container, 0, newItems, 0, _size);
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
                _size = 0;
            }
            else if (capacity > 0)
            {
                _container = new T[capacity];
                _size = capacity;
            }
        }

    
        public int Count
        {
            get { return _size; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            if (_size == _container.Length)
            {
                RiseCapacity(_size + 1);
            }
            _container[_size++] = item;
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
            if (index < _size)
            {
                var sourceIndex = index + 1;
                Array.Copy(_container, sourceIndex, _container, index, _size - index);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _container.Length; i++)
            {
                yield return this._container[i];
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
