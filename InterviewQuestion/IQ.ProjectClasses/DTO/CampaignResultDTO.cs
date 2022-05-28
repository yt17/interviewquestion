using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.ProjectClasses.DTO
{
    public class CampaignResultDTO
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public decimal PriceWithoutCampaign { get; set; }
        public decimal? PriceWithCampaign { get; set; }

    }
}
