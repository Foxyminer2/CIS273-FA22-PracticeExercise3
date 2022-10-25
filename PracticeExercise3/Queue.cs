using System;
namespace PracticeExercise3
{
    public class Queue<T> : IQueue<T>
    {
        private LinkedList<T> linkedList;

        public Queue()
        {
            linkedList = new LinkedList<T>();
        }

        public T First => IsEmpty ? throw new EmptyQueueException() : linkedList.First.Value;

        public T Last => IsEmpty ? throw new EmptyQueueException() : linkedList.Last.Value;

        public int Length => linkedList.Count;

        public bool IsEmpty => linkedList.Count == 0;

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new EmptyQueueException();
            }
            var front = linkedList.First.Value;
            linkedList.RemoveFirst();

            return front;
        }

        public void Enqueue(T item)
        {
            linkedList.AddLast(item);
        }

        public override string ToString()
        {
            string result = "<Back> ";

            var currentNode = linkedList.Last;
            while (currentNode != null)
            {
                result += currentNode.Value;
                if (currentNode.Previous != null)
                {
                    result += " → ";
                }
                currentNode = currentNode.Previous;
            }

            result += " <Front>";

            return result;
        }
    }
}

