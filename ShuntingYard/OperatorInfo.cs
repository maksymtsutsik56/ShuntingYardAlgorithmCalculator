namespace ShuntingYard;

internal class OperatorInfo
{
    static public readonly string[] AllowedOperators = new string[] { "+", "-", "*", "/", "^", "(", ")", "sin", "cos", "max", "clamp" };

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

    static public int GetArity(string @operator) => @operator switch
    {
        "+" or "-" or "*" or "/" or "^" or "max" => 2,
        "sin" or "cos" => 1,
        "clamp" => 3,

        _ => throw new ArgumentException()
    };

    public static double Apply(double first, double second, double third, string @operator) => @operator switch
    {
        "clamp" => Math.Clamp(first, second, third),

        _ => throw new ArgumentException()
    };

    public static double Apply(double first, double second, string @operator) => @operator switch
    {
        "+" => first + second,
        "-" => first - second,
        "*" => first * second,
        "/" => first / second,
        "^" => Math.Pow(first, second),
        "max" => Math.Max(second, first),

        _ => throw new ArgumentException()
    };

    public static double Apply(double first, string @operator) => @operator switch
    { 
        "sin" => Math.Sin(first),
        "cos" => Math.Cos(first),

        _ => throw new ArgumentException()
    };
}
