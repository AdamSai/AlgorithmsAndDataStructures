using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Principal;

namespace Sorting
{
    public class ArraySorter<T> where T : IComparable<T>
    {
        public T[] Queue { get; }
        private int _heapSize, _maxSize, _nextIn;

        public ArraySorter(T[] items, int size)
        {
            // Heapify array
            Queue = new T[size];
            _heapSize = _nextIn = items.Length;
            for (var i = 0; i < items.Length; i++) Queue[i] = items[i];
            
            _maxSize = size;
        }

        /// <summary>
        /// Heapify an array recursively
        /// </summary>
        /// <param name="arr">Array to be heapified</param>
        /// <param name="size">Size of heap</param>
        /// <param name="i">Current index</param>
        private void MaxHeapify(T[] arr, int size, int i)
        {
            var largest = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;
            // Check if left child is larger than root
            if (left < size && !Less(arr[left], arr[largest])) largest = left;
            // Check if right child is larger than root
            if (right < size && !Less(arr[right], arr[largest])) largest = right;
            if (largest != i)
            {
                Exchange(arr, i, largest);
                MaxHeapify(arr, size, largest);
            }
        }

        private void MinHeapify(T[] arr, int size, int i)
        {
            var smallest = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;
            
            // Check if left child is smaller than root
            if (left < size && Less(arr[left], arr[smallest])) smallest = left;
            // Check if right child is smaller than root
            if (right < size && Less(arr[right], arr[smallest])) smallest = right;
            
            if (smallest != i)
            {
                Exchange(arr, i, smallest);
                MinHeapify(arr, size, smallest);
            }
        }

        public void Enqueue(T item)
        {
            if (_heapSize == _maxSize) throw new Exception("Queue is full!");
            Queue[_nextIn++] = item;
            _heapSize++;
            MinHeapifyQueue();
        }

        private void MinHeapifyQueue()
        {
            for (var i = _heapSize / 2 - 1; i >= 0; i--)
            {
                MinHeapify(Queue, _heapSize, i);
            }
        }

        private void Exchange(T[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        public T Dequeue()
        {
            switch (_heapSize)
            {
                case 0:
                    throw new Exception("Queue is empty, can't dequeue.");
                case 1:
                    return Queue[0];
                default: 
                    var returnValue = Queue[0];
                    Queue[0] = Queue[--_heapSize];
                    Queue[_heapSize] = default;
                    MinHeapifyQueue();
                    return returnValue;
            }
        }
        

        public void SortAscending()
        {
            var stopWatch = Stopwatch.StartNew();
            // Build heap
            var length = _heapSize;
            //Move to last "heap" in the tree and start hapifying
            for (var i = length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(Queue, length, i);
            }

            // Extract element from array one by one
            for (var i = length - 1; i >= 0; i--)
            {
                // Move current root to end 
                var temp = Queue[0];
                Queue[0] = Queue[i];
                Queue[i] = temp;

                // call min heapify on the reduced heap 
                MaxHeapify(Queue, i, 0);
            }
            stopWatch.Stop();
        }

        public void SortDescending()
        {
            var length = _heapSize;
            //Move to last "heap" in the tree and start hapifying
            for (var i = length / 2 - 1; i >= 0; i--)
            {
                MinHeapify(Queue, length, i);
            }
            
            for (var i = length - 1; i >= 0; i--)
            {
                // Move current root to end 
                var temp = Queue[0];
                Queue[0] = Queue[i];
                Queue[i] = temp;

                // call min heapify on the reduced heap 
                MinHeapify(Queue, i, 0);
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if a is smaller than b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool Less(T a, T b)
        {
            IComparable aComparable = (IComparable) a;
            IComparable bComparable = (IComparable) b;
            return aComparable.CompareTo(bComparable) < 0;
        }
    }
}