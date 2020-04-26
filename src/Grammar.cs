using System.Collections.Generic;
using System.Text;

namespace ArchPoetry
{
    public class Grammar
    {
        private readonly IDictionary<string, Rule> _rules = new Dictionary<string, Rule>();
        private string _first;

        public void AddRule(Rule rule)
        {
            if (_first == null) {
                _first = rule.GetName();
            }

            _rules.Add(rule.GetName(), rule);
        }

        public string WritePoem()
        {
            return _rules[_first].GetString(_rules);
        }
    }
}
