using System;

namespace ClassExercises.PriorityQueues
{
    public interface IPriorityQueue<T>: ISelection<T> where T: IComparable<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}