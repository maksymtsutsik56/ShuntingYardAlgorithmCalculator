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
}
