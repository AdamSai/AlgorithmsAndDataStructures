using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassExercises
{
    public class LinkedBag<T> : IBag<T>
    {

        private Node<T> first = null;
        private int size;
        public void Add(T item)
        {
            size++;
            if (first == null)
            {
                first = new Node<T>(item);
                return;
            }
            var tmp = first;
            while (tmp.next != null) tmp = tmp.next;
            tmp.next = new Node<T>(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public int GetSize()
        {
            return size;
        }
    }

    class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data)
        { 
            this.data = data;
        }
    }
}

