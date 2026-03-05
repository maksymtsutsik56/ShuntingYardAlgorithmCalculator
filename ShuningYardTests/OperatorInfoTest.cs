using ShuntingYard;

namespace ShuntingYardTests;

internal class OperatorInfoTest
{
    [Test]

    public void TestingGetAssociativity()
    {
        Associativity result = OperatorInfo.GetAssociativity("+");

        Assert.That(result, Is.EqualTo(Associativity.Left));
    }

    [Test] 

    public void getAssociativityThrowsExceptionIfNotRecognizedOperator()
    {
        Assert.Throws<ArgumentException>(() => OperatorInfo.GetAssociativity("arcsin"));
    }

    [TestCase(1, 2, "+", 3)]
    [TestCase(6, 8, "/", 0.75)]
    [TestCase(3, 4, "^", 81)]

    public void Apply_ShouldReturnCorrectOperationResult(double first, double second, string @operator, double expected)
    {
        double result = OperatorInfo.Apply(first, second, @operator);

        Assert.That(result, Is.EqualTo(expected));
    }
}
