using ShuntingYard;

namespace ShuntingYardTests
{
    internal class BasicStackTest
    {
        [Test]

        public void PushDontOverFlowAndDontThrowExceptions()
        {
            BasicStack<int> basicStack = new(); 
            
            Assert.DoesNotThrow(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    basicStack.Push(1);
                }
            });
        }

        [Test]
        public void ThrowsExceptionWhenTryingToPopFromEmptyBasicStack()
        {
            BasicStack<int> basicStack = new();
            basicStack.Push(1);
            basicStack.Pop();

            Assert.Throws<InvalidOperationException>(() => basicStack.Pop());
        }

        [Test]
        public void PopReturnsExpectedValue()
        {
            BasicStack<int> basicStack = new();

            basicStack.Push(1);
            basicStack.Push(2);

            int result1 = basicStack.Pop();
            int result2 = basicStack.Pop();

            var expected = new { item1 = 2, item2 = 1 };
            Assert.That(new {item1 = result1, item2 = result2 }, Is.EqualTo(expected));
        }

        [Test]
        public void PeekReturnsExpectedValue()
        {
            BasicStack<int> basicStack = new();

            basicStack.Push(1);
            basicStack.Push(2);

            int result = basicStack.Peek();

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
