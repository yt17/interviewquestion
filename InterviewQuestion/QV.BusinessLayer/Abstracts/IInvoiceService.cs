using IQ.ProjectClasses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.BusinessLayer.Abstracts
{
    public interface IInvoiceService
    {
        public List<CampaignResultDTO> SendInvoiceForControl(InvoiceCalculateDTO invoiceCalculateDTO);
    }
}
