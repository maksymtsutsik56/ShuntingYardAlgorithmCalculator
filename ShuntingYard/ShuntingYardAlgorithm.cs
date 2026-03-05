namespace ShuntingYard;

static class ShuntingYardAlgorithm
{
    public static BasicQueue<Token> InfixToRPN(BasicList<Token> infix)
    {
        BasicQueue<Token> queue = new();
        BasicStack<Token> stack = new();

        for (int i = 0; i < infix.Count; i++)
        {
            Token token = infix[i];

            switch (token.Type)
            {
                case TokenType.Number:
                    queue.Enqueue(token);
                    break;

                case TokenType.OpenParenthesis:
                    stack.Push(token);
                    break;

                case TokenType.Operator:
                    while (stack.Count != 0 && stack.Peek().Type != TokenType.OpenParenthesis && (OperatorInfo.GetPriority(stack.Peek().Value) > OperatorInfo.GetPriority(token.Value) ||
                    (OperatorInfo.GetPriority(stack.Peek().Value) == OperatorInfo.GetPriority(token.Value) && OperatorInfo.GetAssociativity(token.Value) == Associativity.Left)))
                    {
                        queue.Enqueue(stack.Pop());
                    }

                    stack.Push(token);
                    break;

                case TokenType.CloseParenthesis:
                    while (stack.Peek().Type != TokenType.OpenParenthesis)
                    {
                        queue.Enqueue(stack.Pop());
                    }

                    stack.Pop();
                    break; 
            }
        }

        while (stack.Count != 0)
        {
            queue.Enqueue(stack.Pop());
        }

        return queue;
    }
}


