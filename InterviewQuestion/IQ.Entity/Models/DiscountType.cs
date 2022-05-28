using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class DiscountType
    {
        public DiscountType()
        {
            Campaigns = new HashSet<Campaign>();
        }

        public int CampaignDiscountTypeId { get; set; }
        public string DiscountName { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
