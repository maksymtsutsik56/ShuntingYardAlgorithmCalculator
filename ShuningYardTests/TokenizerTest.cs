using NUnit.Framework.Legacy;
using ShuntingYard;

namespace ShuntingYardTests
{
    internal class TokenizerTest
    {
        [Test]

        public void TokenizeShouldReturnDesiredTokens() 
        {
            string input = "  4 +  sin   456";

            BasicList<Token> tokens = Tokenizer.Tokenize(input);

            Token first = tokens[0];
            Token second = tokens[1];
            Token third = tokens[2];
            Token fourth = tokens[3];


            Token[] result = new Token[4] { first, second, third, fourth };
            Token[] expected = new Token[4] { new Token("4", TokenType.Number), new Token("+", TokenType.Operator),
                                             new Token("sin", TokenType.Operator), new Token("456", TokenType.Number) };

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
