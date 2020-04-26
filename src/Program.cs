using System;
using System.Threading.Tasks;

namespace ArchPoetry
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                if (args.Length < 1) {
                    throw new Exception("Please provide a path to the grammar as the first argument.");
                }

                GrammarParser grammarParser = new GrammarParser();
                Grammar grammar = await grammarParser.ParseAsync(args[0]);
                Console.Write(grammar.WritePoem());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
