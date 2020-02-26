namespace ClassExercises
{
    public class Node<T>
    {
        public T Value { get; }
        public Node<T> Next { get; }

        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}