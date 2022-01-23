namespace RuleEngine.Model
{
    /// <summary>Product catalogue</summary>
    public class Products
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the quantity.</summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the product price.</summary>
        /// <value>The product price.</value>
        public double Price { get; set; }

        /// <summary>Gets or sets the actual price.</summary>
        /// <value>The actual price.</value>
        public double TotalPrice { get; set; }

        /// <summary>Gets or sets the discount price.</summary>
        /// <value>The discount price.</value>
        public double DiscountPrice { get; set; }

        /// <summary>Gets or sets the final price.</summary>
        /// <value>The final price.</value>
        public double FinalPrice { get; set; }
    }
}
