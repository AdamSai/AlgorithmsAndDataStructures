using System;

namespace ClassExercises
{
    public interface IPriorityQueue<T> where T: IComparable<T>, ISelection<T>
    {
        void Enqueue();
        T Dequeue();
        T Peek();
    }
}