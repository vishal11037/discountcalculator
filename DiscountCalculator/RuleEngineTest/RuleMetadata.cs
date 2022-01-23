using Newtonsoft.Json;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace RuleEngineTest
{
    public class RuleMetadata
    {
        protected List<RuleParam> GetRuleScenario(string rulePath)
        {
            var rule = File.ReadAllText(rulePath);
            var rules = JsonConvert.DeserializeObject<List<RuleParam>>(rule);
            return rules;

        }

        protected List<Products> GetProducts(int apple, int biscuit, int chocolate, int detergent)
        {
            var productCatalogue = File.ReadAllText("./Product/Product.json");
            var products = JsonConvert.DeserializeObject<List<Products>>(productCatalogue);
            products.FirstOrDefault(itm => itm.Id == 1).Quantity = apple;
            products.FirstOrDefault(itm => itm.Id == 2).Quantity = biscuit;
            products.FirstOrDefault(itm => itm.Id == 3).Quantity = chocolate;
            products.FirstOrDefault(itm => itm.Id == 4).Quantity = detergent;
            return products;
        }
    }
}
