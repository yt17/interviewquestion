using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class AddRuleType
    {
        public AddRuleType()
        {
            CampignRules = new HashSet<CampignRule>();
        }

        public int AddRuleType1 { get; set; }
        public string AddRuleName { get; set; }
        public int? ValType { get; set; }

        public virtual ICollection<CampignRule> CampignRules { get; set; }
    }
}
