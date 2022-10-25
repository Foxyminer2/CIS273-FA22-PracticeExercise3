using System;
namespace PracticeExercise3
{
    public class Deque<T> : IDeque<T>
    {
        private LinkedList<T> linkedList;

        public Deque()
        {
            linkedList = new LinkedList<T>();
        }

        public bool IsEmpty => linkedList.Count == 0;

        public int Length => linkedList.Count;

        public T Front => IsEmpty ? throw new EmptyQueueException() : linkedList.Last.Value;

        public T Back => IsEmpty ? throw new EmptyQueueException() : linkedList.First.Value;

        public void AddBack(T item)
        {
            linkedList.AddFirst(item);
        }

        public void AddFront(T item)
        {
            linkedList.AddLast(item);
        }

        public T RemoveBack()
        {
            if (IsEmpty)
            {
                throw new EmptyQueueException();
            }

            var back = linkedList.First.Value;
            linkedList.Remove(back);

            return back;

        }

        public T RemoveFront()
        {

            if (IsEmpty)
            {
                throw new EmptyQueueException();
            }

            var front = linkedList.Last.Value;
            linkedList.Remove(front);

            return front;
        }

        public override string ToString()
        {
            string result = "<Back> ";

            var currentNode = linkedList.First;
            while (currentNode != null)
            {
                result += currentNode.Value;
                if (currentNode.Next != null)
                {
                    result += " → ";
                }
                currentNode = currentNode.Next;
            }

            result += " <Front>";

            return result;
        }
    }
}

