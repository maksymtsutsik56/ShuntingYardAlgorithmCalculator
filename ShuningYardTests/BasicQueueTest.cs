using ShuntingYard;

namespace ShuntingYardTests
{
    internal class BasicQueueTest
    {
        [Test]

        public void BasicQueueDoesNotOverFlowWithException()
        {
            BasicQueue<int> basicQueue = new();

            Assert.DoesNotThrow(() => { for (int i = 0; i < 10; i++) basicQueue.Enqueue(1); });
        }

        [Test]
        public void BasicQueueDoesNotThrowExceptionCycleUpsize()
        {
            BasicQueue<int> basicQueue = new();

            basicQueue.Enqueue(1);
            basicQueue.Enqueue(1);

            basicQueue.Dequeue();

            basicQueue.Enqueue(1);
            basicQueue.Enqueue(1);
            basicQueue.Enqueue(1);

            Assert.DoesNotThrow(() => { basicQueue.Enqueue(1); });
        }

        [Test]
        public void ThrowsExceptionWhenDequeuingEmpty()
        {
            BasicQueue<int> basicQueue = new();

            Assert.Throws<InvalidOperationException>(() => basicQueue.Dequeue());
        }

        [Test]
        public void DequeuesLogicallyCorrectValue()
        {
            BasicQueue<int> basicQueue = new();

            basicQueue.Enqueue(1);
            basicQueue.Enqueue(2);

            int first = basicQueue.Dequeue();
            int second = basicQueue.Dequeue();

            var result = new { item1 = first, item2 = second };

            Assert.That(result, Is.EqualTo(new { item1 = 1, item2 = 2 }));

        }

        [Test]

        public void EnqueuingWithResizeWorksCorrectly()
        {
            BasicQueue<int> basicQueue = new();

            basicQueue.Enqueue(1);
            basicQueue.Dequeue();
            basicQueue.Enqueue(1);
            basicQueue.Enqueue(2);
            basicQueue.Enqueue(3);
            basicQueue.Enqueue(4);
            basicQueue.Enqueue(5);

            int[] result = new int[5];
            for (int i = 0; i < 5; i++)
            {
                result[i] = basicQueue.Dequeue();
            }
              
            Assert.That(result, Is.EqualTo([1,2,3,4,5,]));

        }
    }
}
