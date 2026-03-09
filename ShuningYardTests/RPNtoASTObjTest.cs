using ShuntingYard;
namespace ShuntingYardTests;

internal class RPNtoASTObjTest
{
    [Test]
    
    public void RPNtoAST_ShouldReturnExpectedASTObject()
    {
        BasicList<Token> tokens = Tokenizer.Tokenize("(3 + 4) * 5 + sin(4)");
        BasicQueue<Token> postfix = ShuntingYardAlgorithm.InfixToRPN(tokens);

        ASTNode result = RPNtoASTObj.RPNtoAST(postfix);

        NumberNode three = new NumberNode("3");
        NumberNode four = new NumberNode("4");
        NumberNode five = new NumberNode("5");

        BinaryNode plus = new BinaryNode("+", three, four);
        BinaryNode multiplication = new BinaryNode("*", plus, five);

        UnaryNode sin = new UnaryNode("sin", four);

        BinaryNode finalMinus = new BinaryNode("+", multiplication, sin);



        Assert.That(result, Is.EqualTo(finalMinus));
    }
}
