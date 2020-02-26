using System.Threading.Tasks;

namespace ClassExercises
{
    public interface IBag<T> : ISelection<T>
    {
        void Add(T item);
    }
}