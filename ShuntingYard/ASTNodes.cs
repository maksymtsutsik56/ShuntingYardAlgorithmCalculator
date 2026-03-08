namespace ShuntingYard;

internal abstract record ASTNode
{
    public string Type { get; }
    public string Value { get; }

    protected ASTNode(string type, string value)
    {
        Type = type;
        Value = value;
    }
}

internal record NumberNode : ASTNode
{
    public NumberNode(string value) : base("Number", value) { }
}

internal record BinaryOperatorNode : ASTNode
{
    public ASTNode Left { get; }

    public ASTNode Right { get; }

    public BinaryOperatorNode(string value, ASTNode left, ASTNode right) : base("BinaryOperator", value)
    {
        Left = left;
        Right = right;
    }
}

internal record UnaryOperatorNode : ASTNode
{
    public ASTNode Operand { get; }

    public UnaryOperatorNode(string value, ASTNode operand ) : base("UnaryOperator", value)
    {
        Operand = operand;
    }
}



