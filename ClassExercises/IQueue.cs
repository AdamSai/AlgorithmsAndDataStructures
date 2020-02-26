namespace ClassExercises
{
    public interface IQueue<T> : ISelection<T>
    {
        public void Enqueue(T item);
        public T Dequeue();
    }
}