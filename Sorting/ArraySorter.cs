using System;
using System.Diagnostics;

namespace Sorting
{
    public class ArraySorter<T> where T : IComparable<T>
    {
        public T[] Queue { get; }
        private int _nextIn;

        public int HeapSize { get; private set; }

        // Max size of the entire tree
        private int MaxHeapSize { get; }


        public ArraySorter(T[] items, int heapSize)
        {
            Queue = new T[heapSize];
            HeapSize = _nextIn = items.Length;
            MaxHeapSize = heapSize;
            // Copy contents of items array to the queue.
            for (var i = 0; i < items.Length; i++) Queue[i] = items[i];
        }

        public void SortAscending()
        {
            HandleSort(MaxHeapify);
        }

        public void SortDescending()
        {
            HandleSort(MinHeapify);
        }

        /// <summary>
        /// Input the appropriate heapify method (MinHeapify or MaxHeapify and heapify the list according to the select heap method)
        /// </summary>
        /// <param name="heapFunction">MinHeapify or MaxHeapify</param>
        private void HandleSort(Action<T[], int, int> heapFunction)
        {
            var stopWatch = Stopwatch.StartNew();

            var length = HeapSize;
            // Build the heap
            HeapifyQueue(heapFunction);

            // Extract element from array one by one
            for (var i = length - 1; i >= 0; i--)
            {
                // Move current root to end 
                Exchange(Queue, 0, i);
                // call min heapify on the reduced heap 
                heapFunction(Queue, i, 0);
            }

            stopWatch.Stop();
            Console.WriteLine($"Sorted using {heapFunction.Method.Name} in {stopWatch.Elapsed.ToString()}");
        }

        /// <summary>
        /// Heapifies the entire queue
        /// </summary>
        /// <param name="heapMethod">The heapify method to use. MaxHeapify or MinHeapify</param>
        private void HeapifyQueue(Action<T[], int, int> heapMethod)
        {
            // Go to the last heap in the tree and start heapifying
            for (var i = HeapSize / 2 - 1; i >= 0; i--)
            {
                heapMethod(Queue, HeapSize, i);
            }
        }

        /// <summary>
        /// Max heapify an array
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

        /// <summary>
        /// Creates a min heap
        /// </summary>
        /// <param name="arr">array to be heapified</param>
        /// <param name="size">size of heap</param>
        /// <param name="i">current index</param>
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

        /// <summary>
        /// Heapsort using a lambda expression. Example: arraySorter.Sort((x,y) => x.compareTo(y) > 0);
        /// </summary>
        /// <param name="lambda">A lambda expression with 2 types T and should return a bool</param>
        public void Sort(Func<T, T, bool> lambda)
        {
            var stopWatch = Stopwatch.StartNew();
            var length = HeapSize;

            //Move to last heap in the tree and start hapifying
            for (var i = length / 2 - 1; i >= 0; i--)
            {
                LambdaHeapify(Queue, length, i, lambda);
            }

            for (var i = length - 1; i >= 0; i--)
            {
                // Move current root to end 
                Exchange(Queue, 0, i);

                // call min heapify on the reduced heap 
                LambdaHeapify(Queue, i, 0, lambda);
            }

            stopWatch.Stop();
            Console.WriteLine($"Sorted using lambda expression in {stopWatch.Elapsed.ToString()}");
        }


        /// <summary>
        /// Heapifies using a lambda expression to compare children
        /// </summary>
        /// <param name="arr">Array to heapify</param>
        /// <param name="size">Size of heap</param>
        /// <param name="i">Current index</param>
        /// <param name="lambda">Lambda expression to compare children</param>
        private void LambdaHeapify(T[] arr, int size, int i, Func<T, T, bool> lambda)
        {
            var smallest = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;

            if (left < size && lambda(arr[left], arr[smallest])) smallest = left;
            if (right < size && lambda(arr[right], arr[smallest])) smallest = right;
            if (smallest != i)
            {
                Exchange(arr, i, smallest);
                LambdaHeapify(arr, size, smallest, lambda);
            }
        }

        /// <summary>
        /// Insert an item into the queue
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        /// <exception cref="Exception">Throws exception if queue is full</exception>
        public void Enqueue(T item)
        {
            Console.WriteLine(_nextIn);
            if (HeapSize == MaxHeapSize) throw new Exception("Queue is full!");
            Queue[_nextIn++] = item;
            HeapSize++;
            HeapifyQueue(MinHeapify);
        }

        /// <summary>
        /// Dequeue the root of the tree
        /// </summary>
        /// <returns>Value of type T</returns>
        /// <exception cref="Exception">Throws exception if the queue is empty</exception>
        public T Dequeue()
        {
            if (HeapSize == 0)
                throw new Exception("Queue is empty, can't dequeue.");

            var returnValue = Queue[0];
            // Move last element to the root
            Queue[0] = Queue[--HeapSize];
            Queue[HeapSize] = default;
            HeapifyQueue(MaxHeapify);
            _nextIn--;
            return returnValue;
        }

        /// <summary>
        /// Switches the index of 2 values
        /// </summary>
        /// <param name="arr">Array in which the switch should take place</param>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        private void Exchange(T[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }


        /// <summary>
        /// Returns true if a is smaller than b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool Less(T a, T b)
        {
            IComparable aComparable = (IComparable) a;
            IComparable bComparable = (IComparable) b;
            return aComparable.CompareTo(bComparable) < 0;
        }
    }
}