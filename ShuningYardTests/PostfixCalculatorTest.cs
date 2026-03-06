using ShuntingYard;

namespace ShuntingYardTests;

internal class PostfixCalculatorTest
{
    [Test]
    public void Calculate_ShouldExecuteOperationsProperly()
    {
        Token token = new Token("456", TokenType.Number);

        BasicQueue<Token> queue = new();

        queue.Enqueue(token);

        double result = PostfixCalculator.Calculate(queue);

        Assert.That(result, Is.EqualTo(456.0));
    }

    [TestCase("1 + 24", 25.0 )]
    [TestCase("1 + 24 * 2", 49.0 )] 
    [TestCase("(1 + 24) * 2", 50.0 )]
    [TestCase("(1 + 24) * 2 ^ 3", 200.0 )]
    [TestCase("max(sin(0), cos(0))", 1.0 )]
    [TestCase("max(2,3)", 3.0 )]
    [TestCase("2+max(3,4)*5", 22.0 )]
    public void Calculate_CorrectlyProcessSimpleExpression(string expression, double expected)
    {
        BasicList<Token> tokens = Tokenizer.Tokenize(expression);
        BasicQueue<Token> postfix = ShuntingYardAlgorithm.InfixToRPN(tokens);

        double result = PostfixCalculator.Calculate(postfix);

        Assert.That(result, Is.EqualTo(expected));
    }
}
