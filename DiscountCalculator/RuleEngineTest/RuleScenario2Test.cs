using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Interface;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineTest
{
    [TestClass]
    public class RuleScenario2Test: RuleMetadata
    {

        [TestMethod]
        public void ScenarioA()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = GetProducts(1, 1, 1, 0);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            var result = ruleEngine.EvaluateRules(rules, products);

        }

        [TestMethod]
        public void ScenarioB()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = GetProducts(10, 5, 6, 5);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            var result = ruleEngine.EvaluateRules(rules, products);

        }

        private List<RuleParam> GetRules()
        {
            return this.GetRuleScenario("./FakeRules/Promotion2.json");
        }
    }
}
