using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Interface
{
    public interface IRuleEngine
    {
        public List<Products> EvaluateRules(IRules rules,List<Products> products);

    }
}
