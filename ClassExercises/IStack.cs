namespace ClassExercises
{
    public interface IStack<T> : ISelection<T>
    {
        public void Push(T item);
        public T Pop();
    }
}