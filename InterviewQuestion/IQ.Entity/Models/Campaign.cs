using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampignRules = new HashSet<CampignRule>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CampaignStatus { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DiscountTypeId { get; set; }
        public decimal? DiscountValue { get; set; }

        public virtual DiscountType DiscountType { get; set; }
        public virtual ICollection<CampignRule> CampignRules { get; set; }
    }
}
