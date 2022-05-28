using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class Comparing
    {
        public Comparing()
        {
            CampignRules = new HashSet<CampignRule>();
        }

        public int ConditonId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CampignRule> CampignRules { get; set; }
    }
}
