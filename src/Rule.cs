using System;
using System.Collections.Generic;
using System.Text;

namespace ArchPoetry
{
    public class Rule
    {
        private readonly string _name;
        private readonly IList<Expression> _expressions = new List<Expression>();

        public Rule(string name) {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void AddExpression(Expression expression)
        {
            _expressions.Add(expression);
        }

        public string GetString(IDictionary<string, Rule> rules)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Expression expression in _expressions)
            {
                string next = expression.GetString(rules);

                if (!string.IsNullOrWhiteSpace(next) && !next.EndsWith(Environment.NewLine) && stringBuilder.Length > 0)
                {
                    stringBuilder.Append(' ');
                }

                stringBuilder.Append(next);
            }

            return stringBuilder.ToString();
        }
    }
}
