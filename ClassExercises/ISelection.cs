using System.Collections.Generic;

namespace ClassExercises
{
    
    public interface ISelection<T> : IEnumerable<T>
    {
        bool IsEmpty();
        int GetSize();
        
        

    }
}