using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RuleEngine.Interface;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace RuleEngineTest
{
    [TestClass]
    public class RuleScenario1Test : RuleMetadata
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
            var products = this.GetProducts(1, 1, 1, 0);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            var bill = ruleEngine.EvaluateRules(rules, products);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 1).FinalPrice, 50);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 2).FinalPrice, 30);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 3).FinalPrice, 20);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 4).FinalPrice, 0);

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
            var products = this.GetProducts(5, 5, 1, 0);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            var bill = ruleEngine.EvaluateRules(rules, products);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 1).FinalPrice, 230.05);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 2).FinalPrice, 120);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 3).FinalPrice, 20);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 4).FinalPrice, 0);

        }

        [TestMethod]
        public void ScenarioC()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = this.GetProducts(3, 5, 1, 1);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
           var bill = ruleEngine.EvaluateRules(rules, products);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 1).FinalPrice, 130.05);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 2).FinalPrice, 120);
            Assert.AreEqual(bill.FirstOrDefault(i => i.Id == 3).FinalPrice, 0);

        }

        [TestMethod]
        public void ScenarioD()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = this.GetProducts(10, 3, 1, 2);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            var bill = ruleEngine.EvaluateRules(rules, products);

        }

        [TestMethod]
        public void ScenarioE()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = this.GetProducts(11, 6, 3, 1);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            ruleEngine.EvaluateRules(rules, products);

        }

        [TestMethod]
        public void ScenarioF()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = this.GetProducts(11, 6, 2, 0);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            ruleEngine.EvaluateRules(rules, products);

        }

        [TestMethod]
        public void ScenarioG()
        {
            IRules rules = new RuleEngine.Interface.Fakes.StubIRules()
            {
                GetRules = () =>
                {
                    return GetRules();
                }
            };
            var products = this.GetProducts(11, 6, 0, 2);

            IRuleEngine ruleEngine = new RuleEngine.RuleEngine();
            ruleEngine.EvaluateRules(rules, products);

        }



        protected List<RuleParam> GetRules()
        {
            return this.GetRuleScenario("./FakeRules/Promotion.json");
        }
       
    }
}
