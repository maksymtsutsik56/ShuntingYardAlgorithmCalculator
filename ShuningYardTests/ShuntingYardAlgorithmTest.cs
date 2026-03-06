using ShuntingYard;

namespace ShuntingYardTests;

internal class ShuntingYardAlgorithmTest
{
    [Test]

    public void ShuntingYardAlgorithmReturnsCorrectNumberOfTokens()
    {
        string infix = "(1 + 5) * 2  ";

        BasicList<Token> tokens = Tokenizer.Tokenize(infix);
        BasicQueue<Token> postfix = ShuntingYardAlgorithm.InfixToRPN(tokens);

        Assert.That(postfix.Count, Is.EqualTo(5));
    }


    [Test]
    public void ShuntingYardAlgorithmShouldCorrectlyBuildSequence()
    {
        string infix = "max(sin(0), cos(0))";

        BasicList<Token> tokens = Tokenizer.Tokenize(infix);
        BasicQueue<Token> postfix = ShuntingYardAlgorithm.InfixToRPN(tokens);

        int limit = postfix.Count;
        string[] values = new string[limit];

        for (int i = 0; i < limit; i++)
        {
            values[i] = postfix.Dequeue().Value;
        }

        Assert.That(values, Is.EqualTo(["0", "sin", "0", "cos", "max"]));

    }
}
