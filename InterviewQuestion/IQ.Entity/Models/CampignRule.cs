using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class CampignRule
    {
        public int CampaignDetailId { get; set; }
        public int CampaignId { get; set; }
        public int AddRuleType { get; set; }
        public int Comparing { get; set; }
        public string Value { get; set; }
        public decimal? Splitter { get; set; }

        public virtual AddRuleType AddRuleTypeNavigation { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual Comparing ComparingNavigation { get; set; }
    }
}
