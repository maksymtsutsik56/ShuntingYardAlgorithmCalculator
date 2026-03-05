using ShuntingYard;

namespace ShuntingYardTests
{
    public class BasikListTests
    {
        [TestCase(-1)]
        [TestCase(3)]

        public void BasicListIndexet_ThrowsIndexOutOfRangeException_WhenIndexOutOfRange(int index)
        {
            BasicList<int> basicList = new BasicList<int>();

            basicList.Add(1);
            basicList.Add(2);

            Assert.Throws<IndexOutOfRangeException>(() => { var dummmy = basicList[index]; });
        }

        [Test]

        public void BasicListIndexet_ReturnsRightValue()
        {
            BasicList<int> basicList = new BasicList<int>();
            basicList.Add(1);

            int ValueAt_0 = basicList[0];

            Assert.That(ValueAt_0, Is.EqualTo(1));
        }

        [Test]

        public void RemoveFromEmptyBasicListThrowsException()
        {
            BasicList<int> basicList = new BasicList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => basicList.RemoveAt(0));
        }


        [Test]

        public void WontOverFlowAndThrowException()
        {
            BasicList<int> basicList = new BasicList<int>();

            Assert.DoesNotThrow(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    basicList.Add(1);
                }
            }
            );
        }
    }
}
