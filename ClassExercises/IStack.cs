namespace ClassExercises
{
    public interface IStack<T> : ISelection<T>
    {
         void Push(T item);
         T Pop();
    }
}