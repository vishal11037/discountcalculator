using RuleEngine.Interface;
using RuleEngine.Model;
using System;
using System.Collections.Generic;
using Z.Expressions;
using System.Linq;

namespace RuleEngine
{
    /// <summary>Rule Engine Interface</summary>
    public class RuleEngine : IRuleEngine
    {
        /// <summary>Evaluates the rules.</summary>
        /// <param name="rules">The rules.</param>
        /// <param name="products">The products.</param>
        /// <returns>List of Products with updated cost</returns>
        public List<Products> EvaluateRules(IRules rules, List<Products> products)
        {
            try
            {
                var baseRules = rules.GetRules();
                foreach (var product in products)
                {
                    var applicableRule = baseRules.FirstOrDefault(itm => itm.Id == product.Id && itm.IsActive == true);
                    product.ActualPrice = product.Quantity * applicableRule.Price;

                    if (applicableRule.IsGrouped)
                    {
                        var productCount = product.Quantity;
                        var groupedProductCount = products.FirstOrDefault(item => item.Id == applicableRule.GroupedWith)?.Quantity;
                        var productGroupCount = Math.Abs(Eval.Execute<double>(
                                                applicableRule.DiscountRule,
                                                new
                                                {
                                                    productCount = productCount,
                                                    groupedProductCount = groupedProductCount
                                                }));
                        
                        product.FinalPrice = Eval.Execute<double>(
                            applicableRule.Formula,
                            new
                            {
                                ActualPrice = product.ActualPrice,
                                productGroupCount = productGroupCount
                            });
                        product.DiscountPrice = product.ActualPrice - product.FinalPrice;
                    }
                    else
                    {
                        var discount = applicableRule.Discount;
                        var numberOfGroup = Math.Abs(Eval.Execute<double>(
                                                applicableRule.DiscountRule,
                                                new
                                                {
                                                    quantity = product.Quantity
                                                }));
                        var groupPrize = numberOfGroup * applicableRule.ItemCount* applicableRule.Price;
                        product.FinalPrice= Eval.Execute<double>(
                            applicableRule.Formula,
                            new
                            {
                                ActualPrice = product.ActualPrice,
                                DiscountPercentage = discount,
                                groupPrize = groupPrize,
                            });
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
