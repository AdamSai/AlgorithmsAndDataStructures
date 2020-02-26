using System.Collections.Generic;

namespace ClassExercises
{
    public class NodeIterator<T> where T : IEnumerator<T>
    {
        private Node<T> _step;

        public NodeIterator(Node<T> first)
        {
            this._step = first;
        }

        public bool HasNext()
        {
            return _step != null;
        }

        public T Next()
        {
            T value = _step.Value;
            _step = _step.Next;
            return value;
        }
    }
}