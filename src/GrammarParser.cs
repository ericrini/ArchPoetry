using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ArchPoetry
{
    public class GrammarParser
    {
        public async Task<Grammar> ParseAsync(string path) {
            Grammar grammar = new Grammar();

            using(StreamReader streamReader = new StreamReader(path))
            {
                while (streamReader.Peek() != -1)
                {
                    string nextLine = await streamReader.ReadLineAsync();
                    List<string> tokens = new List<string>(nextLine.Split(' '));

                    if (tokens.Count < 2) {
                        throw new Exception("A grammar rule should consist of a name and one or more expressions.");
                    }

                    Rule rule = new Rule(tokens[0].Trim().Replace(":", ""));
                    tokens.RemoveAt(0);

                    foreach(string token in tokens)
                    {
                        Expression expression = new Expression(token.Split("|"));
                        rule.AddExpression(expression);
                    }

                    grammar.AddRule(rule);
                }
            }

            return grammar;
        }
    }
}
