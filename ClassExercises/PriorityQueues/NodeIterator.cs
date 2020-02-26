using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassExercises.PriorityQueues
{
    public class NodeIterator<T> : IEnumerator<T>
    {
        private Node<T> _step;
        private readonly Node<T> _initial_value;

        public NodeIterator(Node<T> first)
        {
            _step = first;
            _initial_value = first;
        }

        public bool HasNext()
        {
            return _step != null;
        }

        public bool MoveNext()
        {
            Console.WriteLine(_step.Value);
            _step = _step?.Next;
            return HasNext();
        }

        public void Reset()
        {
            _step = _initial_value;
        }

        public T Current => _step.Value;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            _step = null;
        }
    }
}