namespace ShuntingYard;

internal static class RPNtoASTObj
{
    public static ASTNode RPNtoAST(BasicQueue<Token> queue)
    {
        BasicStack<ASTNode> stack = new();

        while (queue.Count != 0)
        {
            Token token = queue.Dequeue();

            switch (token.Type)
            {
                case TokenType.Number:
                    {
                        NumberNode node = new NumberNode(token.Value);
                        stack.Push(node);
                        break;
                    }


                case TokenType.Operator:
                    {
                        ASTNode right = stack.Pop();
                        ASTNode left = stack.Pop();

                        BinaryOperatorNode node = new BinaryOperatorNode(token.Value, left, right);
                        stack.Push(node);

                        break;
                    }


                case TokenType.Function:
                    switch (OperatorInfo.GetArity(token.Value))
                    {
                        case 1:
                            {
                                ASTNode operand = stack.Pop();

                                UnaryOperatorNode node =  new UnaryOperatorNode(token.Value, operand);
                                stack.Push(node);

                                break;
                            }

                        case 2:
                            {
                                ASTNode right = stack.Pop();
                                ASTNode left = stack.Pop();

                                ASTNode node = new BinaryOperatorNode(token.Value, left, right);
                                stack.Push(node);

                                break;
                            }
                    }

                    break;
            }
        }

        return stack.Pop();
    }
}
