namespace ShuntingYard;

internal class OperatorInfo
{
    static public readonly string[] AllowedOperators = new string[] { "+", "-", "*", "/", "^", "(", ")" };

    static public Associativity GetAssociativity(string @operator) => @operator switch
    {
        "+" or "-" or "*" or "/" => Associativity.Left,
        "^" => Associativity.Right,

        _ => throw new ArgumentException()
    };

    static public int GetPriority(string @operator) => @operator switch
    {
        "+" or "-" => 1,
        "*" or "/" => 2,
        "^" => 3,

        _ => throw new ArgumentException()
    };

    public static double Apply(double first, double second, string @operator) => @operator switch
    {
        "+" => first + second,
        "-" => first - second,
        "*" => first * second,
        "/" => first / second,
        "^" => Math.Pow(first, second),

        _ => throw new ArgumentException()
    };
}
