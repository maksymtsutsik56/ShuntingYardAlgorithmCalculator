
namespace ShuntingYard;

static class Tokenizer
{
    public static BasicList<Token> Tokenize(string expression)
    {
        BasicList<Token> list = new();
        int i = 0;

        while(i < expression.Length)
        {
            char c = expression[i];
            
            if (char.IsWhiteSpace(c))
            {
                i++;
                continue;
            }

            if (char.IsLetter(c))
            {
                int start = i;

                while (i < expression.Length && char.IsLetter(expression[i])) i++;

                string value = expression.Substring(start, i - start);

                list.Add(new Token(value, TokenType.Operator));
                continue;
            }

            if (char.IsDigit(c))
            {
                int start = i;

                while (i < expression.Length && char.IsDigit(expression[i])) i++;

                string value = expression.Substring(start, i - start);

                list.Add(new Token(value, TokenType.Number));
                continue;
            }

            list.Add(new Token(c.ToString(), TokenType.Operator));
            i++;
        }

        return list;
    }
}



//for (int i = 0; i < expression.Length; i++)
//{
//    char c = expression[i];

//    if (char.IsAsciiDigit(c))
//    {
//        string output = string.Empty;

//        while(char.IsAsciiDigit(c))
//        {   
//            output += c;

//            i++;
//            if (i >= expression.Length) break;

//            c = expression[i];
//        }

//        list.Add(output);
//    }

//    if (char.IsAsciiLetter(c))
//    {
//        string output = string.Empty;

//        while (char.IsAsciiLetter(c))
//        {
//            output += c;

//            i++;
//            if (i >= expression.Length) break;

//            c = expression[i];
//        }

//        if ((char.IsWhiteSpace(c))) continue;

//        list.Add(output);
//    }

//list.Add(c.ToString());
//}