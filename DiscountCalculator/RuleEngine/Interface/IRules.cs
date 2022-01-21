namespace RuleEngine.Interface
{
    using global::RuleEngine.Model;
    using System.Collections.Generic;

    /// <summary>Rules Interface</summary>
    public interface IRules
    {
        /// <summary>Gets the rules.</summary>
        /// <returns>List of rule parameters for rule engine</returns>
        public List<RuleParam> GetRules();
    }
}
