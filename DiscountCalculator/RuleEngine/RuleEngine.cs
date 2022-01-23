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
                    product.TotalPrice = product.Quantity * product.Price;

                    if (applicableRule.IsGrouped)
                    {
                        //// Product count.
                        var productCount = product.Quantity;

                        //// product details with which it is grouped.
                        var groupedProduct = products.FirstOrDefault(item => item.Id == applicableRule.GroupedWith);
                        var groupedProductCount = groupedProduct?.Quantity;
                        var groupedProductPrice = groupedProduct?.Price;

                        //// calculate the number of applicable groups
                        var productGroupCount = Math.Abs(Eval.Execute<int>(
                                                applicableRule.DiscountRule,
                                                new
                                                {
                                                    ProductCount = productCount,
                                                    GroupedProductCount = groupedProductCount
                                                }));

                        //// calculate the final price of this grouped item
                        product.FinalPrice = Eval.Execute<double>(
                            applicableRule.Formula,
                            new
                            {
                                ProductPrice = product.Price,
                                GroupedProductPrice = Convert.ToDouble(groupedProductPrice),
                                GroupedProductCount = Convert.ToDouble(groupedProductCount),
                                ProductCount = Convert.ToDouble(productCount),
                                ProductGroupCount = Convert.ToDouble(productGroupCount),
                                DiscountPercentage = Convert.ToDouble(applicableRule.Discount)
                            });
                        product.DiscountPrice = product.TotalPrice - product.FinalPrice;
                    }
                    else
                    {
                        var discount = applicableRule.Discount;
                        var numberOfGroup = Math.Abs(Eval.Execute<double>(
                                                applicableRule.DiscountRule,
                                                new
                                                {
                                                    Quantity = product.Quantity
                                                }));
                        var groupPrize = numberOfGroup * applicableRule.ItemCount * product.Price;
                        product.FinalPrice = Eval.Execute<double>(
                            applicableRule.Formula,
                            new
                            {
                                TotalPrice = product.TotalPrice,
                                DiscountPercentage = discount,
                                GroupPrize = groupPrize,
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
