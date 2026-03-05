using System.Reflection.Emit;

namespace ShuntingYard;

static class PostfixCalculator
{
    public static double Calculate(BasicQueue<Token> queue)
    {
        BasicStack<double> stack = new();

        while(queue.Count != 0)
        {
            Token token = queue.Dequeue();

            switch (token.Type)
            {
                case TokenType.Number:
                    stack.Push(double.Parse(token.Value)); 
                    break;

                case TokenType.Operator:
                    double second = stack.Pop();
                    double first = stack.Pop();

                    double result = OperatorInfo.Apply(first, second, token.Value); 
                    stack.Push(result);
                    break;
            }
        }

        return stack.Pop();
    }
}
