using IQ.BusinessLayer.Abstracts;
using IQ.ProjectClasses.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQ.API.Controllers
{
    [ApiController, Route("api/[controller]")]    
    public class InvoiceCalculateController : ControllerBase
    {
        private IInvoiceService invoiceService;
        public InvoiceCalculateController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }
        [HttpPost]
        public List<CampaignResultDTO> CalculateInvoiceReports([FromBody] InvoiceCalculateDTO invoiceCalculateDTO)
        {
            return invoiceService.SendInvoiceForControl(invoiceCalculateDTO);
        }
    }
}
