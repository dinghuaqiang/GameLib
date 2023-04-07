using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.Base.Container
{
    /// <summary>
    /// 一个快速链表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickList<T>
    {
        public T[] _buffer;
        public int _size;

        public QuickList()
        {
            this._buffer = new T[8];
        }

        public QuickList(int capacity)
        {
            this._buffer = new T[capacity];
        }

        public void Add(T item)
        {
            if ((this._buffer == null) || (this._size == this._buffer.Length))
            {
                this.AllocateMore();
            }
            this._buffer[this._size++] = item;
        }

        private void AllocateMore()
        {
            T[] array = (this._buffer == null) ? new T[0x20] : new T[Mathf.Max(this._buffer.Length << 1, 0x20)];
            if ((this._buffer != null) && (this._size > 0))
            {
                this._buffer.CopyTo(array, 0);
            }
            this._buffer = array;
        }

        public void Clear()
        {
            this._size = 0;
        }

        public void Release()
        {
            this._size = 0;
            this._buffer = null;
        }

        public void Remove(T item)
        {
            if (this._buffer != null)
            {
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                for (int i = 0; i < this._size; i++)
                {
                    if (comparer.Equals(this._buffer[i], item))
                    {
                        this._size--;
                        this._buffer[i] = default(T);
                        for (int j = i; j < this._size; j++)
                        {
                            this._buffer[j] = this._buffer[j + 1];
                        }
                        return;
                    }
                }
            }
        }

        public T Pop()
        {
            if (_buffer != null && _size != 0)
            {
                T val = _buffer[--_size];
                _buffer[_size] = default(T);
                return val;
            }
            return default(T);
        }

        public void RemoveAt(int index)
        {
            if ((this._buffer != null) && (index < this._size))
            {
                this._size--;
                this._buffer[index] = default(T);
                for (int i = index; i < this._size; i++)
                {
                    this._buffer[i] = this._buffer[i + 1];
                }
            }
        }

        public T[] ToArray()
        {
            this.Trim();
            return this._buffer;
        }

        private void Trim()
        {
            if (this._size > 0)
            {
                if (this._size < this._buffer.Length)
                {
                    T[] localArray = new T[this._size];
                    for (int i = 0; i < this._size; i++)
                    {
                        localArray[i] = this._buffer[i];
                    }
                    this._buffer = localArray;
                }
            }
            else
            {
                this._buffer = null;
            }
        }

        public int Count
        {
            get
            {
                return this._size;
            }
        }

        public T this[int i]
        {
            get
            {
                return this._buffer[i];
            }
            set
            {
                this._buffer[i] = value;
            }
        }
    }
}