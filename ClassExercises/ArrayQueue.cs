using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassExercises
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] queueArray;
        private int size, nextOut, nextIn;
        


        public ArrayQueue()
        {
            queueArray = new T[32];
            nextOut = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return queueArray.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int GetSize()
        {
            return nextIn - nextOut;
        }

        public void Enqueue(T item)
        {
            if (queueArray.Length * 0.75 <= nextIn)
            {
                ResizeArray();
            }
            queueArray[nextIn] = item;
            nextIn++;
            size++;
        }

        private void ResizeArray()
        {
            var tempArray = new T[queueArray.Length * 2];
            for (var i = 0; i < queueArray.Length; i++)
            {
                tempArray[i] = queueArray[i];
            }
            queueArray = tempArray;
        }

        public T Dequeue()
        {
            var dequeuedItem = queueArray[nextOut];
            queueArray[nextOut] = default(T);
            nextOut++;
            size--;
            return dequeuedItem;
        }
    }
}