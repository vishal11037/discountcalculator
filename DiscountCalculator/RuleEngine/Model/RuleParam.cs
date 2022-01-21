namespace RuleEngine.Model
{
    /// <summary>Rule Parameters</summary>
    public class RuleParam
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the discount.</summary>
        /// <value>The discount.</value>
        public double Discount { get; set; }

        /// <summary>Gets or sets the discount rule.</summary>
        /// <value>The discount rule.</value>
        public string DiscountRule { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>Gets or sets the item count.</summary>
        /// <value>The item count.</value>
        public int ItemCount { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        public double Price { get; set; }

        /// <summary>Gets or sets the formula.</summary>
        /// <value>The formula.</value>
        public string Formula { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is grouped.</summary>
        /// <value>
        ///   <c>true</c> if this instance is grouped; otherwise, <c>false</c>.</value>
        public bool IsGrouped { get; set; }

        /// <summary>Gets or sets the grouped with.</summary>
        /// <value>The grouped with.</value>
        public int GroupedWith { get; set; }
    }
}
