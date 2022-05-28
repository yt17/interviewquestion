using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.ProjectClasses.DTO
{
    public class InvoiceReportDTO
    {
        public int TotalProductCount { get; set; }
        public decimal TotalProductPrice { get; set; }
        public string CampaignExplanition { get; set; }
        public decimal TotalProductPriceWithCampaign { get; set; }
    }
}
