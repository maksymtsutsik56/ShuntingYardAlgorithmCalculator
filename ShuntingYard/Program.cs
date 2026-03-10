using System.Linq.Expressions;

namespace ShuntingYard;

internal class Program
{
    static void Main()
    {
        string expression = ConsoleIO.ReadStringInput();

        BasicList<Token> tokens = Tokenizer.Tokenize(expression);
        BasicQueue<Token> postfix1 = ShuntingYardAlgorithm.InfixToRPN(tokens);
        BasicQueue<Token> postfix2 = ShuntingYardAlgorithm.InfixToRPN(tokens);

        double result = PostfixCalculator.Calculate(postfix1);
        ConsoleIO.PrintStringMessage($"Result: {result}");

        ASTNode tree = RPNtoASTObj.RPNtoAST(postfix2);  
        File.WriteAllText(@"D:\VS Dotnet\ShuntingYard\ast.dot", ASTObjToDotLanguage.DotStringBuilder(tree));
    }
}

