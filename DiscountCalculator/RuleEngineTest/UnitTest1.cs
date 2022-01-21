using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RuleEngine.Interface;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RuleEngineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScenarioA()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                 {
                     return GetRuleScenario1();
                 }
            };
            var products = GetProducts(1, 1, 1, 0);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            ruleEngine.EvaluateRules(rules, products);

        }

        [TestMethod]
        public void ScenarioB()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRuleScenario1();
                }
            };
            var products = GetProducts(5, 5, 1, 0);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            ruleEngine.EvaluateRules(rules, products);

        }

        [TestMethod]
        public void ScenarioC()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRuleScenario1();
                }
            };
            var products = GetProducts(3, 5, 1, 1);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            ruleEngine.EvaluateRules(rules, products);

        }

        private List<RuleParam> GetRuleScenario1()
        {
            var rule = File.ReadAllText("./FakeRules/Promotion.json");
            var rules = JsonConvert.DeserializeObject<List<RuleParam>>(rule);
            return rules;

        }

        private List<Products> GetProducts(int apple, int biscuit, int chocolate, int detergent)
        {

            var products = new List<Products>()
            {
                new Products()
                {
                    Id=1,
                    Name="Apple",
                    Quantity=apple
                },
                new Products()
                {
                    Id=2,
                    Name="Buiscut",
                    Quantity=biscuit
                },
                new Products()
                {
                     Id=3,
                    Name="chocolate",
                    Quantity=chocolate
                },
                new Products()
                {
                     Id=4,
                    Name="detergent",
                    Quantity=detergent
                }
            };
            return products;
        }
    }
}
