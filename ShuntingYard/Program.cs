namespace ShuntingYard;

internal class Program
{
    static void Main()
    {
        string input = "  4 +  456";

        BasicList<Token> tokens = Tokenizer.Tokenize(input);
    }
}

