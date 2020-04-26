using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ArchPoetry
{
    public class Expression
    {
        private readonly IList<string> _expressions;

        public Expression(string[] expressions) {
            _expressions = ImmutableList<string>.Empty.AddRange(expressions);
        }

        public string GetString(IDictionary<string, Rule> rules)
        {
            string current = _expressions[new Random().Next(_expressions.Count)];

            // End
            if (current.ToLower() == "$end")
            {
                return "";
            }

            // Line Break
            if (current.ToLower() == "$linebreak")
            {
                return Environment.NewLine;
            }

            // Rule
            if (current.StartsWith("<") && current.EndsWith(">"))
            {
                string rule = current.Replace("<", "").Replace(">", "");

                if (!rules.ContainsKey(rule))
                {
                    throw new Exception($"No definition for rule '{rule}' was found.");
                }

                return rules[rule].GetString(rules);
            }

            // Word
            return current;
        }
    }
}
