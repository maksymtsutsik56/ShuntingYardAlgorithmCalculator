using NUnit.Framework.Legacy;
using ShuntingYard;

namespace ShuntingYardTests
{
    internal class TokenizerTest
    {
        [Test]

        public void TokenizeShouldReturnDesiredTokens() 
        {
            string input = "  ( 4 +  sin   456)";

            BasicList<Token> tokens = Tokenizer.Tokenize(input);

            Token first = tokens[0];
            Token second = tokens[1];
            Token third = tokens[2];
            Token fourth = tokens[3];
            Token fifth = tokens[4];
            Token sixth = tokens[5];

            Token[] result = new Token[6] { first, second, third, fourth, fifth, sixth };
            Token[] expected = new Token[6] { new Token("(", TokenType.OpenParenthesis), new Token("4", TokenType.Number), new Token("+", TokenType.Operator),
                                             new Token("sin", TokenType.Operator), new Token("456", TokenType.Number), new Token(")", TokenType.CloseParenthesis) };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TokenizeShouldReturnBasicListOfExpectedLength()
        {
            string input = "4+456-(56+78)+sin567";

            BasicList<Token> tokens = Tokenizer.Tokenize(input);

            int result = tokens.Count;

            Assert.That(result, Is.EqualTo(12));
        }
    }
}
