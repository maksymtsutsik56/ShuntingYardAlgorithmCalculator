namespace ShuntingYard;

internal enum NodeType { Number, Binary, Unary, Ternary }

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

internal record TernaryNode : ASTNode
{
    public ASTNode First { get; }

    public ASTNode Second { get; }
    public ASTNode Third { get; }

    public TernaryNode(string value, ASTNode first, ASTNode second, ASTNode third) : base(NodeType.Binary, value)
    {
        First = first;
        Second = second;
        Third = third;
    }
}

internal record BinaryNode : ASTNode
{
    public ASTNode First { get; }

    public ASTNode Second { get; }

    public BinaryNode(string value, ASTNode first, ASTNode second) : base(NodeType.Binary, value)
    {
        First = first;
        Second = second;
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

