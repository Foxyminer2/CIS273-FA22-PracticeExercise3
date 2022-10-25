using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeExercise3;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestStackPush()
        {
            var stack = new PracticeExercise3.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            stack.Push(8);

            Assert.AreEqual(5, stack.Length);
            Assert.AreEqual("8\n5\n3\n2\n1\n", stack.ToString());

        }

        [TestMethod]
        public void TestStackPop()
        {
            // judah

            var stack = new PracticeExercise3.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            stack.Push(8);
            stack.Push(13);
            Assert.AreEqual("13\n8\n5\n3\n2\n1\n", stack.ToString());

            Assert.AreEqual(13, stack.Pop());
            Assert.AreEqual("8\n5\n3\n2\n1\n", stack.ToString());

            stack = new PracticeExercise3.Stack<int>();

            stack.Push(5);
            stack.Pop();
            Assert.AreEqual(0, stack.Length);


            Assert.ThrowsException<EmptyStackException>(() =>
            {
                stack.Pop();
            });


        }

        [TestMethod]
        public void TestStackPeek()
        {
            // lou
            var stack = new PracticeExercise3.Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            stack.Push(8);

            Assert.AreEqual(5, stack.Length);

            Assert.AreEqual("8\n5\n3\n2\n1\n", stack.ToString());
            stack.Pop();
            Assert.AreEqual(5, stack.Peek());
            Assert.AreEqual(4, stack.Length);
            Assert.AreEqual("5\n3\n2\n1\n", stack.ToString());

            stack.Pop();

            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(3, stack.Length);

            Assert.AreEqual("3\n2\n1\n", stack.ToString());

            stack.Pop();
            stack.Pop();
            stack.Pop();

            Assert.AreEqual(0, stack.Length);

            Assert.ThrowsException<EmptyStackException>(() =>
            {
                stack.Peek();
            });

        }

        [TestMethod]
        public void TestStackLength()
        {
            // danny

            var stack = new PracticeExercise3.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual(5, stack.Length);

            var stack2 = new PracticeExercise3.Stack<int>();
            stack2.Push(5);
            stack2.Push(10);
            stack2.Push(15);
            stack2.Push(20);
            stack2.Push(25);
            stack2.Push(30);
            stack2.Push(35);

            Assert.AreEqual(7, stack2.Length);

            var stack3 = new PracticeExercise3.Stack<int>();
            stack3.Push(1);

            Assert.AreEqual(1, stack3.Length);
        }

        [TestMethod]
        public void TestStackIsEmpty()
        {
            // kelly

            var stack = new PracticeExercise3.Stack<int>();

            Assert.IsTrue(stack.IsEmpty);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            stack.Push(8);

            Assert.IsFalse(stack.IsEmpty);

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty);

        }



        [TestMethod]
        public void TestQueueDequeue()
        {
            // lauren
            var queue = new PracticeExercise3.Queue<int>();

            for (int i = 1; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());

            Assert.AreEqual(7, queue.Length);
            Assert.AreEqual("<Back> 9 → 8 → 7 → 6 → 5 → 4 → 3 <Front>", queue.ToString());

            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(5, queue.Length);
            Assert.AreEqual("<Back> 9 → 8 → 7 → 6 → 5 <Front>", queue.ToString());

            queue.Enqueue(10);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(0, queue.Length);
            Assert.AreEqual("<Back><Front>", queue.ToString().Replace(" ", ""));

            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                queue.Dequeue();
            });

            var queue1 = new PracticeExercise3.Queue<int>();
            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                queue1.Dequeue();
            });

        }

        [TestMethod]
        public void TestQueueEnqueue()
        {
            // 
            var queue = new PracticeExercise3.Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Length);
            Assert.AreEqual("<Back> 5 → 4 → 3 → 2 → 1 <Front>", queue.ToString());

            queue.Enqueue(6);
            queue.Enqueue(7);

            Assert.AreEqual(7, queue.Length);
            Assert.AreEqual("<Back> 7 → 6 → 5 → 4 → 3 → 2 → 1 <Front>", queue.ToString());

        }

        [TestMethod]
        public void TestQueueFirst()
        {
            // savannah

            var queue = new PracticeExercise3.Queue<int>();

            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                int i = queue.First;
            });

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Assert.AreEqual(0, queue.First);
            }

            Assert.AreEqual(10, queue.Length);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, queue.First);
                queue.Dequeue();
            }

        }

        [TestMethod]
        public void TestQueueLast()
        {
            // zach

            var queue = new PracticeExercise3.Queue<int>();
            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                int x = queue.Last;
            });

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Assert.AreEqual(i, queue.Last);
            }

            for (int i = 0; i < 10; i++)
            {
                queue.Dequeue();
            }

            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                int x = queue.Last;
            });
        }

        [TestMethod]
        public void TestQueueIsEmpty()
        {
            // kenan

            var queue = new PracticeExercise3.Queue<int>();

            Assert.IsTrue(queue.IsEmpty);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Assert.IsFalse(queue.IsEmpty);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty);

        }

        [TestMethod]
        public void TestQueueLength()
        {
            // john allen

            var queue = new PracticeExercise3.Queue<int>();
            Assert.AreEqual(0, queue.Length);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Length);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(0, queue.Length);
        }

        [TestMethod]
        public void TestDequeAddFront()
        {
            // sean

            Deque<int> deque = new Deque<int>();

            deque.AddFront(1);
            Assert.AreEqual(1, deque.Front);

            deque.AddFront(2);
            Assert.AreEqual(2, deque.Front);

            deque.AddFront(3);
            Assert.AreEqual(3, deque.Front);

            deque.AddFront(4);
            Assert.AreEqual(4, deque.Front);

            deque.AddFront(5);
            Assert.AreEqual(5, deque.Front);

            Assert.AreEqual(5, deque.Length);
            Assert.AreEqual(1, deque.Back);

            Assert.AreEqual("<Back> 1 → 2 → 3 → 4 → 5 <Front>", deque.ToString());
        }

        [TestMethod]
        public void TestDequeAddBack()
        {
            // tristan
            Deque<int> deque = new Deque<int>();

            deque.AddBack(1);
            deque.AddBack(2);
            deque.AddBack(3);
            deque.AddBack(4);
            deque.AddBack(5);

            Assert.AreEqual(5, deque.Length);
            Assert.AreEqual(1, deque.Front);
            Assert.AreEqual(5, deque.Back);
            Assert.AreEqual("<Back> 5 → 4 → 3 → 2 → 1 <Front>", deque.ToString());

            deque.RemoveBack();
            deque.AddBack(6);
            Assert.AreEqual(5, deque.Length);
            Assert.AreEqual(1, deque.Front);
            Assert.AreEqual(6, deque.Back);
            Assert.AreEqual("<Back> 6 → 4 → 3 → 2 → 1 <Front>", deque.ToString());

        }

        [TestMethod]
        public void TestDequeRemoveFront()
        {
            // madison

            Deque<int> deque = new Deque<int>();

            for (int i = 0; i < 5; i++)
            {
                deque.AddBack(i);
            }

            Assert.AreEqual(5, deque.Length);
            Assert.AreEqual("<Back> 4 → 3 → 2 → 1 → 0 <Front>", deque.ToString());

            Assert.AreEqual(0, deque.RemoveFront());
            Assert.AreEqual("<Back> 4 → 3 → 2 → 1 <Front>", deque.ToString());

            deque.AddFront(-1);

            Assert.AreEqual("<Back> 4 → 3 → 2 → 1 → -1 <Front>", deque.ToString());
            Assert.AreEqual(-1, deque.RemoveFront());
            Assert.AreEqual("<Back> 4 → 3 → 2 → 1 <Front>", deque.ToString());

            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();

            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                deque.RemoveFront();
            });

        }

        [TestMethod]
        public void TestDequeRemoveBack()
        {
            // kenan
            Deque<int> deque = new Deque<int>();

            deque.AddBack(1);
            deque.AddBack(2);
            deque.AddBack(3);
            deque.AddBack(4);
            deque.AddBack(5);

            Assert.AreEqual(5, deque.Length);
            Assert.AreEqual("<Back> 5 → 4 → 3 → 2 → 1 <Front>", deque.ToString());

            Assert.AreEqual(5, deque.RemoveBack());
            Assert.AreEqual(4, deque.Length);
            Assert.AreEqual("<Back> 4 → 3 → 2 → 1 <Front>", deque.ToString());

            Assert.AreEqual(4, deque.RemoveBack());
            Assert.AreEqual(3, deque.RemoveBack());
            Assert.AreEqual(2, deque.RemoveBack());
            Assert.AreEqual(1, deque.RemoveBack());

        }


        [TestMethod]
        public void TestDequeIsEmpty()
        {
            // kenan
            Deque<int> deque = new Deque<int>();

            Assert.IsTrue(deque.IsEmpty);

            deque.AddBack(1);
            deque.AddBack(2);
            deque.AddBack(3);
            deque.AddBack(4);
            deque.AddBack(5);

            Assert.IsFalse(deque.IsEmpty);

            deque.RemoveBack();
            deque.RemoveBack();
            deque.RemoveBack();
            deque.RemoveBack();
            deque.RemoveBack();

            Assert.IsTrue(deque.IsEmpty);
        }

        [TestMethod]
        public void TestDequeLength()
        {
            // kenan
            Deque<int> deque = new Deque<int>();

            Assert.AreEqual(0, deque.Length);

            deque.AddBack(1);
            deque.AddBack(2);
            deque.AddBack(3);
            deque.AddBack(4);
            deque.AddBack(5);

            Assert.AreEqual(5, deque.Length);

            deque.RemoveBack();
            deque.RemoveFront();

            Assert.AreEqual(3, deque.Length);

            deque.RemoveBack();
            deque.RemoveBack();
            deque.RemoveBack();

            Assert.AreEqual(0, deque.Length);

        }

        [TestMethod]
        public void TestDequeFront()
        {
            // tim

            Deque<int> deque = new Deque<int>();

            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                var back = deque.Front;
            });

            deque.AddFront(1);
            deque.AddFront(2);
            deque.AddFront(3);
            deque.AddFront(4);
            deque.AddFront(5);

            Assert.AreEqual(5, deque.Front);

            deque.RemoveFront();

            Assert.AreEqual(4, deque.Front);

            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();

            Assert.AreEqual(1, deque.Front);
        }

        [TestMethod]
        public void TestDequeBack()
        {
            // bryce

            Deque<int> myDeque = new Deque<int>();

            Assert.ThrowsException<EmptyQueueException>(() =>
            {
                var back = myDeque.Back;
            });

            for (int i = 0; i < 5; i++)
            {
                myDeque.AddBack(i);
            }

            Assert.AreEqual(myDeque.Back, 4);

            myDeque.AddBack(5);
            myDeque.AddFront(6);

            Assert.AreEqual(myDeque.Back, 5);

            myDeque.RemoveBack();
            myDeque.RemoveBack();

            Assert.AreEqual(myDeque.Back, 3);

            myDeque.RemoveFront();

            Assert.AreEqual(myDeque.Back, 3);
        }
    }
}