namespace ClassExercises
{
    public interface IQueue<T> : ISelection<T>
    {
        void Enqueue(T item);
         T Dequeue();
    }
}