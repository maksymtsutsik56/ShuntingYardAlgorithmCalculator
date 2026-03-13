namespace ShuntingYard;

internal record struct Vertex(int ParentId, ASTNode Node);

internal static class ASTObjToDotLanguage
{
    private static int _counter = 0;
    public static string DotStringBuilder(ASTNode root)
    {
        string labels = String.Empty;
        string connections = String.Empty;

        BasicStack<Vertex> stack = new();

        int id = IdNext();
        labels += CreateLabel(root, id);

        AddChildrenAndIgnoreLeaves(root, stack, id);

        while (stack.Count != 0)
        {
            Vertex currentVertex = stack.Pop();

            ASTNode currentNode = currentVertex.Node;

            int currentId = IdNext();
            labels += CreateLabel(currentNode, currentId);

            connections += CreateConnection(currentVertex.ParentId, currentId);
            AddChildrenAndIgnoreLeaves(currentNode, stack, currentId);
        }

        return "digraph AST {\n" + labels + connections + "}";
    }

    private static void AddChildrenAndIgnoreLeaves(ASTNode node, BasicStack<Vertex> stack, int parentId)
    {
        if (node is TernaryNode ternary)
        {

            stack.Push(new Vertex(parentId, ternary.Third));
            stack.Push(new Vertex(parentId, ternary.Second));
            stack.Push(new Vertex(parentId, ternary.First));

            return;
        }

        if (node is BinaryNode binary)
        {
            stack.Push(new Vertex(parentId, binary.Second));
            stack.Push(new Vertex(parentId, binary.First));

            return;
        }

        if (node is UnaryNode unary)
        {
            stack.Push(new Vertex(parentId, unary.Operand));

            return;
        }
    }

    private static int IdNext()
    {
        return _counter++;
    }
    private static string CreateConnection(int parent, int children)
    {
        return $"n{parent} -> n{children};\n";
    }
    private static string CreateLabel(ASTNode node, int Id)
    {
        return $"n{Id} [label = \"{node.Value}\"];\n";
    }
}