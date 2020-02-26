using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassExercises.PriorityQueues
{
    public class LinkedPriorityQueue<T> :  IPriorityQueue<T> where T : IComparable<T>
    {
        private Node<T> root;
        private int size;
        public LinkedPriorityQueue()
        {
            size = 0;
        }

        public void Enqueue(T data)
        {
            if(size == 0)
            {

                size++;
                root = new Node<T>(data, null);
            }
            else
            {
                var currentNode = root;
                for (var i = 0; i <= size; i++)
                {
                    if (i == 0)
                    {
                        if (Less(data, currentNode.Value))
                        {
                            var temp = currentNode;
                            root = new Node<T>(data, temp);
                            size++;
                            return;
                        }
                    }
                    if (currentNode.Next == null)
                    {
                        currentNode.Next = new Node<T>(data, null);
                        size++;
                        return;
                    }
                    if (Less(data, currentNode.Next.Value))
                    {
                        var temp = currentNode.Next;
                        currentNode.Next = new Node<T>(data, temp);
                        size++;
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        public T Dequeue()
        {
            if(IsEmpty()) throw new IndexOutOfRangeException("Queue is empty");
            var nodeToReturn = root;
            root = root.Next;
            size--;
            return nodeToReturn.Value;
        }

        public T Peek()
        {
            return root.Value;
        }


        private static bool Less(T a, T b)
        {

            return a.CompareTo(b) < 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = root;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
            // return new NodeIterator<T>(root);
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
            return size;
        }
    }
}