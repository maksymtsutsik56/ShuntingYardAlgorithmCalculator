namespace ShuntingYard;

internal enum NodeType { Number, Binary, Unary }

internal abstract record ASTNode
{
    public NodeType Type { get; }
    public string Value { get; }

    protected ASTNode(NodeType type, string value)
    {
        Type = type;
        Value = value;
    }
}

internal record NumberNode : ASTNode
{
    public NumberNode(string value) : base(NodeType.Number, value) { }
}

internal record BinaryNode : ASTNode
{
    public ASTNode Left { get; }

    public ASTNode Right { get; }

    public BinaryNode(string value, ASTNode left, ASTNode right) : base(NodeType.Binary, value)
    {
        Left = left;
        Right = right;
    }
}

internal record UnaryNode : ASTNode
{
    public ASTNode Operand { get; }

    public UnaryNode(string value, ASTNode operand ) : base(NodeType.Unary, value)
    {
        Operand = operand;
    }
}

