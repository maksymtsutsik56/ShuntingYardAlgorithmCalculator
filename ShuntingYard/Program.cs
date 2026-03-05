using System.Linq.Expressions;

namespace ShuntingYard;

internal class Program
{
    static void Main()
    {
        string expression = ConsoleIO.ReadStringInput();

        BasicList<Token> tokens = Tokenizer.Tokenize(expression);
        BasicQueue<Token> postfix = ShuntingYardAlgorithm.InfixToRPN(tokens);
        double result = PostfixCalculator.Calculate(postfix);

        ConsoleIO.PrintStringMessage($"Result: {result}");
    }
}

